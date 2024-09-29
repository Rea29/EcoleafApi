using Common.Constants;
using Common.DTO.Users;
using Common.Model.Global.Brands;
using Common.Model.Global.Categories;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcoleafAPI.GraphQL.QueryTypes
{
    [ExtendObjectType("Query")]

    public class UsersQuery
    {
        //private readonly AppDbContext _context;

        public UsersQuery(AppDbContext context)
        {
            //_context = context;
        }
       
        //[GraphQLName("getMaterialRequisitionSlip")]
        //public IQueryable<MaterialRequisitionSlipDTO> GetMaterialRequisitionSlip([Service] AppDbContext context) =>
        //context.MaterialRequisitionSlip;
        [GraphQLName("getUsers")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        [Authorize]
        //public async Task<IQueryable<MaterialRequisitionSlipDTO>> GetMaterialRequisitionSlip(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext context)
        public async Task<List<UserDTO>> getUsers(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
        {
            List<UserDTO> users = new List<UserDTO>();
            try
            {
                users = await _context.Users.Where(p => p.IsActive == true).ToListAsync();
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
            return users;
        }
    }
}
