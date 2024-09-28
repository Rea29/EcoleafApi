using Common.DTO.AccountingManagementSystem;
using Common.DTO.HumanResourceManagement;
using Common.Helpers;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using DTO.PowerToolsInventory;
using Microsoft.EntityFrameworkCore;

namespace EcoleafAPI.GraphQL.MutationsTypes
{
    [ExtendObjectType("Mutation")]
    public class HumanResourceManagementMutation
    {
        //private readonly AppDbContext _context;
        private readonly ValidateInput _validateInput;

        public HumanResourceManagementMutation (AppDbContext context)
        {

        }
       
        [GraphQLName("addEmployee")]
        public async Task<EmployeesDTO> addEmployee(EmployeesDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();
           
            try
            {


                input.EmployeesUID = Guid.NewGuid();
                input.IsDeleted = false;
                input.IsActive = true;
                context.Employees.Add(input);
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
        [GraphQLName("updateEmployee")]
        public async Task<EmployeesDTO> updateEmployee(EmployeesDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {


                input.EmployeesUID = Guid.NewGuid();
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
        [GraphQLName("addEmployeeChildren")]
        public async Task<EmployeesDTO> addEmployeeChildren(EmployeesDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {


                input.EmployeesUID = Guid.NewGuid();
                input.IsDeleted = false;
                input.IsActive = true;
                context.Employees.Add(input);
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
