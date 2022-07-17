﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MuhasebeMaster.MvcWebUI.Identity;
using MuhasebeMaster.MvcWebUI.Models.Security;
using MuhasebeMaster.MvcWebUI.Services;

namespace MuhasebeMaster.MvcWebUI.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SecurityController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private RoleManager<AppIdentityRole> _roleManager;
        private SignInManager<AppIdentityUser> _signInManager;
        private IConfiguration _configuration;
        private IMailService _mailService;
        private ILogger _logger;

        public SecurityController(UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityRole> roleManager,SignInManager<AppIdentityUser> signInManager,
            IConfiguration configuration, IMailService mailService, ILogger logger)
        {  
            _userManager = userManager; 
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mailService = mailService;
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = null) 
        {
            if (ModelState.IsValid)
            {
                returnUrl ??= Url.Content("~/");
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user != null)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError(string.Empty, "Confirm your email please!");
                        return View(loginViewModel);
                    }
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, true);
                    if (result.Succeeded)
                    {
                        //return Redirect("/Home/Index");
                        if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            _logger.LogInformation("User logged in.");
                            return Redirect(returnUrl);
                        }
                        if (result.IsLockedOut)
                        {
                            _logger.LogWarning("User account locked out.");
                            return RedirectToPage("./Lockout");
                        }
                        else
                        {
                            return View(loginViewModel);
                        }
                    }
                    ModelState.AddModelError(String.Empty, "Login failed!");
                    return View(loginViewModel);
                }
                return View(loginViewModel);
            }
            return View(loginViewModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult AccessDenied() 
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel) 
        {
            if (ModelState.IsValid)
            {  
                var user = new AppIdentityUser { 
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.UserName
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    var confirmationCode = _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var projectUrl = _configuration.GetSection("ProjectSettings").GetSection("ProjectUrl").Value;
                    var callBackUrl = projectUrl + Url.Action("ConfirmEmail", "Security", new { userId = user.Id, code = confirmationCode.Result });

                    //Kullaniciya mail gonderme
                    var emailAddressesTo = new List<EmailAddress>();
                    emailAddressesTo.Add(new EmailAddress { Name = registerViewModel.UserName, Address = registerViewModel.Email});
                    var emailAddressesFrom = new List<EmailAddress>();
                    emailAddressesFrom.Add(new EmailAddress { Name = "Test Project Bilgilendirme", Address = _configuration.GetSection("EmailConfiguration").GetSection("EmailFrom").Value });
                    _mailService.Send(new EmailMessage { Content = callBackUrl, ToAddresses = emailAddressesTo, Subject = registerViewModel.UserName, FromAddresses = emailAddressesFrom });

                    return RedirectToAction("ConfirmEmailInfo","Security", new { email = user.Email });
                }
                return View(registerViewModel);
            }
            return View(registerViewModel);
        }

        [AllowAnonymous]
        public IActionResult ConfirmEmailInfo(string email) 
        {
            TempData["email"] = email;
            return View();
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code) 
        {
            if (userId == null || code == null)
            {
                RedirectToAction("Index", "Home");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException("Unable to find user!");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(forgotPasswordViewModel);
            }
            var user = await _userManager.FindByEmailAsync(forgotPasswordViewModel.Email);
            if (user == null)
            {
                return View(forgotPasswordViewModel);
            }
            var confirmationCode = await _userManager.GeneratePasswordResetTokenAsync(user);
            var projectUrl = _configuration.GetSection("ProjectSettings").GetSection("ProjectUrl").Value;
            var callBack = projectUrl + Url.Action("ResetPassword", "Security", new { userId = user.Id, code = confirmationCode });

            //Send email

            return RedirectToAction("ConfirmForgotPasswordInfo", new { email = user.Email });
        }

        [AllowAnonymous]
        public IActionResult ConfirmForgotPasswordInfo(string email) 
        {
            TempData["email"] = email;
            return View();
        }

        [AllowAnonymous]
        public IActionResult ResetPassword(string userId, string code) 
        {
            if (userId == null || code == null)
            {
                throw new ApplicationException("User id or code must be supplied for password reset!");
            }
            var resetPasswordViewModel = new ResetPasswordViewModel { 
                Code = code
            };
            return View(resetPasswordViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel) 
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
                if (user == null)
                {
                    throw new ApplicationException("User not found!");
                }
                var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Code, resetPasswordViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                return View(resetPasswordViewModel);
            }
            return View(resetPasswordViewModel);
        }
    }
}