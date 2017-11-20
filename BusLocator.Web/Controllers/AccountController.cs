using BusLocator.Persistence.BusinessObjects;
using BusLocator.Services.Managers;
using BusLocator.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BusLocator.Web.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IWindsor windsor)
            : base(windsor)
        {
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserBO user = await UserManager.FindByNameAsync(model.Email);
                    if (user == null || user.Audit.RecordStateType == Domain.Enum.RecordStateType.InActive)
                        return View();
                   
                    var signinResult = await SignInManager.PasswordSignInAsync(model.Email, model.Password, true, shouldLockout: true);

                    var roles = UserManager.GetRoles(user.Id);

                    if(signinResult == SignInStatus.Success)
                    {
                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (roles.Contains("Driver"))
                        {
                            return RedirectToAction("Driver", "StartTrip");
                        }
                        else
                        {
                            return RedirectToAction("", "");
                        }
                    }
                    if (signinResult == SignInStatus.Failure)
                    {
                        return View();
                    }
                    if (signinResult == SignInStatus.LockedOut)
                    {
                        return View();
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}