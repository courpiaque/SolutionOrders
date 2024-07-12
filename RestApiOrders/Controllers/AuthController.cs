using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestApiOrders.DTOs;
using RestApiOrders.Helpers;
using RestApiOrders.Model;
using RestApiOrders.Model.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestApiOrders.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly JwtSettings _jwtSettings;
		private readonly CompanyContext _context;

		public AuthController(CompanyContext context, JwtSettings jwtSettings)
		{
			_context = context;
			_jwtSettings = jwtSettings;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(UserDto userDto)
		{
			var user = new User
			{
				Login = userDto.Login,
				Password = userDto.Password
			};
			_context.Users.Add(user);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				throw;
			}

			return Ok(user);
		}

		[HttpPost("login")]
		public IActionResult Login(UserDto userDto)
		{
			var user = _context.Users.SingleOrDefault(x => x.Login == userDto.Login && x.Password == userDto.Password);
			if (user == null)
				return BadRequest(new { message = "Username or password is incorrect" });

			var token = GenerateJwtToken(user);

			return Ok(new { token });
		}

		private string GenerateJwtToken(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
				Issuer = _jwtSettings.Issuer,
				Audience = _jwtSettings.Audience,
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}

}
