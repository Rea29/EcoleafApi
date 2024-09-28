using Common.Constants;
using Common.DTO.ProjectMonitoringManagement;
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

    public class ProjectSummaryExpenseQuery
    {
        //private readonly AppDbContext _context;

        public ProjectSummaryExpenseQuery(AppDbContext context)
        {
            //_context = context;
        }


        [GraphQLName("getProjectSummaryExpense")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]

        public async Task<List<ProjectSummaryExpenseDTO>> getProjectSummaryExpenseAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
        {
            List<ProjectSummaryExpenseDTO> projectSummaryExpenseLis = new List<ProjectSummaryExpenseDTO>();
            try
            {
                projectSummaryExpenseLis = await _context.ProjectSummaryExpense.Where(p => p.IsDeleted == false || p.IsDeleted == null).ToListAsync();
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
            return projectSummaryExpenseLis;
        }
    }
}
