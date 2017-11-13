﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text.RegularExpressions;

using diary.Models;
using diary.Helper;
using diary.Models.AccountViewModels;

namespace diary.Controllers
{
      public class AccountController : Controller
      {
            private UserManager<User> _usermanager;
            private readonly SignInManager<User> _signinmanager;

            public AccountController(
                  UserManager<User> usermanager,
                  SignInManager<User> signinmanager)
            {
                  _signinmanager = signinmanager;
                  _usermanager = usermanager;
                  _usermanager.PasswordHasher = new PasswordHashing();
            }

            private IActionResult RedirectToLocal(string returnUrl)
            {
                  if (Url.IsLocalUrl(returnUrl))
                  {
                        return Redirect(returnUrl);
                  }
                  else
                  {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                  }
            }


            ///
            /// Login
            /// 
            [HttpGet]
            [AllowAnonymous]
            public async Task<IActionResult> Login(string returnUrl = null)
            {
                  // Clear the existing external cookie to ensure a clean login process
                  await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                  ViewData["ReturnUrl"] = returnUrl;
                  return View();
            }

            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
            {
                  ViewData["ReturnUrl"] = returnUrl;

                  if (ModelState.IsValid)
                  {
                        // This doesn't count login failures towards account lockout
                        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                        var result = await _signinmanager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                              return RedirectToLocal(returnUrl);
                        }
                        else
                        {
                              ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                              return View(model);
                        }
                  }

                  // If we got this far, something failed, redisplay form
                  return View(model);
            }
      }
}