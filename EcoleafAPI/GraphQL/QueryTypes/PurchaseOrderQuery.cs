using Common.Constants;
using Common.DTO.PersonalProtectiveEquipmentInventory;
using Common.DTO.ProjectMonitoringManagement;
using Common.DTO.PurchaseOrder;
using Common.DTO.SummaryExpenses;
using Common.Model.Global.Brands;
using Common.Model.Global.Categories;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace EcoleafAPI.GraphQL.QueryTypes
{
    [ExtendObjectType("Query")]

    public class PurchaseOrderQuery
    {
        //private readonly AppDbContext _context;

        public PurchaseOrderQuery(AppDbContext context)
        {
            //_context = context;
        }


        [GraphQLName("getPurchaseOrder")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]

        public async Task<List<PurchaseOrderDTO>> getPurchaseOrderAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
        {
            List<PurchaseOrderDTO> purchaseOrderLis = new List<PurchaseOrderDTO>();
            try
            {
                purchaseOrderLis = await _context.PurchaseOrder.Where(p => p.IsDeleted == false || p.IsDeleted == null).ToListAsync();
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
            return purchaseOrderLis;
        }
    }
}
