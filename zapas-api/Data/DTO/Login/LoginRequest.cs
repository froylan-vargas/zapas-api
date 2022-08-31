using System;
namespace Zapas.Data.DTO.Login
{
	public class LoginRequest
	{
		[Required(ErrorMessage = "Email is required.")]
		public string Email { get; set; } = null!;

		[Required(ErrorMessage = "Password is required.")]
		public string Password { get; set; } = null!;
	}
}

