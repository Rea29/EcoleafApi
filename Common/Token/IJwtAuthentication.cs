using Common.DTO.HumanResourceManagement;
using Common.DTO.Users;
using Common.Model.Global.Users;
using Common.Model.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Token
{
    public interface IJwtAuthentication
    {
        //string username, string id, string role, 
        JwtDTO GenerateJwtToken(UserDTO user);
    }
}
