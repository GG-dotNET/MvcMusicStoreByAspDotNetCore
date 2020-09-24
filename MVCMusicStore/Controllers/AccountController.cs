using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCMusicStore.Models;
using MVCMusicStore.ViewModels;

namespace MVCMusicStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel()
            {
                ReturnUrl = returnUrl

            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password,
                    model.RememberMe, false);

                if (loginResult.Succeeded)
                {
                    if (Url.IsLocalUrl(model.ReturnUrl)) return Redirect(model.ReturnUrl);

                    return RedirectToAction("Index", "Home");
                }
            }
            else
                ModelState.AddModelError("", "User not found");
            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() => View();

        [HttpPost, ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { Email = model.Email, UserName = model.UserName };
                var createResult = await _userManager.CreateAsync(user, model.Password);

                if (createResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var identityError in createResult.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }










        //private IActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }

        //    return RedirectToAction(nameof(HomeController.Index), "Home");
        //}

        //private void AddError(IdentityResult result)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError(string.Empty, error.Description);
        //    }
        //}

        //public IActionResult Register(string returnUrl = null)
        //{
        //    ViewData["ReturnUrl"] = returnUrl;

        //    return View();
        //}


        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string returnUrl = null)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ViewData["ReturnUrl"] = returnUrl;
        //        var identityUser = new ApplicationUser
        //        {

        //            UserName = registerViewModel.UserName,
        //            NormalizedUserName = registerViewModel.UserName
        //        };
        //        var identityResult = await _userManager.CreateAsync(identityUser, registerViewModel.Password);
        //        if (identityResult.Succeeded)
        //        {
        //            await _signInManager.SignInAsync(identityUser, new AuthenticationProperties { IsPersistent = true });

        //            return RedirectToLocal(returnUrl);
        //        }
        //        else
        //        {
        //            AddError(identityResult);
        //        }
        //    }

        //    return View();
        //}

        //public IActionResult Login(string returnUrl = null)
        //{
        //    ViewData["ReturnUrl"] = returnUrl;
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        //{
        //    var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
        //    if (user != null)
        //    {
        //        var result = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
        //        if (result != true)
        //        {
        //            return View(loginViewModel);
        //        }
        //        else
        //        {
        //            await _signInManager.SignInAsync(user, new AuthenticationProperties { IsPersistent = true });
        //        }
        //    }
        //    else
        //    {

        //        return View(loginViewModel);
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}

        //public IActionResult AccessDenied()
        //{
        //    return View();
        //}


















        //// GET: /Account/LogOn

        //public IActionResult LogOn()
        //{
        //    return View();
        //}

        ////
        //// POST: /Account/LogOn

        //[HttpPost]
        //public IActionResult LogOn(LogOnModel model, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Membership.ValidateUser(model.UserName, model.Password))
        //        {
        //            FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
        //            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
        //                && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
        //            {
        //                return Redirect(returnUrl);
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "The user name or password provided is incorrect.");
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        ////
        //// GET: /Account/LogOff

        //public IActionResult LogOff()
        //{
        //    FormsAuthentication.SignOut();

        //    return RedirectToAction("Index", "Home");
        //}

        ////
        //// GET: /Account/Register

        //public IActionResult Register()
        //{
        //    return View();
        //}

        ////
        //// POST: /Account/Register

        //[HttpPost]
        //public IActionResult Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Attempt to register the user
        //        MembershipCreateStatus createStatus;
        //        Membership.CreateUser(model.UserName, model.Password, model.Email, "question", "answer", true, null, out createStatus);

        //        if (createStatus == MembershipCreateStatus.Success)
        //        {
        //            FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", ErrorCodeToString(createStatus));
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        ////
        //// GET: /Account/ChangePassword

        //[Authorize]
        //public IActionResult ChangePassword()
        //{
        //    return View();
        //}

        ////
        //// POST: /Account/ChangePassword

        //[Authorize]
        //[HttpPost]
        //public IActionResult ChangePassword(ChangePasswordModel model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        // ChangePassword will throw an exception rather
        //        // than return false in certain failure scenarios.
        //        bool changePasswordSucceeded;
        //        try
        //        {
        //            MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
        //            changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
        //        }
        //        catch (Exception)
        //        {
        //            changePasswordSucceeded = false;
        //        }

        //        if (changePasswordSucceeded)
        //        {
        //            return RedirectToAction("ChangePasswordSuccess");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        ////
        //// GET: /Account/ChangePasswordSuccess

        //public IActionResult ChangePasswordSuccess()
        //{
        //    return View();
        //}

        //#region Status Codes
        //private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        //{
        //    // See http://go.microsoft.com/fwlink/?LinkID=177550 for
        //    // a full list of status codes.
        //    switch (createStatus)
        //    {
        //        case MembershipCreateStatus.DuplicateUserName:
        //            return "User name already exists. Please enter a different user name.";

        //        case MembershipCreateStatus.DuplicateEmail:
        //            return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

        //        case MembershipCreateStatus.InvalidPassword:
        //            return "The password provided is invalid. Please enter a valid password value.";

        //        case MembershipCreateStatus.InvalidEmail:
        //            return "The e-mail address provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.InvalidAnswer:
        //            return "The password retrieval answer provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.InvalidQuestion:
        //            return "The password retrieval question provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.InvalidUserName:
        //            return "The user name provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.ProviderError:
        //            return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

        //        case MembershipCreateStatus.UserRejected:
        //            return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

        //        default:
        //            return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
        //    }
        //}
        //#endregion
    }
}
