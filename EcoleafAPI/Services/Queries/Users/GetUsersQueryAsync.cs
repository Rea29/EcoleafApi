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
    public class GetUsersQueryService
    {
        private readonly IMediator _mediator;
        public GetUsersQueryService(IMediator mediator)
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
        public async Task<UserDTO> GetUsersByUserUIDQueryAsync(UserDTO user)
        {

            var resultMediator = await _mediator.Send(new GetUsersQuery(user, "useruid"));
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
    public static class GetUsersQueryAsyncInjection
    {
        public static IServiceCollection GetUsersQueryAsyncApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUsersQueryAsyncInjection).Assembly));
            return services;
        }
    }
    public class GetUsersQuery : IRequest<List<UserDTO>>
    {
        public string Command { get; set; }
        public UserDTO User { get; set; }
        public GetUsersQuery(UserDTO user = null, string command = null)
        {
            User = user;
            Command = command;
        }
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDTO>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly ILogger<GetUsersQueryHandler> _logger;

        public GetUsersQueryHandler(IRepositoryService repositoryService, ILogger<GetUsersQueryHandler> logger)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));

            _logger = logger;
        }

        public async Task<List<UserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching users from the repository.");

            if (_repositoryService == null)
            {
                _logger.LogError("Repository service is null.");
                throw new GraphQLException("Repository service is null.");
            }

            List<UserDTO> users = new List<UserDTO>();
            try
            {
                var jsonSettings = new JsonSerializerSettings()
                { ContractResolver = new IgnorePropertiesResolver(new[] { "none" }) };
                var jsonRes = JsonConvert.SerializeObject(request.User, jsonSettings);


                var dbParams = new DynamicParameters();
                dbParams.Add("command", request.Command);
                dbParams.Add("postedData", jsonRes);

                users = await _repositoryService.GetJsonPathAsyncV2<List<UserDTO>>(StoredProcedures.UserSP.GET_ALL_USERS, dbParams);

                if (users == null)
                {
                    _logger.LogWarning("No users found from the stored procedure.");
                    throw new GraphQLException("Looks like we couldn’t find that email address");
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


