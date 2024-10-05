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
using Common.DTO.HumanResourceManagement;

namespace EcoleafAPI.Services.Queries.Users
{
    public class EmployeesMutationService
    {
        private readonly IMediator _mediator;
        public EmployeesMutationService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<EmployeesDTO> InsertEmployee(EmployeesDTO userModuleDetails,Guid userUID)
        {


            var createRes = await _mediator.Send(new EmployeesMutationMutation(userModuleDetails, userUID));
            if (createRes is null)
            {
                throw new Exception("The server is temporarily down, please try again later.");
            }
            //throw new NotImplementedException();
            return createRes;
        }
      

    }
    public static class EmployeesMutationMutationAsyncInjection
    {
        public static IServiceCollection EmployeesMutationMutationAsyncApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EmployeesMutationMutationAsyncInjection).Assembly));
            return services;
        }
    }
    public class EmployeesMutationMutation : IRequest<EmployeesDTO>
    {
        public string Command { get; set; }
        public EmployeesDTO Employee { get; set; }
        public Guid UserUID { get; set; }
        public EmployeesMutationMutation(EmployeesDTO employee, Guid userUID, string command = null)
        {
            Employee = employee;
            Command = command;
            UserUID = userUID;
        }
    }

    public class EmployeesMutationMutationHandler : IRequestHandler<EmployeesMutationMutation, EmployeesDTO>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly ILogger<EmployeesMutationMutationHandler> _logger;

        public EmployeesMutationMutationHandler(IRepositoryService repositoryService, ILogger<EmployeesMutationMutationHandler> logger)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));

            _logger = logger;
        }

        public async Task<EmployeesDTO> Handle(EmployeesMutationMutation request, CancellationToken cancellationToken)
        {
           
            if (_repositoryService == null)
            {
                throw new GraphQLException("Repository service is null.");
            }

            EmployeesDTO users = new EmployeesDTO();
            try
            {
                var jsonSettings = new JsonSerializerSettings()
                { ContractResolver = new IgnorePropertiesResolver(new[] { "RoleName" }) };
                var jsonRes = JsonConvert.SerializeObject(request.Employee, jsonSettings);


                var dbParams = new DynamicParameters();
                dbParams.Add("userUID", request.UserUID);
                dbParams.Add("postedData", jsonRes);

                users = await _repositoryService.ExecuteWithReturnAsync<EmployeesDTO>(StoredProcedures.EmployeeSP.CREATE_EMPLOYEE, dbParams);

                if (users == null)
                {
                    throw new GraphQLException("No users found from the stored procedure.");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return users;
        }
    }

}


