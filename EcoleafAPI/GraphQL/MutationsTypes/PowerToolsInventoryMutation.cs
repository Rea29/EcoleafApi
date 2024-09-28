using Common.Helpers;
using Common.Model.Global.Input;
using DTO.MaterialRequesitionSlip;
using DTO.PowerToolsInventory;
using Microsoft.EntityFrameworkCore;
using System;

namespace EcoleafAPI.GraphQL.MutationsTypes
{
    [ExtendObjectType("Mutation")]
    public class PowerToolsInventoryMutation
    {
        //private readonly AppDbContext _context;
        private readonly ValidateInput _validateInput;

        public PowerToolsInventoryMutation(AppDbContext context)
        {

        }
        [GraphQLName("addPowerToolsInventory")]
        public async Task<PowerToolsInventoryDTO> addPowerToolsInventory(PowerToolsInventoryDTO powerToolsInventoryDTO, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();
           
            try
            {
                powerToolsInventoryDTO.PowerToolsInventoryUID = Guid.NewGuid();
                //powerToolsInventoryDTO.IsActive = true;
                //powerToolsInventoryDTO.IsDeleted = false;
                context.PowerToolsInventory.Add(powerToolsInventoryDTO);
                await context.SaveChangesAsync(cancellationToken);



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
            return powerToolsInventoryDTO;
        }
        [GraphQLName("updatePowerToolsInventory")]
        public async Task<PowerToolsInventoryDTO> UpdatePersonAsync(PowerToolsInventoryDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {
                var PowerToolsInventory = await context.PowerToolsInventory.FirstOrDefaultAsync(p => p.PowerToolsInventoryUID == input.PowerToolsInventoryUID, cancellationToken);
                if (PowerToolsInventory is null)
                {
                    validateInput.AddCustomModelErrorResponseGVM("PowerToolsInventoryUID", new List<string> { "ProjectCode does not exists" });
                }
                else
                {
                    context.PowerToolsInventory.Update(input);
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
