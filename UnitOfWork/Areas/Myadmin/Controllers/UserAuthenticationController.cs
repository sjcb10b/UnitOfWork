using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Data.Services;
using UnitOfWork.Models;

namespace UnitOfWork.Areas.Myadmin.Controllers
{
    [Area("Myadmin")]
    public class UserAuthenticationController : Controller
    {
       
        private readonly IUserAuthenticationService authenticationService;

        public UserAuthenticationController(IUserAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }





        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            // if information is not correct 
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var result = await authenticationService.LoginAsync(login);

            if (result.StatusCode == 1)
            {
                //return RedirectToAction("index", "Home");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction("Login", "UserAuthentication");
                //return RedirectToAction(nameof(Login));
            }

        }


        //[Authorize]
        public async Task<IActionResult> Logout()
        {
            await this.authenticationService.LogoutAsync();
           // return RedirectToAction(nameof(Login));
            return RedirectToAction("Login", "UserAuthentication");
        }




        //public async Task<IActionResult> RegisterAdmin()
        //{
        //    RegistrationModel model = new RegistrationModel
        //    {
        //        Username = "admingrand",
        //        Email = "jcc@jccbweb.com",
        //        FirstName = "shop",
        //        LastName = "shop",
        //        Password = "Shop12345#"
        //    };
        //    model.Role = "admin";
        //    var result = await this.authenticationService.RegisterAsync(model);
        //    return Ok(result);
        //}





    }
}
