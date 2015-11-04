using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Data.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Shared.Model;
using Shared.Model.DTO;
using Splitter.App_Start;
using Splitter.Common;
using Splitter.Models;
using RepositoryManager = Splitter.Common.RepositoryManager;

namespace Splitter.Controllers
{
    public class AccountController : Controller
    {
        private CustomSignInManager _signInManager;
        private CustomUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(CustomUserManager userManager, CustomSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public CustomSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<CustomSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public CustomUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<CustomUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await SignInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                //case SignInStatus.LockedOut:
                //    return View("Lockout");
                //case SignInStatus.RequiresVerification:
                //    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new CustomIdentityUser(RegisterModel.ConvertToUser(model));
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var createdUser = RepositoryManager.Instance.UserRepository.GetByLogin(model.Login);
                    if (createdUser != null)
                    {
                        await SignInManager.SignInAsync(new CustomIdentityUser(createdUser), isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}