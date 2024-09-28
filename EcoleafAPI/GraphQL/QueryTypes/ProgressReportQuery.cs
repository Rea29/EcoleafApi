using Common.DTO.ProgressReport;
using Common.DTO.ProjectMonitoringManagement;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcoleafAPI.GraphQL.QueryTypes
{
    public class ProgressReportQuery
    {
       
            public ProgressReportQuery(AppDbContext context)
            {
                //_context = context;
            }


            [GraphQLName("getProgressReport")]
            [UseOffsetPaging]
            [UseFiltering]
            [UseSorting]

            public async Task<List<ProgressReportDTO>> getProgressReportAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
            {
                List<ProgressReportDTO> progressReportLis = new List<ProgressReportDTO>();
                try
                {
                progressReportLis = await _context.ProgressReport.Where(p => p.IsDeleted == false || p.IsDeleted == null).ToListAsync();
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
                return progressReportLis;
            }


            [GraphQLName("getProgressReport")]
            [UseOffsetPaging]
            [UseFiltering]
            [UseSorting]

            public async Task<List<ProgressReportDTO>> getProgressReportsAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
            {
                List<ProgressReportDTO> projects = new List<ProgressReportDTO>();
                try
                {
                    projects = await _context.ProgressReport.Where(p => p.IsDeleted == false || p.IsDeleted == null).ToListAsync();
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
                return projects;
            }
        }
}
