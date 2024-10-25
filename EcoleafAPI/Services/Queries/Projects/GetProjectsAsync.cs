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
    public class GetProjectsService
    {
        private readonly IMediator _mediator;
        public GetProjectsService(IMediator mediator)
        {
            _mediator = mediator;
        }
       

        public async Task<List<ProjectsDTO>> GetProjects()
        {

            var result = await _mediator.Send(new GetProjectsQuery());

            if (result is null)
            {
                result = new List<ProjectsDTO>();
            }

            return result;
            //throw new NotImplementedException();
        }
      

    }
    public static class GetProjectsAsyncInjection
    {
        public static IServiceCollection GetProjectsAsyncApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetProjectsAsyncInjection).Assembly));
            return services;
        }
    }
    public class GetProjectsQuery : IRequest<List<ProjectsDTO>>
    {

        public GetProjectsQuery()
        {
           
        }
    }

    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, List<ProjectsDTO>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly ILogger<GetProjectsQueryHandler> _logger;

        public GetProjectsQueryHandler(IRepositoryService repositoryService, ILogger<GetProjectsQueryHandler> logger)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));

            _logger = logger;
        }
        
        public async Task<List<ProjectsDTO>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
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
                //var jsonSettings = new JsonSerializerSettings()
                //{ ContractResolver = new IgnorePropertiesResolver(new[] { "none" }) };
                //var jsonRes = JsonConvert.SerializeObject(request.Projects, jsonSettings);

                var dbParams = new DynamicParameters();
               

                projects = await _repositoryService.GetJsonPathAsyncV2<List<ProjectsDTO>>(StoredProcedures.ProjectsSP.GET_ALL_PROJECTS, dbParams);
               

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


