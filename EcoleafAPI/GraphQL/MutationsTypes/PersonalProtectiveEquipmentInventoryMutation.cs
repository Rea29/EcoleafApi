using Common.DTO.AccountingManagementSystem;
using Common.DTO.PersonalProtectiveEquipmentInventory;
using Common.Helpers;
using Microsoft.EntityFrameworkCore;
using System;

namespace EcoleafAPI.GraphQL.MutationsTypes
{
    [ExtendObjectType("Mutation")]
    public class PersonalProtectiveEquipmentInventoryMutation
    {
        //private readonly AppDbContext _context;
        private readonly ValidateInput _validateInput;

        public PersonalProtectiveEquipmentInventoryMutation (AppDbContext context)
        {

        }
        [GraphQLName("addPersonalProtectiveEquipmentInventory")]
        public async Task<PersonalProtectiveEquipmentInventoryDTO> addPersonalProtectiveEquipmentInventory(PersonalProtectiveEquipmentInventoryDTO personalProtectiveEquipmentInventoryDTO, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();
           
            try { 


                personalProtectiveEquipmentInventoryDTO.PersonalProtectiveEquipmentInventoryUID = Guid.NewGuid();
                context.PersonalProtectiveEquipmentInventory.Add(personalProtectiveEquipmentInventoryDTO);
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
            return personalProtectiveEquipmentInventoryDTO;
        }
        [GraphQLName("updatePersonalProtectiveEquipmentInventory")]
        public async Task<PersonalProtectiveEquipmentInventoryDTO> updatePersonalProtectiveEquipmentInventory(PersonalProtectiveEquipmentInventoryDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {


                //input.PersonalProtectiveEquipmentInventoryUID = Guid.NewGuid();
                //input.IsDeleted = false;
                //input.IsActive = true;
                var x = input.PersonalProtectiveEquipmentInventoryUID;
                context.PersonalProtectiveEquipmentInventory.Attach(input);
                context.Entry(input).State = EntityState.Modified;
                context.Entry(input).Property(e => e.LineId).IsModified = false;
                // Save the changes
                await context.SaveChangesAsync();
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
