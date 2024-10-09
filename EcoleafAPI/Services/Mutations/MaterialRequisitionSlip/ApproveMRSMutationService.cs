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
using DTO.MaterialRequesitionSlip;

namespace EcoleafAPI.Services.Queries.Users
{
    public class ApproveMRSMutationService
    {
        private readonly IMediator _mediator;
        public ApproveMRSMutationService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<MRSApproversDTO> ApproveMRS(Guid mrsUID,Guid userUID)
        {


            var createRes = await _mediator.Send(new ApproveMRSMutationServiceMutation(mrsUID,userUID));
            if (createRes is null)
            {
                throw new Exception("The server is temporarily down, please try again later.");
            }
            //throw new NotImplementedException();
            return createRes;
        }
      

    }
    public static class ApproveMRSMutationServiceAsyncInjection
    {
        public static IServiceCollection ApproveMRSMutationServiceAsyncApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApproveMRSMutationServiceAsyncInjection).Assembly));
            return services;
        }
    }
    public class ApproveMRSMutationServiceMutation : IRequest<MRSApproversDTO>
    {
        public string Command { get; set; }
        public Guid MrsUID { get; set; }
        public Guid UserUID { get; set; }
        public ApproveMRSMutationServiceMutation(Guid mrsUID, Guid userUID, string command = null)
        {
            MrsUID = mrsUID;
            Command = command;
            UserUID = userUID;
        }
    }

    public class ApproveMRSMutationServiceMutationHandler : IRequestHandler<ApproveMRSMutationServiceMutation, MRSApproversDTO>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly ILogger<ApproveMRSMutationServiceMutationHandler> _logger;

        public ApproveMRSMutationServiceMutationHandler(IRepositoryService repositoryService, ILogger<ApproveMRSMutationServiceMutationHandler> logger)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));

            _logger = logger;
        }

        public async Task<MRSApproversDTO> Handle(ApproveMRSMutationServiceMutation request, CancellationToken cancellationToken)
        {
           
            if (_repositoryService == null)
            {
                throw new GraphQLException("Repository service is null.");
            }

            MRSApproversDTO users = new MRSApproversDTO();
            try
            {
                //var jsonSettings = new JsonSerializerSettings()
                //{ ContractResolver = new IgnorePropertiesResolver(new[] { "RoleName" }) };
                //var jsonRes = JsonConvert.SerializeObject(request.Employee, jsonSettings);


                var dbParams = new DynamicParameters();
                dbParams.Add("userUID", request.UserUID);
                dbParams.Add("mrsUID", request.MrsUID);

                users = await _repositoryService.ExecuteWithReturnAsync<MRSApproversDTO>(StoredProcedures.MaterialRequisitionSlipSP.APPROVE_MATERIAL_REQUISITION_SLIP, dbParams);

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


