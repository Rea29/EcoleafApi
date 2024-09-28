using Common.Constants;
using Common.DTO.WareHouseInventory;
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

    public class WareHouseInventoryQuery
    {
        //private readonly AppDbContext _context;

        public WareHouseInventoryQuery(AppDbContext context)
        {
            //_context = context;
        }

        //[GraphQLName("getMaterialRequisitionSlip")]
        //public IQueryable<MaterialRequisitionSlipDTO> GetMaterialRequisitionSlip([Service] AppDbContext context) =>
        //context.MaterialRequisitionSlip;
        [GraphQLName("getWareHouseInventory")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        //public async Task<IQueryable<MaterialRequisitionSlipDTO>> GetMaterialRequisitionSlip(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext context)
        public async Task<List<WareHouseInventoryDTO>> GetWareHouseInventoryAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
        {
            List<WareHouseInventoryDTO> wareHouseInventoryis = new List<WareHouseInventoryDTO>();
            try
            {
                wareHouseInventoryis = await _context.WareHouseInventory.ToListAsync();

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
            return wareHouseInventoryis;
        }
    }
}
