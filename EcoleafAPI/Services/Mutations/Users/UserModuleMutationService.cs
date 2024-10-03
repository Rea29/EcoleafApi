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

namespace EcoleafAPI.Services.Queries.Users
{
    public class UserModuleMutationService
    {
        private readonly IMediator _mediator;
        public UserModuleMutationService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<UserModuleDetailsDTO> ManageUserModule(UserModuleDetailsDTO userModuleDetails)
        {


            var createRes = await _mediator.Send(new UserModuleMutation(userModuleDetails));
            if (createRes is null)
            {
                throw new Exception("The server is temporarily down, please try again later.");
            }
            //throw new NotImplementedException();
            return createRes;
        }
      

    }
    public static class UserModuleMutationAsyncInjection
    {
        public static IServiceCollection UserModuleMutationAsyncApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserModuleMutationAsyncInjection).Assembly));
            return services;
        }
    }
    public class UserModuleMutation : IRequest<UserModuleDetailsDTO>
    {
        public string Command { get; set; }
        public UserModuleDetailsDTO UserModuleDetails { get; set; }
        public UserModuleMutation(UserModuleDetailsDTO userModuleDetails = null, string command = null)
        {
            UserModuleDetails = userModuleDetails;
            Command = command;
        }
    }

    public class UserModuleMutationHandler : IRequestHandler<UserModuleMutation, UserModuleDetailsDTO>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly ILogger<UserModuleMutationHandler> _logger;

        public UserModuleMutationHandler(IRepositoryService repositoryService, ILogger<UserModuleMutationHandler> logger)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));

            _logger = logger;
        }

        public async Task<UserModuleDetailsDTO> Handle(UserModuleMutation request, CancellationToken cancellationToken)
        {
           
            if (_repositoryService == null)
            {
                throw new GraphQLException("Repository service is null.");
            }

            UserModuleDetailsDTO users = new UserModuleDetailsDTO();
            try
            {
                var jsonSettings = new JsonSerializerSettings()
                { ContractResolver = new IgnorePropertiesResolver(new[] { "none" }) };
                var jsonRes = JsonConvert.SerializeObject(request.UserModuleDetails, jsonSettings);


                var dbParams = new DynamicParameters();
                dbParams.Add("postedData", jsonRes);

                var results = await _repositoryService.ExecuteWithReturnAsync<string>(StoredProcedures.ModuleSP.MANAGE_USER_MODULES, dbParams);

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


