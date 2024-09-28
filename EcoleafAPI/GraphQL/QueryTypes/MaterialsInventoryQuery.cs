using Common.Constants;
using Common.DTO.MaterialsInventory;
using Common.Model.Global.Brands;
using Common.Model.Global.Categories;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace EcoleafAPI.GraphQL.QueryTypes
{
    [ExtendObjectType("Query")]

    public class MaterialsInventoryQuery
    {
        //private readonly AppDbContext _context;

        public MaterialsInventoryQuery(AppDbContext context)
        {
            //_context = context;
        }

        //[GraphQLName("getMaterialRequisitionSlip")]
        //public IQueryable<MaterialRequisitionSlipDTO> GetMaterialRequisitionSlip([Service] AppDbContext context) =>
        //context.MaterialRequisitionSlip;
        [GraphQLName("getMaterialsInventory")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        //public async Task<IQueryable<MaterialRequisitionSlipDTO>> GetMaterialRequisitionSlip(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext context)
        public async Task<List<MaterialsInventoryDTO>> GetgetMaterialsInventoryAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
        {
            List<MaterialsInventoryDTO> getMaterialsInventoryLis = new List<MaterialsInventoryDTO>();
            try
            {
                getMaterialsInventoryLis = await _context.MaterialsInventory.Where(p => p.IsDeleted == false || p.IsDeleted == null).ToListAsync();
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
            return getMaterialsInventoryLis;

            //materialRequisitionSlipLis
        }
    }
}
