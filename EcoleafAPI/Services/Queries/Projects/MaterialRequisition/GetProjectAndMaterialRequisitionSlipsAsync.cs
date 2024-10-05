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
      
        public async Task<List<ProjectsDTO>> GetProjectAndMaterialRequisitionSlipsByUserUIDQueryAsync(Guid UserUID, ProjectsDTO projects)
        {
            var resultMediator = await _mediator.Send(new GetProjectAndMaterialRequisitionSlipsQuery( UserUID, projects, "useruid"));
      
            if (resultMediator is null)
            {
                resultMediator = new List<ProjectsDTO>();
            }

            return resultMediator;
            //throw new NotImplementedException();
        }
        public async Task<List<ProjectsDTO>> GetProjectAndMaterialRequisitionSlipsByProjectUIDQueryAsync(Guid UserUID, ProjectsDTO projects)
        {
            var resultMediator = await _mediator.Send(new GetProjectAndMaterialRequisitionSlipsQuery(UserUID, projects, "projectuid"));

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
        public ProjectsDTO Projects { get; set; }

        public GetProjectAndMaterialRequisitionSlipsQuery(Guid userUID, ProjectsDTO projects, string command = null)
        {
            UserUID = userUID;
            Command = command;
            Projects = projects;
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

        public async Task<List<ProjectsDTO>> Handle(GetProjectAndMaterialRequisitionSlipsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching users from the repository.");

            if (_repositoryService == null)
            {
                _logger.LogError("Repository service is null.");
                throw new GraphQLException("Repository service is null.");
            }

            List<ProjectsDTO> users = new List<ProjectsDTO>();
            try
            {
                var jsonSettings = new JsonSerializerSettings()
                { ContractResolver = new IgnorePropertiesResolver(new[] { "none" }) };
                var jsonRes = JsonConvert.SerializeObject(request.Projects, jsonSettings);


                var dbParams = new DynamicParameters();
                dbParams.Add("command", request.Command);
                dbParams.Add("postedData", jsonRes);
                dbParams.Add("userUID", request.UserUID);

                users = await _repositoryService.GetJsonPathAsyncV2<List<ProjectsDTO>>(StoredProcedures.ProjectsSP.GET_ALL_MATERIALREQUISITIONSLIP, dbParams);

                if (users == null)
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

            return users;
        }
    }

}


