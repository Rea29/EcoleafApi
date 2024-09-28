using Common.DTO.AccountingManagementSystem;
using Common.DTO.HumanResourceManagement;
using Common.DTO.SummaryExpenses;
using Common.Helpers;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using DTO.PowerToolsInventory;
using Microsoft.EntityFrameworkCore;

namespace EcoleafAPI.GraphQL.MutationsTypes
{
    [ExtendObjectType("Mutation")]
    public class AccountingManagementSystemMutation
    {
        //private readonly AppDbContext _context;
        private readonly ValidateInput _validateInput;

        public AccountingManagementSystemMutation(AppDbContext context)
        {

        }

        [GraphQLName("addAccountingManagementSystem")]
        public async Task<AccountingManagementSystemDTO> addAccountingManagementSystem(AccountingManagementSystemDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {


                input.AccountingManagementSystemUID = Guid.NewGuid();
                input.IsDeleted = false;
                input.IsActive = true;
                context.AccountingManagementSystem.Add(input);
                await context.SaveChangesAsync(cancellationToken);
                // liwat


            }
            catch (DbUpdateException ex)
            {
                var error = new Error(ex.Message, "500");
                validateInput.AddCustomModelErrorResponseGVM("ServerError", new List<string> { error.Message });

                //Console.WriteLine("Update issue: " + ex.ToString());
            }
            catch (Exception ex)
            {
                var error = new Error(ex.Message, "500");
                validateInput.AddCustomModelErrorResponseGVM("ServerError", new List<string> { error.Message });


            }
            validateInput.ProcessCustomModelErrorResponseGVM("error");
            return input;
        }

        [GraphQLName("updateAccountingManagementSystem")]
        public async Task<AccountingManagementSystemDTO> updateAccountingManagementSystem(AccountingManagementSystemDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {


                //input.AccountingManagementSystemUID = Guid.NewGuid();
                input.IsDeleted = false;
                input.IsActive = true;
                context.AccountingManagementSystem.Update(input);
                await context.SaveChangesAsync(cancellationToken);
                // liwat


            }
            catch (DbUpdateException ex)
            {
                var error = new Error(ex.Message, "500");
                validateInput.AddCustomModelErrorResponseGVM("ServerError", new List<string> { error.Message });

                //Console.WriteLine("Update issue: " + ex.ToString());
            }
            catch (Exception ex)
            {
                var error = new Error(ex.Message, "500");
                validateInput.AddCustomModelErrorResponseGVM("ServerError", new List<string> { error.Message });


            }
            validateInput.ProcessCustomModelErrorResponseGVM("error");
            return input;
        }

    }
}
