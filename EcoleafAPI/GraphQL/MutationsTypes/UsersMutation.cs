using Common.Constants;
using Common.DTO;
using Common.DTO.Users;
using Common.Helpers;
using Common.Model.Global;
using Common.Model.Global.Input;
using Common.Model.Global.Users;
using Common.Token;
using DTO.MaterialRequesitionSlip;
using EcoleafAPI.Services.Queries.Users;
using GreenDonut;
using HotChocolate.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading;
using static HotChocolate.ErrorCodes;

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
        [GraphQLName("login")]
        [AllowAnonymous]
        public async Task<LoginGVM> LoginAsync(LoginGVM input, HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context, [Service] GetUsersQueryService getUsersQueryService)
        {
            var result = new LoginGVM { Email = input.Email, Password = input.Password };
            var validateInput = new ValidateInput();
            var customValidate = new List<CutomModelErrorResponseGVM>();

            try
            {
                // Find user by email
                UserDTO userDTO = new UserDTO();
                userDTO.Email = input.Email;
                var getUserDetail = await getUsersQueryService.GetUsersByEmailQueryAsync(userDTO);
                //var getUserDetail = await _context.Users
                //    .Where(p => p.Email == input.Email && (p.IsActive == true || p.IsActive == null))
                //    .FirstOrDefaultAsync();

                // Handle case where user is not found
                if (getUserDetail is null)
                {
                    validateInput.AddCustomModelErrorResponseGVM("email", new List<string> { "Looks like we couldn’t find that email address" });
                    validateInput.ProcessCustomModelErrorResponseGVM("error");
                }

                // Check for login attempts
                DateTime philippinesTimeToday = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time"));
                if (getUserDetail.LastLoginAttemptAt <= philippinesTimeToday && getUserDetail.LoginAttempt >= 3)
                {
                    getUserDetail.LoginAttempt = 0;
                    getUserDetail.LastLoginAttemptAt = null;
                    _context.Update(getUserDetail);
                    await _context.SaveChangesAsync();
                }

                // Hash and validate password
                if (!string.IsNullOrEmpty(input.Password))
                {
                    var isValidPassword = _passwordSecurityProvider.IsValidPassword(getUserDetail.Password, input.Password, input.Password);
                    if (!isValidPassword)
                    {
                        getUserDetail.LoginAttempt += 1;
                        _context.Update(getUserDetail);
                        await _context.SaveChangesAsync();

                        if (getUserDetail.LoginAttempt >= 3)
                        {
                            validateInput.AddCustomModelErrorResponseGVM("message", new List<string> { "You have reached your maximum login attempts. Try again after 24 hours." });
                            validateInput.ProcessCustomModelErrorResponseGVM("error");
                        }
                        else
                        {
                            int? attemptsLeft = (3 - getUserDetail.LoginAttempt);
                            validateInput.AddCustomModelErrorResponseGVM("message", new List<string> { $"You have {attemptsLeft} more attempts." });
                            validateInput.ProcessCustomModelErrorResponseGVM("error");
                        }
                    }
                }

                // Reset login attempts on successful login
                getUserDetail.LoginAttempt = 0;
                getUserDetail.LastLoginAttemptAt = null;
                _context.Users.Update(getUserDetail);
                await _context.SaveChangesAsync();

                // Generate JWT token
                var jwt = _jwt.GenerateJwtToken(getUserDetail);
                result.Token = jwt.Token;

                // Store token in the database
                UserTokenDTO userToken = new UserTokenDTO
                {
                    UserUID = getUserDetail.UserUID,
                    JwtToken = jwt.Token,
                    Islogin = true,
                    ExpiredAt = DateTime.Now.AddDays(1),
                    IdleAt = DateTime.Now.AddMinutes(15),
                    CreatedAt = DateTime.Now
                };

                _context.UserToken.Add(userToken);
                await _context.SaveChangesAsync();
                getUserDetail.Password = "n/a";


            }
            catch (DbUpdateException ex)
            {
                validateInput.AddCustomModelErrorResponseGVM("ServerError", new List<string> { "Database update error." });
            }
            catch (GraphQLException ex)
            {
                validateInput.AddCustomModelErrorResponseGVM("LoginError", new List<string> { ex.Message });

            }
            catch (Exception ex)
            {
                validateInput.AddCustomModelErrorResponseGVM("ServerError", new List<string> { "An error occurred during login." });
            }
           

            // Return any validation errors if they exist
            validateInput.ProcessCustomModelErrorResponseGVM("error");

            return result;
        }

        [GraphQLName("addUsers")]
        
        public async Task<UserDTO> addUsers(UserDTO user, [Service] AppDbContext context, CancellationToken cancellationToken)
        {
            var validateInput = new ValidateInput();
            UserDTO createdUser = new UserDTO();
            try
            {
                
                if (await context.Users.AnyAsync(x => x.Email == user.Email, cancellationToken))
                {
                    validateInput.AddCustomModelErrorResponseGVM("Email", new List<string> { "Email already exists" });
                }
             
                else
                {
                    user.UserUID = Guid.NewGuid();
                    user.IsActive = true;
                    user.CreatedAt = DateTime.Now;
                    user.CreatedBy = "_System";
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


        [GraphQLName("manageUserModules")]
        [Authorize]
        public async Task<UserModuleDetailsDTO> manageUserModules(UserModuleDetailsDTO input, [Service] AppDbContext context,[Service] UserModuleMutationService userModuleMutationService)
        {
            var validateInput = new ValidateInput();
            UserModuleDetailsDTO res = new UserModuleDetailsDTO();
            try
            {

                res = await userModuleMutationService.ManageUserModule(input);


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
            return res;
        }

    }
}
