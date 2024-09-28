using Common.Model.Global.Merchants;
using Common.Model.Global.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Users
{
    public class UserGraphQLResponse
    {
        public UserGVM GetUserById { get; set; }
        public UserGVM CreateUser { get; set; }
        public UserGVM UserProfile { get; set; }
        public UserGVM UpdateUser { get; set; }
        public GetAllModules Modules { get; set; }
        public List<UserGVM> Users { get; set; }
        public GetAllRoles Roles { get; set; }
        public GetAllRoles MtRoles { get; set; }
        public GetAllMerchants Merchants { get; set; }
        public GetAllMerchants MtMerchants { get; set; }
        public LoginGVM Login { get; set; }
        public LogoutResponseGVM Logout { get; set; }
		public List<GraphQLError> Errors { get; set; }
	}

    public class GetAllMerchants
    {
        public List<MerchantGVM> Items { get; set; }
    }
}
