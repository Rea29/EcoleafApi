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
using EcoleafAPI.Services.Queries.Users;

namespace EcoleafAPI.Services.Queries.Users
{
    public class GetModulesQueryAsync
    {
        private readonly IMediator _mediator;
        public GetModulesQueryAsync(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<List<ModulesDTO>> GetAllModulesQueryAsync()
        {

            var result = await _mediator.Send(new GetModulesQuery());


            return result;
            //throw new NotImplementedException();
        }
        public async Task<List<ModulesDTO>> GetAllModulesByUserUIDQueryAsync(Guid UserUID)
        {

            var result = await _mediator.Send(new GetModulesQuery(null, "useruid", UserUID));


            return result;
            //throw new NotImplementedException();
        }
        public async Task<UserDTO> GetUsersByEmailQueryAsync(UserDTO user)
        {

            var resultMediator = await _mediator.Send(new GetUsersQuery(user, "email"));
            var result = new UserDTO();
            foreach (UserDTO i in resultMediator)
            {
                result = i;
            }
            if (result is null)
            {
                result = new UserDTO();
            }

            return result;
            //throw new NotImplementedException();
        }


    }
    public static class GetModulesQueryAsyncInjection
    {
        public static IServiceCollection GetModulesQueryAsyncApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetModulesQueryAsyncInjection).Assembly));
            return services;
        }
    }
    public class GetModulesQuery : IRequest<List<ModulesDTO>>
    {
        public string Command { get; set; }
        public UserDTO User { get; set; }
        public Guid UserUID { get; set; }
        public GetModulesQuery(UserDTO user = null, string command = null, Guid userUID = default)
        {
            User = user;
            Command = command;
            UserUID = userUID;
        }
    }

    public class GetModulesQueryHandler : IRequestHandler<GetModulesQuery, List<ModulesDTO>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly ILogger<GetModulesQueryHandler> _logger;

        public GetModulesQueryHandler(IRepositoryService repositoryService, ILogger<GetModulesQueryHandler> logger)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));

            _logger = logger;
        }

        public async Task<List<ModulesDTO>> Handle(GetModulesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching users from the repository.");

            if (_repositoryService == null)
            {
                _logger.LogError("Repository service is null.");
                throw new GraphQLException("Repository service is null.");
            }

            List<ModulesDTO> users = new List<ModulesDTO>();
            try
            {
                var jsonSettings = new JsonSerializerSettings()
                { ContractResolver = new IgnorePropertiesResolver(new[] { "none" }) };
                var jsonRes = JsonConvert.SerializeObject(request.User, jsonSettings);


                var dbParams = new DynamicParameters();
                dbParams.Add("command", request.Command);
                dbParams.Add("postedData", jsonRes);
                dbParams.Add("userUID", request.UserUID);

                users = await _repositoryService.GetJsonPathAsyncV2<List<ModulesDTO>>(StoredProcedures.ModuleSP.GET_ALL_MODULES, dbParams);

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


