using Common.Constants;
using Common.DTO.PersonalProtectiveEquipmentInventory;
using Common.Model.Global.Brands;
using Common.Model.Global.Categories;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using DTO.PowerToolsInventory;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcoleafAPI.GraphQL.QueryTypes
{
    [ExtendObjectType("Query")]

    public class ProtectivePersonalEquipmentInventoryQuery
    {
        //private readonly AppDbContext _context;

        public ProtectivePersonalEquipmentInventoryQuery(AppDbContext context)
        {
            //_context = context;
        }

        //[GraphQLName("getMaterialRequisitionSlip")]
        //public IQueryable<MaterialRequisitionSlipDTO> GetMaterialRequisitionSlip([Service] AppDbContext context) =>
        //context.MaterialRequisitionSlip;
        [GraphQLName("getProtectivePersonalEquipmentInventory")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        //public async Task<IQueryable<MaterialRequisitionSlipDTO>> GetMaterialRequisitionSlip(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext context)
        public async Task<List<PersonalProtectiveEquipmentInventoryDTO>> GetProtectivePersonalEquipmentInventoryAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
        {
            List<PersonalProtectiveEquipmentInventoryDTO> protectivePersonalEquipmentInventoryis = new List<PersonalProtectiveEquipmentInventoryDTO>();
            try
            {
                protectivePersonalEquipmentInventoryis = await _context.PersonalProtectiveEquipmentInventory.ToListAsync();

            }
            catch (DbUpdateException ex)
            {
                var error = new Error(ex.Message, "500");
                throw new GraphQLException(error);
            }
            catch (Exception ex)
            {
                var error = new Error(ex.Message, "500");
                throw new GraphQLException(error);
            }
            return protectivePersonalEquipmentInventoryis;
        }
    }
}
