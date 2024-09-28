using Common.DTO.AccountingManagementSystem;
using Common.DTO.HumanResourceManagement;
using Common.DTO.ProgressReport;
using Common.Helpers;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using DTO.PowerToolsInventory;
using Microsoft.EntityFrameworkCore;

namespace EcoleafAPI.GraphQL.MutationsTypes
{
    [ExtendObjectType("Mutation")]
    public class ProgressReportMutation
    {
        //private readonly AppDbContext _context;
        private readonly ValidateInput _validateInput;

        public ProgressReportMutation(AppDbContext context)


        {

        }

        [GraphQLName("addprogressreport")]
        public async Task<ProgressReportDTO> addprogressreport(ProgressReportDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {


                input.AccomplishReportUID = Guid.NewGuid();
                input.IsDeleted = false;
                input.IsActive = true;
                context.ProgressReport.Add(input);
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
        [GraphQLName("updateprogressreport")]
        public async Task<ProgressReportDTO> updateprogressreport(ProgressReportDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {


                input.AccomplishReportUID = Guid.NewGuid();
                input.IsDeleted = false;
                input.IsActive = true;
                context.Update(input);
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
