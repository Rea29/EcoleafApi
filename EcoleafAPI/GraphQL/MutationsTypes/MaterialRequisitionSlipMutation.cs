using Common.DTO.MaterialRequisitionSlip;
using Common.Helpers;
using Common.Model.Global.Input;
using DTO.MaterialRequesitionSlip;
using Microsoft.EntityFrameworkCore;
using System;

namespace EcoleafAPI.GraphQL.MutationsTypes
{
    [ExtendObjectType("Mutation")]
    public class MaterialRequisitionSlipMutation
    {
        //private readonly AppDbContext _context;
        private readonly ValidateInput _validateInput;

        public MaterialRequisitionSlipMutation(AppDbContext context)
        {

            //_context = context;
        }
        //public bool CheckProjectIdExists(string projectId, [Service] AppDbContext _context)
        //{
        //    var res =  _context.MaterialRequisitionSlip.Any(p => p.ProjectId == projectId);
        //    return res;
        //}
        [GraphQLName("addMaterialRequisitionSlip")]
        public async Task<MaterialRequisitionSlipDTO> addMaterialRequisitionSlip(MaterialRequisitionSlipDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();
            
            try
            {
                
                if (await context.MaterialRequisitionSlip.AnyAsync(p => p.ProjectUID == input.ProjectUID, cancellationToken))
                {
                
                }
                else
                {
                    input.MaterialRequestUID = Guid.NewGuid();
                    input.IsActive = true;
                    input.IsDeleted = false;
                    input.CreatedAt = DateTime.Now;
                    input.CreatedBy = "_System";

                    
                    foreach (var item in input.Items)
                    {
                        item.MaterialRequestItemsUID = Guid.NewGuid();
                        item.MaterialRequestUID = input.MaterialRequestUID;
                        item.IsActive = true;
                        item.IsDeleted = false;
                        item.CreatedAt = DateTime.Now;
                        item.CreatedBy = "_System";
                        context.MaterialRequestItems.Add(item);

                        await context.SaveChangesAsync(cancellationToken);

                    }
                    context.MaterialRequisitionSlip.Add(input);
                    
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
        [GraphQLName("updateMaterialRequisitionSlip")]
        public async Task<MaterialRequisitionSlipDTO> updateMaterialRequisitionSlipAsync(MaterialRequisitionSlipDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {
                var materialRequisitionSlip = await context.MaterialRequisitionSlip.FirstOrDefaultAsync(p => p.MaterialRequestUID == input.MaterialRequestUID, cancellationToken);
                if (materialRequisitionSlip is null)
                {
                    validateInput.AddCustomModelErrorResponseGVM("MaterialRequestUID", new List<string> { "MaterialRequest does not exists" });
                }
                else
                {
                    context.MaterialRequisitionSlip.Update(input);
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
