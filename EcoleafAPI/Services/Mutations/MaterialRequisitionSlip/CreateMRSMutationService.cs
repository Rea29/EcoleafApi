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
    public class CreateMRSMutationServiceService
    {
        private readonly IMediator _mediator;
        public CreateMRSMutationServiceService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<MaterialRequisitionSlipDTO> InsertMRS(MaterialRequisitionSlipDTO postedData,Guid userUID)
        {


            var createRes = await _mediator.Send(new CreateMRSMutationServiceMutation(postedData, userUID));
            if (createRes is null)
            {
                throw new Exception("The server is temporarily down, please try again later.");
            }
            //throw new NotImplementedException();
            return createRes;
        }
      

    }
    public static class CreateMRSMutationServiceMutationAsyncInjection
    {
        public static IServiceCollection CreateMRSMutationServiceMutationAsyncApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateMRSMutationServiceMutationAsyncInjection).Assembly));
            return services;
        }
    }
    public class CreateMRSMutationServiceMutation : IRequest<MaterialRequisitionSlipDTO>
    {
        public string Command { get; set; }
        public MaterialRequisitionSlipDTO Employee { get; set; }
        public Guid UserUID { get; set; }
        public CreateMRSMutationServiceMutation(MaterialRequisitionSlipDTO employee, Guid userUID, string command = null)
        {
            Employee = employee;
            Command = command;
            UserUID = userUID;
        }
    }

    public class CreateMRSMutationServiceMutationHandler : IRequestHandler<CreateMRSMutationServiceMutation, MaterialRequisitionSlipDTO>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly ILogger<CreateMRSMutationServiceMutationHandler> _logger;

        public CreateMRSMutationServiceMutationHandler(IRepositoryService repositoryService, ILogger<CreateMRSMutationServiceMutationHandler> logger)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));

            _logger = logger;
        }

        public async Task<MaterialRequisitionSlipDTO> Handle(CreateMRSMutationServiceMutation request, CancellationToken cancellationToken)
        {
           
            if (_repositoryService == null)
            {
                throw new GraphQLException("Repository service is null.");
            }

            MaterialRequisitionSlipDTO users = new MaterialRequisitionSlipDTO();
            try
            {
                var jsonSettings = new JsonSerializerSettings()
                { ContractResolver = new IgnorePropertiesResolver(new[] { "RoleName" }) };
                var jsonRes = JsonConvert.SerializeObject(request.Employee, jsonSettings);


                var dbParams = new DynamicParameters();
                dbParams.Add("userUID", request.UserUID);
                dbParams.Add("postedData", jsonRes);

                users = await _repositoryService.ExecuteWithReturnAsync<MaterialRequisitionSlipDTO>(StoredProcedures.MaterialRequisitionSlipSP.CREATE_MATERIAL_REQUISITION_SLIP, dbParams);

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


