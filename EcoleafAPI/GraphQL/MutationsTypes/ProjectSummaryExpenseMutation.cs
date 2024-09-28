using Common.DTO.ProjectMonitoringManagement;
using Common.DTO.SummaryExpenses;
using Common.Helpers;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using DTO.PowerToolsInventory;
using Microsoft.EntityFrameworkCore;

namespace EcoleafAPI.GraphQL.MutationsTypes
{
    [ExtendObjectType("Mutation")]
    public class ProjectSummaryExpenseMutation
    {
        //private readonly AppDbContext _context;
        private readonly ValidateInput _validateInput;

        public ProjectSummaryExpenseMutation(AppDbContext context)


        {

        }

       
        [GraphQLName("updateProjectSummaryExpense")]
        public async Task<ProjectSummaryExpenseDTO> UpdatePersonAsync(ProjectSummaryExpenseDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {
                var projectSummaryExpense = await context.ProjectSummaryExpense.FirstOrDefaultAsync(p => p.ProjectSummaryExpenseUID == input.ProjectSummaryExpenseUID, cancellationToken);
                if (projectSummaryExpense is null)
                {
                    validateInput.AddCustomModelErrorResponseGVM("MaterialRequestUID", new List<string> { "ProjectSummaryExpense does not exists" });
                }
                else
                {
                    context.ProjectSummaryExpense.Update(input);
                    await context.SaveChangesAsync(cancellationToken);
                }



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
