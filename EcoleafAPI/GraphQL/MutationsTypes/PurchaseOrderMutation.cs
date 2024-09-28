using Common.DTO.HumanResourceManagement;
using Common.DTO.ProjectMonitoringManagement;
using Common.DTO.PurchaseOrder;
using Common.Helpers;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using DTO.PowerToolsInventory;
using Microsoft.EntityFrameworkCore;

namespace EcoleafAPI.GraphQL.MutationsTypes
{
    [ExtendObjectType("Mutation")]
    public class PurchaseOrderMutation
    {
        //private readonly AppDbContext _context;
        private readonly ValidateInput _validateInput;

        public PurchaseOrderMutation(AppDbContext context)


        {

        }

        [GraphQLName("addPurchaseOrder")]
        public async Task<PurchaseOrderDTO> addPurchaseOrder(PurchaseOrderDTO purchaseOrderDTO, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {


                purchaseOrderDTO.PurchaseOrderUID = Guid.NewGuid();

                context.PurchaseOrder.Add(purchaseOrderDTO);
                await context.SaveChangesAsync(cancellationToken);



            }
            catch (DbUpdateException ex)
            {
                var error = new Error(ex.ToString(), "500");
                validateInput.AddCustomModelErrorResponseGVM("ServerError", new List<string> { error.Message });

                //Console.WriteLine("Update issue: " + ex.ToString());
            }
            catch (Exception ex)
            {
                var error = new Error(ex.ToString(), "500");
                validateInput.AddCustomModelErrorResponseGVM("ServerError", new List<string> { error.Message });


            }
            validateInput.ProcessCustomModelErrorResponseGVM("error");
            return purchaseOrderDTO;
        }
        [GraphQLName("updatePurchaseOrder")]
        public async Task<PurchaseOrderDTO> updatePurchaseOrder(PurchaseOrderDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {


                input.PurchaseOrderUID = Guid.NewGuid();
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
