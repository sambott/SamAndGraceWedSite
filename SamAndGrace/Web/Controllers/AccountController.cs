using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Web.DAL;
using Web.Models;
using Web.Models.Identity;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<SiteUser> m_userManager;
        private readonly RoleManager<SiteRole> m_roleManager;

        public AccountController()
        {
            var db = new SamAndGraceContext();

            var userStore = new UserStore<SiteUser>(db);
            m_userManager = new UserManager<SiteUser>(userStore);

            var roleStore = new RoleStore<SiteRole>(db);
            m_roleManager = new RoleManager<SiteRole>(roleStore);

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new SiteUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FullName = model.FullName
                };

                IdentityResult result = m_userManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    m_userManager.AddToRole(user.Id, "Administrator");
                    return RedirectToAction("Login", "Account");
                }
                ModelState.AddModelError("UserName", "Error while creating the user!");
            }
            return View(model);

        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            SiteUser user = m_userManager.Find(model.UserName, model.Password);
            if (user != null)
            {
                IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                ClaimsIdentity identity = m_userManager.CreateIdentity(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                var props = new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                };
                authenticationManager.SignIn(props, identity);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid username or password.");
            return View(model);
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                SiteUser user = m_userManager.FindByName(HttpContext.User.Identity.Name);
                IdentityResult result = m_userManager.ChangePassword(user.Id, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut();
                    return RedirectToAction("Login", "Account");
                }
                ModelState.AddModelError("", "Error while changing the password.");
            }
            return View(model);
        }

        [Authorize]
        public ActionResult ChangeProfile()
        {
            SiteUser user = m_userManager.FindByName(HttpContext.User.Identity.Name);
            var model = new ChangeProfile
            {
                FullName = user.FullName
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeProfile(ChangeProfile model)
        {
            if (ModelState.IsValid)
            {
                SiteUser user = m_userManager.FindByName(HttpContext.User.Identity.Name);
                user.FullName = model.FullName;
                IdentityResult result = m_userManager.Update(user);
                if (result.Succeeded)
                {
                    ViewBag.Message = "Profile updated successfully.";
                }
                else
                {
                    ModelState.AddModelError("", "Error while saving profile.");
                }
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}