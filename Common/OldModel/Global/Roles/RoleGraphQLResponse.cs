using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Roles
{
    public class RoleGraphQLResponse
    {
        public RoleGVM GetRoleById { get; set; }
        public RoleGVM CreateRole { get; set; }
        public RoleGVM UpdateRole { get; set; }
        public GetAllModules Modules { get; set; }
        public GetAllRoles Roles { get; set; }
        public List<GraphQLError> Errors { get; set; }
    }

    //Get All Roles with Pagination
    public class GetAllRoles: PageInformation
    {
        public List<RoleGVM> Items { get; set; }
    }
    //Get All Modules with Pagination
    public class GetAllModules
    {
        public List<ModuleGVM> Items { get; set; }
    }

}
