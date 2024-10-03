using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Common.DTO.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using EcoleafAPI.Services.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using HotChocolate.Authorization;
using Common.Model.Global.Input;
using EcoleafAPI.Services.Queries.Users;

namespace EcoleafAPI.GraphQL.QueryTypes
{
    [ExtendObjectType("Query")]
    public class ModulesQuery
    {
        private readonly IMediator _mediator;

        public ModulesQuery(IMediator mediator)
        {
            _mediator = mediator;
        }

        [GraphQLName("getModules")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        [Authorize]
        public async Task<List<ModulesDTO>> GetModulesAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] GetModulesQueryAsync getModulesQueryAsync)
        {
            List<ModulesDTO> modules = new List<ModulesDTO>();
            try
            {

                //var nameIdentifier = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                //UserDTO userDTO = new UserDTO();
                //userDTO.UserUID = new Guid(nameIdentifier);
                // Call the mediator to send the query
                modules = await getModulesQueryAsync.GetAllModulesQueryAsync();
            }
            catch (GraphQLException ex)
            {
                var error = new Error(ex.Message, "500");
                throw new GraphQLException(error);
            }
            catch (System.Exception ex)
            {
                var error = new Error(ex.Message, "500");
                throw new GraphQLException(error);
            }
            return modules;
        }

        [GraphQLName("getModulesByUserUID")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        //[Authorize]
        public async Task<List<ModulesDTO>> GetModulesByUserUIDAsync(Guid input,HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] GetModulesQueryAsync getModulesQueryAsync)
        {
            List<ModulesDTO> modules = new List<ModulesDTO>();
            try
            {

                //var nameIdentifier = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
               
                //UserDTO userDTO = new UserDTO();
                //userDTO.UserUID = new Guid(nameIdentifier);
                // Call the mediator to send the query
                modules = await getModulesQueryAsync.GetAllModulesByUserUIDQueryAsync(input);
            }
            catch (GraphQLException ex)
            {
                var error = new Error(ex.Message, "500");
                throw new GraphQLException(error);
            }
            catch (System.Exception ex)
            {
                var error = new Error(ex.Message, "500");
                throw new GraphQLException(error);
            }
            return modules;
        }


    }
}
