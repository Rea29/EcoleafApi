using Common.Constants;
using Common.DTO.MaterialRequisitionSlip;
using Common.Model.Global.Brands;
using Common.Model.Global.Categories;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcoleafAPI.GraphQL.QueryTypes
{
    [ExtendObjectType("Query")]

    public class MaterialRequisitionSlipQuery
    {
        //private readonly AppDbContext _context;

        public MaterialRequisitionSlipQuery(AppDbContext context)
        {
            //_context = context;
        }
       
        //[GraphQLName("getMaterialRequisitionSlip")]
        //public IQueryable<MaterialRequisitionSlipDTO> GetMaterialRequisitionSlip([Service] AppDbContext context) =>
        //context.MaterialRequisitionSlip;
        [GraphQLName("getMaterialRequisitionSlip")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        //public async Task<IQueryable<MaterialRequisitionSlipDTO>> GetMaterialRequisitionSlip(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext context)
        public async Task<List<MaterialRequisitionSlipDTO>> GetMaterialRequisitionSlipAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
        {
            List<MaterialRequisitionSlipDTO> materialRequisitionSlipLis = new List<MaterialRequisitionSlipDTO>();
            try
            {
                var result = await _context.MaterialRequisitionSlip.Where(p => p.IsDeleted == false || p.IsDeleted == null).ToListAsync();
                foreach (var request in result)
                {
                    request.Items = await _context.MaterialRequestItems.Where(p => (p.IsDeleted == false || p.IsDeleted == null) && p.MaterialRequestUID == request.MaterialRequestUID).ToListAsync();
                    materialRequisitionSlipLis.Add(request);
                }



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
            return materialRequisitionSlipLis;
        }
    }
}
