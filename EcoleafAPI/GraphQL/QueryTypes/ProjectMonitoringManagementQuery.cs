using Common.Constants;
using Common.DTO.ProjectMonitoringManagement;
using Common.Helpers;
using Common.Model.Global.Brands;
using Common.Model.Global.Categories;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using EcoleafAPI.Services.Queries.Users;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace EcoleafAPI.GraphQL.QueryTypes
{
    [ExtendObjectType("Query")]

    public class ProjectMonitoringManagementQuery
    {
        //private readonly AppDbContext _context;
        public ProjectMonitoringManagementQuery(AppDbContext context)
        {
            //_context = context;
        }

        [GraphQLName("getProjectsAndMaterialRequisitionSlipProjectUID")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        [Authorize]

        public async Task<List<ProjectsDTO>> getProjectsAndMaterialRequisitionSlipAsync(Guid input,HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] GetProjectAndMaterialRequisitionSlipsQueryService getProjectAndMaterialRequisitionSlipsQueryAsync)
        {
            List<ProjectsDTO> projects = new List<ProjectsDTO>();
            try
            {
                //projects = await _context.Projects.Where(p => p.IsDeleted == false || p.IsDeleted == null).ToListAsync();
                var nameIdentifier = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Guid userUID = new Guid(nameIdentifier);
                ProjectsDTO projectsDTO = new ProjectsDTO();
                //projects = ConvertListModelValueToLowerHelper.Convert(projects);
                projectsDTO.ProjectUID = input;
                projects = await getProjectAndMaterialRequisitionSlipsQueryAsync.GetProjectAndMaterialRequisitionSlipsByProjectUIDQueryAsync(userUID, projectsDTO);

                //projects = await _context.ToLowerCase(_context.Projects.Where(p => p.IsDeleted == false || p.IsDeleted == null)).ToListAsync();
                //var results = _context.ToLowerCase(context.YourModels).ToList();
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


        [GraphQLName("getProjectsAndMaterialRequisitionSlip")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        [Authorize]

        public async Task<List<ProjectsDTO>> getProjectsAndMaterialRequisitionSlipAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] GetProjectAndMaterialRequisitionSlipsQueryService getProjectAndMaterialRequisitionSlipsQueryAsync)
        {
            List<ProjectsDTO> projects = new List<ProjectsDTO>();
            try
            {
                //projects = await _context.Projects.Where(p => p.IsDeleted == false || p.IsDeleted == null).ToListAsync();
                var nameIdentifier = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Guid userUID = new Guid(nameIdentifier);
                //projects = ConvertListModelValueToLowerHelper.Convert(projects);
                projects = await getProjectAndMaterialRequisitionSlipsQueryAsync.GetProjectAndMaterialRequisitionSlipsByUserUIDQueryAsync(userUID, new ProjectsDTO());

                //projects = await _context.ToLowerCase(_context.Projects.Where(p => p.IsDeleted == false || p.IsDeleted == null)).ToListAsync();
                //var results = _context.ToLowerCase(context.YourModels).ToList();
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

        [GraphQLName("getProjectMonitoringManagement")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]

        public async Task<List<ProjectMonitoringManagementDTO>> getProjectMonitoringManagementAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
        {
            List<ProjectMonitoringManagementDTO> projectMonitoringManagementLis = new List<ProjectMonitoringManagementDTO>();
            try
            {
                projectMonitoringManagementLis = await _context.ProjectMonitoringManagement.Where(p => p.IsDeleted == false || p.IsDeleted == null).ToListAsync();
               
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
            return projectMonitoringManagementLis;
        }


        [GraphQLName("getProjects")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]

        public async Task<List<ProjectsDTO>> getProjectsAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
        {
            List<ProjectsDTO> projects = new List<ProjectsDTO>();
            try
            {
                projects = await _context.Projects.Where(p => p.IsDeleted == false || p.IsDeleted == null).ToListAsync();

                projects = ConvertListModelValueToLowerHelper.Convert(projects);
                //projects = await _context.ToLowerCase(_context.Projects.Where(p => p.IsDeleted == false || p.IsDeleted == null)).ToListAsync();
                //var results = _context.ToLowerCase(context.YourModels).ToList();
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
