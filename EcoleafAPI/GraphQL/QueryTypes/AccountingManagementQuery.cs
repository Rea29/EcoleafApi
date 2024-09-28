using Common.Constants;
using Common.DTO.AccountingManagementSystem;
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

    public class AccountingManagementQuery
    {
        //private readonly AppDbContext _context;

        public AccountingManagementQuery(AppDbContext context)
        {
            //_context = context;
        }


        [GraphQLName("getAccountingManagementSystem")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]

        public async Task<List<AccountingManagementSystemDTO>> getAccountingManagementSystemAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
        {
            List<AccountingManagementSystemDTO> accountingManagementSystemLis = new List<AccountingManagementSystemDTO>();
            try
            {
                accountingManagementSystemLis = await _context.AccountingManagementSystem.Where(p => p.IsDeleted == false || p.IsDeleted == null).ToListAsync();
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
            return accountingManagementSystemLis;
        }
    }
}
