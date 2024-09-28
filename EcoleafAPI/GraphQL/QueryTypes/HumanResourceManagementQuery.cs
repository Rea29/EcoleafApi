using Common.Constants;
using Common.DTO.HumanResourceManagement;
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

    public class HumanResourceManagementQuery
    {
        //private readonly AppDbContext _context;

        public HumanResourceManagementQuery(AppDbContext context)
        {
            //_context = context;
        }

       
        [GraphQLName("getEmployees")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        
        public async Task<List<EmployeesDTO>> getEmployeesAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
        {
            List<EmployeesDTO> humanResourceManagementLis = new List<EmployeesDTO>();
            try
            {
                humanResourceManagementLis = await _context.Employees.Where(p => p.IsDeleted == false || p.IsDeleted == null).ToListAsync();
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
            return humanResourceManagementLis;
        }
    }
}
