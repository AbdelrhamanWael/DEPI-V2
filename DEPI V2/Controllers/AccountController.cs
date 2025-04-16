using Microsoft.AspNetCore.Mvc;
using DEPI_V2.ViewModels;
using DEPI_V2.Models;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DEPI_V2.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Hardcoded admin check
                if (model.Email == "admin@depi.com" && model.Password == "Admin@123")
                {
                    await signInManager.SignInAsync(new User 
                    { 
                        UserName = model.Email,
                        Email = model.Email,
                        FirstName = "Admin",
                        LastName = "User",
                        IsAdmin = true 
                    }, isPersistent: model.RememberMe);
                    return RedirectToAction("Index", "Dashboard");
                }

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is incorrect.");
                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    RegistrationDate = DateTime.UtcNow
                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        public IActionResult VerifyEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "User not found.");
                    return View(model);
                }
                else
                {
                    return RedirectToAction("ChangePassword", "Account", new { username = user.UserName });
                }
            }
            return View(model);
        }

        public IActionResult ChangePassword(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("VerifyEmail", "Account");
            }
            return View(new ChangePasswordViewModel { 
                Email = username,
                NewPassword = "",
                ConfirmNewPassword = ""
            });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    var result = await userManager.RemovePasswordAsync(user);
                    if (result.Succeeded)
                    {
                        result = await userManager.AddPasswordAsync(user, model.NewPassword);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Login", "Account");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                            return View(model);
                        }
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email not found");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "something went wrong. try");
                return View(model);
            }
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CreateAdmin()
        {
            try
            {
                // Check if admin already exists
                var existingAdmin = await userManager.GetUsersInRoleAsync("Admin");
                if (existingAdmin.Any())
                {
                    return RedirectToAction("Login", "Account");
                }

                // Create Admin role if it doesn't exist
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    var roleResult = await roleManager.CreateAsync(new IdentityRole("Admin"));
                    if (!roleResult.Succeeded)
                    {
                        throw new Exception("Failed to create Admin role");
                    }
                }

                // Check if admin user exists by email
                var existingUser = await userManager.FindByEmailAsync("admin@depi.com");
                if (existingUser != null)
                {
                    // If user exists but not in admin role, add to role
                    if (!await userManager.IsInRoleAsync(existingUser, "Admin"))
                    {
                        await userManager.AddToRoleAsync(existingUser, "Admin");
                    }
                    return RedirectToAction("Login", "Account");
                }

                var adminUser = new User
                {
                    UserName = "admin@depi.com",
                    Email = "admin@depi.com",
                    FirstName = "Admin",
                    LastName = "User",
                    IsAdmin = true,
                    EmailConfirmed = true,
                    RegistrationDate = DateTime.UtcNow
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                
                if (result.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(adminUser, "Admin");
                    if (!roleResult.Succeeded)
                    {
                        throw new Exception("Failed to add user to Admin role");
                    }
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                throw new Exception($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating admin: {ex.Message}");
                return View("Login");
            }
        }
    }
}

