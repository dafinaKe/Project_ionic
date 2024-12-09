using Taxi_APP.Data;
using Taxi_APP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Diagnostics.Metrics;
using System.Security.Claims;
using static Taxi_APP.Models.TokenModel;
using TaxiApp.Controllers;

namespace Taxi_APP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase, IAuthController
    {
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthentication _authentication;
        private readonly IHttpContextAccessor _context;

        public AuthController(ApplicationDbContext db, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
            IAuthentication authentication, IHttpContextAccessor context)
        {
            _db = db;
            _signInManager = signInManager;
            _userManager = userManager;
            _authentication = authentication;
            _context = context;

        }
        [HttpPost("registerUser")]
        public async Task<ActionResult<ServiceResponse<string>>> Register(Register register)
        {
            var response = new ServiceResponse<string>();
            var checking = await _userManager.FindByEmailAsync(register.Email);

            if (checking != null)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "You're already registered";
                return response;
            }

            var user = new ApplicationUser
            {
                Email = register.Email,
                UserName = register.UserName,
                PhoneNumber = register.PhoneNumber,
                FirstName = register.FirstName,
                LastName = register.LastName,
                City = register.City,
                Country = register.Country,
                Birthday = register.Birthday,
                Address = register.Address,
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    if (error.Code == "DuplicateUserName")
                    {
                        response.Data = null;
                        response.Success = false;
                        response.Message = "Username is already chosen";
                        return response;
                    }
                    if (error.Code == "PasswordRequiresNonAlphanumeric" || error.Code == "PasswordRequiresDigit" || error.Code == "PasswordRequiresUpper")
                    {
                        response.Data = null;
                        response.Success = false;
                        response.Message = "Password is not strong enough";
                        return response;
                    }
                }
                response.Data = null;
                response.Success = false;
                response.Message = "Failed to create user";
                return response;
            }

            // If registration is successful
            response.Data = null;
            response.Success = true;
            response.Message = "You're registered successfully";
            return response;
        }
        [HttpPost("loginUser")]
        public async Task<ActionResult<ServiceResponse<List<string>>>> Login(Login login)
        {
            var response = new ServiceResponse<List<string>>();
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "No user found";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
            if (result.Succeeded)
            {
                // Generate JWT Token
                var jwtSecurityToken = _authentication.GenerateJwtToken(user); // Assuming the token generation method does not require roles
                var refreshToken = _authentication.GenerateRefreshToken();



                // Optionally store the token in session
                _context.HttpContext.Session.SetString("user", user.NormalizedEmail);
                _context.HttpContext.Session.SetString("Token", jwtSecurityToken);

                // Return tokens to the client
                List<string> tokenList = new List<string>
        {
            jwtSecurityToken,
            refreshToken
        };
                response.Data = tokenList;
                response.Message = "Logged in successfully";
                response.Success = true;
            }
            else
            {
                response.Data = null;
                response.Message = "Invalid credentials";
                response.Success = false;
            }

            return response;
        }

    }
}
