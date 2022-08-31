using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Zapas.Data.DTO.Login;
using Zapas.Data.Models;
using Zapas.Services.Login;

namespace Zapas.Controllers
{
	[Route("api/account")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly JwtService _jwtService;

		public AccountController(
			ApplicationDbContext context,
			UserManager<ApplicationUser> userManager,
			JwtService jwtService)
		{
			_context = context;
			_userManager = userManager;
			_jwtService = jwtService;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginRequest loginRequest)
		{
			var user = await _userManager.FindByNameAsync(loginRequest.Email);
			if (user == null || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
				return Unauthorized(new LoginResult()
				{
					Success = false,
					Message = "Invalid Email or Password."
				});
			var secToken = await _jwtService.GetTokenAsync(user);
			var jwt = new JwtSecurityTokenHandler().WriteToken(secToken);
			return Ok(new LoginResult()
			{
				Success = true,
				Message = "Login successful",
				Token = jwt
			}); ;
		}
	}
}

