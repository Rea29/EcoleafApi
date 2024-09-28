using Common.Constants;
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

    public class PowerToolsInventoryQuery
    {
        //private readonly AppDbContext _context;

        public PowerToolsInventoryQuery(AppDbContext context)
        {
            //_context = context;
        }

        //[GraphQLName("getMaterialRequisitionSlip")]
        //public IQueryable<MaterialRequisitionSlipDTO> GetMaterialRequisitionSlip([Service] AppDbContext context) =>
        //context.MaterialRequisitionSlip;
        [GraphQLName("getPowerToolsInventory")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        //public async Task<IQueryable<MaterialRequisitionSlipDTO>> GetMaterialRequisitionSlip(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext context)
        public async Task<List<PowerToolsInventoryDTO>> GetPowerToolsInventoryAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
        {
            List<PowerToolsInventoryDTO> powerToolsInventoryis = new List<PowerToolsInventoryDTO>();
            try
            {
                powerToolsInventoryis = await _context.PowerToolsInventory.ToListAsync();
                 
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
            return powerToolsInventoryis;
        }
    }
}
