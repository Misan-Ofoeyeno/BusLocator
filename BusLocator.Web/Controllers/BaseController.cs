using BusLocator.Persistence.IdentityServices.Managers;
using BusLocator.Services.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusLocator.Web.Controllers
{
    public class BaseController : Controller
    {
        private BusLocatorSignInManager _signInManager;
        private BusLocatorUserManager _userManager;
        private BusLocatorRoleManager _roleManager;
        public IWindsor windsor;

        public BaseController(IWindsor windsor)
        {
            this.windsor = windsor;
        }

        public BaseController(BusLocatorUserManager userManager, BusLocatorSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public BaseController(BusLocatorUserManager userManager, BusLocatorSignInManager signInManager, BusLocatorRoleManager roleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }

        public BusLocatorSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<BusLocatorSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public BusLocatorUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<BusLocatorUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public BusLocatorRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<BusLocatorRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public string CurrentUserId
        {
            get
            {
                return User.Identity.GetUserId();
            }
        }

        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }

                if (_roleManager != null)
                {
                    _roleManager.Dispose();
                    _roleManager = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}