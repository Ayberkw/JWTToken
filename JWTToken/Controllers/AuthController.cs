using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTToken.Models;
using Microsoft.AspNetCore.Authorization;
using JWTToken.Models;
using JWTToken.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using JWTToken.Services;

namespace JWTToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "John", LastName = "Doe", Username = "johndoe", Password = "password", Role = "User" },
            new User { Id = 2, FirstName = "Jane", LastName = "Doe", Username = "janedoe", Password = "password", Role = "Admin" }
        };

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = _tokenService.GenerateToken(user);

            return Ok(new { token });
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("changepassword")]
        public IActionResult ChangePassword([FromBody] ChangePasswordModel model)
        {
            var user = _userService.Authenticate(model.Username, model.CurrentPassword);

            if (user == null)
            {
                return Unauthorized();
            }

            user.Password = model.NewPassword;

            _userService.Update(user);

            return Ok();
        }
    }
}