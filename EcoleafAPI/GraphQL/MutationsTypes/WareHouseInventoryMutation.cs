using Common.DTO.AccountingManagementSystem;
using Common.DTO.WareHouseInventory;
using Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace EcoleafAPI.GraphQL.MutationsTypes
{
    public class WareHouseInventoryMutation
    {
        //private readonly AppDbContext _context;
        private readonly ValidateInput _validateInput;

        public WareHouseInventoryMutation(AppDbContext context)


        {

        }

        [GraphQLName("addWareHouseInventory")]
        public async Task<WareHouseInventoryDTO> addWareHouseInventory(WareHouseInventoryDTO wareHouseInventoryDTO, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {


                wareHouseInventoryDTO.WareHouseInventoryUID = Guid.NewGuid();
                wareHouseInventoryDTO.IsDeleted = false;
                wareHouseInventoryDTO.IsActive = true;
                context.WareHouseInventory.Add(wareHouseInventoryDTO);
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
            return wareHouseInventoryDTO;
        }

        [GraphQLName("updateWareHouseInventory")]
        public async Task<WareHouseInventoryDTO> updateWareHouseInventory(WareHouseInventoryDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {


                //input.AccountingManagementSystemUID = Guid.NewGuid();
                input.IsDeleted = false;
                input.IsActive = true;
                context.WareHouseInventory.Update(input);
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
