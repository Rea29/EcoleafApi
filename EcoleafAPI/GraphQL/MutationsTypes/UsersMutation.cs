using Common.DTO.Users;
using Common.Helpers;
using Common.Model.Global.Input;
using Common.Token;
using DTO.MaterialRequesitionSlip;
using Microsoft.EntityFrameworkCore;
using System;

namespace EcoleafAPI.GraphQL.MutationsTypes
{
    [ExtendObjectType("Mutation")]
    public class UsersMutation
    {
        //private readonly AppDbContext _context;
        private readonly ValidateInput _validateInput;
        private readonly IJwtAuthentication _jwt;
        private readonly PasswordSecurityProvider _passwordSecurityProvider;

        public UsersMutation(AppDbContext context, IJwtAuthentication jwt)
        {
            _jwt = jwt;
            _passwordSecurityProvider = new PasswordSecurityProvider();

            //_context = context;
        }
        //public bool CheckProjectIdExists(string projectId, [Service] AppDbContext _context)
        //{
        //    var res =  _context.MaterialRequisitionSlip.Any(p => p.ProjectId == projectId);
        //    return res;
        //}
        [GraphQLName("addUsers")]
        public async Task<UserDTO> addUsers(UserDTO user, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();
            UserDTO createdUser = new UserDTO();
            try
            {
                
                if (await context.Users.AnyAsync(x => x.Email == user.Email || x.EmployeeNumber == user.EmployeeNumber, cancellationToken))
                {
                    validateInput.AddCustomModelErrorResponseGVM("ProjectId", new List<string> { "ProjectId already exists" });
                }
                else
                {
                    user.UserUID = Guid.NewGuid();
                    user.IsActive = true;
                    user.CreatedAt = DateTime.Now;
                    var unHashedPassword = user.Password;
                    //var jwt = _jwt.GenerateJwtToken(user);
                    if (string.IsNullOrEmpty(user.Password))
                    {
                        user.Password = StringHelper.GenerateRandomString(15);
                    }
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        var hashPassword = _passwordSecurityProvider.SecurePassword(user.Password, user.Password, 200);
                        user.Password = hashPassword.HashPassword;
                    }
                    //user.IsDeleted = false;
                    context.Users.Add(user);
                    await context.SaveChangesAsync(cancellationToken);
                    createdUser = await context.Users.FirstOrDefaultAsync(x => x.UserUID == user.UserUID);
                    createdUser.NotHashPassword = unHashedPassword;
                }


                


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
            return createdUser;
        }

    }
}
