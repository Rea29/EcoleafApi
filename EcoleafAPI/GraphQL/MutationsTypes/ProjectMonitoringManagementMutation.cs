using Common.DTO.AccountingManagementSystem;
using Common.DTO.ProjectMonitoringManagement;
using Common.Helpers;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using DTO.PowerToolsInventory;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcoleafAPI.GraphQL.MutationsTypes
{
    [ExtendObjectType("Mutation")]
    public class ProjectMonitoringManagementMutation
    {
        //private readonly AppDbContext _context;
        private readonly ValidateInput _validateInput;

        public ProjectMonitoringManagementMutation(AppDbContext context)


        {

        }

        [GraphQLName("addProject")]
        [Authorize]
        public async Task<ProjectsDTO> addProjectAsync(ProjectsDTO input, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {
                var userUID = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

                input.ProjectUID = Guid.NewGuid();
                input.IsActive = true;
                input.IsActive = true;
                context.Projects.Add(input);
                await context.SaveChangesAsync(cancellationToken);



            }
            catch (DbUpdateException ex)
            {
                var error = new Error(ex.ToString(), "500");
                validateInput.AddCustomModelErrorResponseGVM("ServerError", new List<string> { error.Message });

                //Console.WriteLine("Update issue: " + ex.ToString());
            }
            catch (Exception ex)
            {
                var error = new Error(ex.ToString(), "500");
                validateInput.AddCustomModelErrorResponseGVM("ServerError", new List<string> { error.Message });


            }
            validateInput.ProcessCustomModelErrorResponseGVM("error");
            return input;
        }
        [GraphQLName("addProjectMonitoringManagement")]
        public async Task<ProjectMonitoringManagementDTO> addProjectMonitoringManagement(ProjectMonitoringManagementDTO projectMonitoringManagementDTO, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {


                projectMonitoringManagementDTO.ProjectMonitoringUID = Guid.NewGuid();

                context.ProjectMonitoringManagement.Add(projectMonitoringManagementDTO);
                await context.SaveChangesAsync(cancellationToken);
                


            }
            catch (DbUpdateException ex)
            {
                var error = new Error(ex.ToString(), "500");
                validateInput.AddCustomModelErrorResponseGVM("ServerError", new List<string> { error.Message });

                //Console.WriteLine("Update issue: " + ex.ToString());
            }
            catch (Exception ex)
            {
                var error = new Error(ex.ToString() , "500");
                validateInput.AddCustomModelErrorResponseGVM("ServerError", new List<string> { error.Message });


            }
            validateInput.ProcessCustomModelErrorResponseGVM("error");
            return projectMonitoringManagementDTO;
        }
        [GraphQLName("updateProjectMonitoringManagement")]
        public async Task<ProjectMonitoringManagementDTO> updateProjectMonitoringManagement(ProjectMonitoringManagementDTO input, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();

            try
            {


                input.ProjectMonitoringUID = Guid.NewGuid();
                input.IsDeleted = false;
                input.IsActive = true;
                context.ProjectMonitoringManagement.Update(input);
                await context.SaveChangesAsync(cancellationToken);
                // liwat


            }
            catch (DbUpdateException ex)
            {
                var error = new Error(ex.Message, "500");
                validateInput.AddCustomModelErrorResponseGVM("ServerError", new List<string> { error.Message });

                //Console.WriteLine("Update issue: " + ex.ToString());
            }
            catch (Exception ex)
            {
                var error = new Error(ex.Message, "500");
                validateInput.AddCustomModelErrorResponseGVM("ServerError", new List<string> { error.Message });


            }
            validateInput.ProcessCustomModelErrorResponseGVM("error");
            return input;
        }

    }
}
