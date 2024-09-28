using Common.DTO.MaterialsInventory;
using Common.Helpers;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using DTO.PowerToolsInventory;
using Microsoft.EntityFrameworkCore;

namespace EcoleafAPI.GraphQL.MutationsTypes
{
    [ExtendObjectType("Mutation")]
    public class MaterialsInventoryMutation
    {
        //private readonly AppDbContext _context;
        private readonly ValidateInput _validateInput;

        public MaterialsInventoryMutation(AppDbContext context)


        {

        }

        [GraphQLName("addMaterialsInventory")]
        public async Task<MaterialsInventoryDTO> addMaterialsInventory(MaterialsInventoryDTO materialsInventoryDTO, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {


                materialsInventoryDTO.MaterialsInventoryUID = Guid.NewGuid();

                context.MaterialsInventory.Add(materialsInventoryDTO);
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
            return materialsInventoryDTO;
        }

    }
}
