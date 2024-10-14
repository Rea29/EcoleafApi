using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.DTO.Users;
using Common.Helpers;
using Common.Constants;
using Datalayer;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Common.Model.Global;
using Common.DTO.ProjectMonitoringManagement;
using Common.DTO.MaterialsInventory;
using Common.DTO.MaterialRequisitionSlip;
using DTO.MaterialRequesitionSlip;
using Common.DTO.HumanResourceManagement;
using static Common.Constants.StoredProcedures;

namespace EcoleafAPI.Services.Queries.Users
{
    public class GetProjectAndMaterialRequisitionSlipsQueryService
    {
        private readonly IMediator _mediator;
        public GetProjectAndMaterialRequisitionSlipsQueryService(IMediator mediator)
        {
            _mediator = mediator;
        }
       

        public async Task<List<UserDTO>> GetUsersQueryAsync()
        {

            var result = await _mediator.Send(new GetUsersQuery());

            if (result is null)
            {
                result = new List<UserDTO>();
            }

            return result;
            //throw new NotImplementedException();
        }
      
        public async Task<List<ProjectsDTO>> GetProjectAndMaterialRequisitionSlipsByUserUIDQueryAsync(Guid UserUID, ProjectsDTO projects,EmployeesDTO employeesDTO)
        {
            var resultMediator = await _mediator.Send(new GetProjectAndMaterialRequisitionSlipsQuery( UserUID, projects, employeesDTO, null,"useruid"));
      
            if (resultMediator is null)
            {
                resultMediator = new List<ProjectsDTO>();
            }

            return resultMediator;
            //throw new NotImplementedException();
        }
        public async Task<List<ProjectsDTO>> GetProjectAndMaterialRequisitionSlipsByProjectUIDQueryAsync(Guid UserUID, ProjectsDTO projects, EmployeesDTO emp, string materialRequestUID)
        {
            var resultMediator = await _mediator.Send(new GetProjectAndMaterialRequisitionSlipsQuery(UserUID, projects, emp, materialRequestUID, "projectuid"));

            if (resultMediator is null)
            {
                resultMediator = new List<ProjectsDTO>();
            }

            return resultMediator;
            //throw new NotImplementedException();
        }

    }
    public static class GetProjectAndMaterialRequisitionSlipsQueryAsyncInjection
    {
        public static IServiceCollection GetProjectAndMaterialRequisitionSlipsQueryAsyncApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUsersQueryAsyncInjection).Assembly));
            return services;
        }
    }
    public class GetProjectAndMaterialRequisitionSlipsQuery : IRequest<List<ProjectsDTO>>
    {
        public string Command { get; set; }
        //public MaterialRequisitionSlipDTO User { get; set; }
        public Guid UserUID { get; set; }
        public string MaterialRequestUID { get; set; }
        public ProjectsDTO Projects { get; set; }
        public EmployeesDTO Employee { get; set; }

        public GetProjectAndMaterialRequisitionSlipsQuery(Guid userUID, ProjectsDTO projects, EmployeesDTO employees,string materialRequestUID, string command = null )
        {
            UserUID = userUID;
            Command = command;
            Projects = projects;
            Employee = employees;
            MaterialRequestUID = materialRequestUID;
        }
    }

    public class GetProjectAndMaterialRequisitionSlipsQueryHandler : IRequestHandler<GetProjectAndMaterialRequisitionSlipsQuery, List<ProjectsDTO>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly ILogger<GetProjectAndMaterialRequisitionSlipsQueryHandler> _logger;

        public GetProjectAndMaterialRequisitionSlipsQueryHandler(IRepositoryService repositoryService, ILogger<GetProjectAndMaterialRequisitionSlipsQueryHandler> logger)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));

            _logger = logger;
        }
        public bool IsPreviousApproverApproved(List<MRSApproversDTO> approvers, EmployeesDTO approverEmployee)
        {
            // Find the current approver by their EmployeesUID
            var currentApprover = approvers
                .FirstOrDefault(a => a.EmployeesUID == approverEmployee.EmployeesUID);

            // If the current approver is not found, return false (or handle this case differently if needed)
            if (currentApprover == null)
            {
                return false;
            }

            // Find the previous approver based on hierarchy sequence
            var previousApprover = approvers
                .Where(a => a.HierarchySequence < currentApprover.HierarchySequence)
                .OrderByDescending(a => a.HierarchySequence) // Get the most recent previous approver
                .FirstOrDefault();

            // If there is no previous approver, assume it's the first in the sequence and return true
            if (previousApprover == null)
            {
                return true; // No previous approver means no dependency
            }

            // Check if the previous approver has approved
            return previousApprover.IsApproved ?? false; // Return false if IsApproved is null
        }
        public async Task<List<ProjectsDTO>> Handle(GetProjectAndMaterialRequisitionSlipsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching users from the repository.");

            if (_repositoryService == null)
            {
                _logger.LogError("Repository service is null.");
                throw new GraphQLException("Repository service is null.");
            }

            List<ProjectsDTO> projects = new List<ProjectsDTO>();
            try
            {
                var jsonSettings = new JsonSerializerSettings()
                { ContractResolver = new IgnorePropertiesResolver(new[] { "none" }) };
                var jsonRes = JsonConvert.SerializeObject(request.Projects, jsonSettings);

                var dbParams = new DynamicParameters();
                dbParams.Add("command", request.Command);
                //dbParams.Add("postedData", jsonRes);
                dbParams.Add("userUID", request.UserUID);

                if(request.MaterialRequestUID is not null)
                {
                    dbParams.Add("materialRequestUID", new Guid(request.MaterialRequestUID));
                }
                else
                {
                    dbParams.Add("materialRequestUID", null);

                }
                List<SubMaterialRequisitionSlipDTO> materialRequisitionSlipDTOs = new List<SubMaterialRequisitionSlipDTO>();
                //dbParams.Add("projectUID", request.Projects.ProjectUID);
                if (request.Command == "useruid")
                {
                   
                    materialRequisitionSlipDTOs = await _repositoryService.GetJsonPathAsyncV2<List<SubMaterialRequisitionSlipDTO>>(StoredProcedures.ProjectsSP.GET_ALL_MATERIALREQUISITIONSLIP, dbParams);
                }else if(request.Command == "projectuid")
                {
                    projects = await _repositoryService.GetJsonPathAsyncV2<List<ProjectsDTO>>(StoredProcedures.ProjectsSP.GET_ALL_MATERIALREQUISITIONSLIP, dbParams);
                }
               
                if (request.Command == "useruid" && materialRequisitionSlipDTOs is not null)
                {
                    List<ProjectsDTO> projectsTemp = new List<ProjectsDTO>();
                    foreach (SubMaterialRequisitionSlipDTO mrs in materialRequisitionSlipDTOs)
                    {
                        var mrsProjectTemp = mrs.Project.FirstOrDefault();
                        if (projectsTemp.Any(p => p.ProjectUID == mrsProjectTemp.ProjectUID))
                        {
                            // Project with this UID already exists
                            if (mrs is not null)
                            {
                                var existingProject = projectsTemp.First(p => p.ProjectUID == mrsProjectTemp.ProjectUID);

                                // Ensure MaterialRequisitionSlip is initialized before adding
                                if (mrsProjectTemp.MaterialRequisitionSlip == null)
                                {
                                    mrsProjectTemp.MaterialRequisitionSlip = new List<SubMaterialRequisitionSlipDTO>();
                                }
                                if(new Guid(mrs.CreatedBy) == request.UserUID)
                                {
                                    mrs.Project = null;
                                    existingProject.MaterialRequisitionSlip.Add(mrs);
                                }
                                else
                                {
                                    if (mrs.Approvers is not null)
                                    {
                                        var myApproval = mrs.Approvers.Where(x => x.EmployeesUID == request.Employee.EmployeesUID).FirstOrDefault();
                                        if (myApproval is not null)
                                        {
                                            if (!(bool)myApproval.IsApproved)
                                            {
                                                bool isPreviousApproverApproved = IsPreviousApproverApproved(mrs.Approvers, request.Employee);
                                                if (isPreviousApproverApproved)
                                                {
                                                    mrs.Project = null;
                                                    existingProject.MaterialRequisitionSlip.Add(mrs); // Add to the new list
                                                                                                      // Exclude project to avoid circular reference
                                                }
                                            }
                                        }

                                    }
                                }
                             

                            }
                        }
                        else
                        {
                            
                            if (mrs is not null)
                            {
                                // Ensure MaterialRequisitionSlip is initialized before adding
                                if (mrsProjectTemp.MaterialRequisitionSlip == null)
                                {
                                    mrsProjectTemp.MaterialRequisitionSlip = new List<SubMaterialRequisitionSlipDTO>();
                                }

                                if (new Guid(mrs.CreatedBy) == request.UserUID)
                                {
                                    mrsProjectTemp.MaterialRequisitionSlip.Add(mrs); // Add to the new list
                                    mrs.Project = null;  // Exclude project to avoid circular reference
                                                         //mrsProjectTemp.MaterialRequisitionSlip.Add(mrs);  // Add the mrs
                                    projectsTemp.Add(mrsProjectTemp);  // Add project to the temp list
                                }
                                else
                                {
                                    if (mrs.Approvers is not null)
                                    {
                                        var myApproval = mrs.Approvers.Where(x => x.EmployeesUID == request.Employee.EmployeesUID).FirstOrDefault();
                                        if (myApproval is not null)
                                        {
                                            if (!(bool)myApproval.IsApproved)
                                            {
                                                bool isPreviousApproverApproved = IsPreviousApproverApproved(mrs.Approvers, request.Employee);
                                                if (isPreviousApproverApproved)
                                                {
                                                    mrsProjectTemp.MaterialRequisitionSlip.Add(mrs); // Add to the new list
                                                    mrs.Project = null;  // Exclude project to avoid circular reference
                                                                         //mrsProjectTemp.MaterialRequisitionSlip.Add(mrs);  // Add the mrs
                                                    projectsTemp.Add(mrsProjectTemp);  // Add project to the temp list
                                                }
                                            }
                                        }


                                    }
                                }
                                

                            }
                          
                        }
                    }
                    projects = projectsTemp;
                }

                //if (request.Command == "projectuid")
                //{
                //    List<ProjectsDTO> projectsTemp = new List<ProjectsDTO>();

                //    foreach (ProjectsDTO project in projects)
                //    {
                //        if (project.MaterialRequisitionSlip is not null)
                //        {
                //            ProjectsDTO projectTemp = new ProjectsDTO();
                //            projectTemp = project;
                //            if(project.ProjectUID == request.Projects.ProjectUID)
                //            {
                //                // Create a new list to store the filtered slips
                //                List<SubMaterialRequisitionSlipDTO> subMaterialRequisitionSlipDTO = new List<SubMaterialRequisitionSlipDTO>();

                //                foreach (SubMaterialRequisitionSlipDTO MaterialRequisitionSlip in project.MaterialRequisitionSlip)
                //                {

                //                    if (new Guid(MaterialRequisitionSlip.CreatedBy) == request.UserUID)
                //                    {
                //                        subMaterialRequisitionSlipDTO.Add(MaterialRequisitionSlip); // Add to the new list
                //                    }

                //                    if (MaterialRequisitionSlip.Approvers is not null)
                //                    {
                //                        bool isPreviousApproverApproved = IsPreviousApproverApproved(MaterialRequisitionSlip.Approvers, request.Employee);
                //                        if (isPreviousApproverApproved)
                //                        {
                //                            subMaterialRequisitionSlipDTO.Add(MaterialRequisitionSlip); // Add to the new list
                //                        }
                //                    }
                //                }

                //                if (subMaterialRequisitionSlipDTO.Count > 0)
                //                {
                //                    // Only add the project if there's any valid slip
                //                    projectTemp.MaterialRequisitionSlip = subMaterialRequisitionSlipDTO;
                //                    projectsTemp.Add(projectTemp);
                //                }
                //            }
                           
                //        }
                //    }

                //    if (projectsTemp.Any())
                //    {
                //        return projectsTemp.Where(p=> p.MaterialRequisitionSlip is not null).ToList();
                //    }
                //}

                if (projects == null)
                {
                    _logger.LogWarning("No users found from the stored procedure.");
                    throw new GraphQLException("No users found from the stored procedure.");
                }

                _logger.LogInformation("Successfully fetched users.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while fetching users: {ex.Message}");
                throw;
            }

            return projects;
        }
    }

}


