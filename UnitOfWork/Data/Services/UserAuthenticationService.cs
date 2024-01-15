using UnitOfWork.Models;
using UnitOfWork.Data.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace UnitOfWork.Data.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;


        public UserAuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<Status> RegisterAsync(RegistrationModel model)
        {
            Status status = new Status();
            var vuser = await userManager.FindByNameAsync(model.Username);
            if (vuser != null)
            {
                status.StatusCode = 0;
                status.Message = "User Already exist";
                return status;
            }
            ApplicationUser user = new ApplicationUser
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "Something went wrong ";
                return status;
            }

            if (!await roleManager.RoleExistsAsync(model.Role))
                await roleManager.CreateAsync(new IdentityRole(model.Role));


            if (await roleManager.RoleExistsAsync(model.Role))
            {
                await userManager.AddToRoleAsync(user, model.Role);
            }



            status.StatusCode = 1;
            status.Message = "User Created Succesfully";
            return status;
        }


        public async Task<Status> ChangePasswordAsync(ChangePasswordModel model, string username)
        {
            Status status = new Status();
            // first find if the user exist 
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                status.StatusCode = 0;
                status.Message = " User not found";
                return status;
            }

            var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (result.Succeeded)
            {
                status.Message = "Password changed Successfully";
                status.StatusCode = 1;
                return status;
            }
            else
            {
                status.Message = "Something went wrong";
                status.StatusCode = 0;
            }
            return status;
        }



        public async Task<Status> LoginAsync(LoginModel model)
        {
            Status status = new Status();
            // verify username
            var userv = await userManager.FindByNameAsync(model.Username);

            if (userv == null)
            {
                status.StatusCode = 0;
                status.Message = "Verify Credentials :: User not found";
                return status;
            }

            var vpass = await userManager.CheckPasswordAsync(userv, model.Password);
            if (vpass == null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid Password";
                return status;
            }

            var signInResult = await signInManager.PasswordSignInAsync(userv, model.Password, false, true);
            if (signInResult.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(userv);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userv.UserName),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                status.StatusCode = 1;
                status.Message = "Logged in successfully";
            }
            else if (signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.Message = "User is locked out";
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Error on logging in";
            }

            return status;

        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

    }
}
