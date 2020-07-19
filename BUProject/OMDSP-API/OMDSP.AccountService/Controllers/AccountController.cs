using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OMDSP.AccountService.Repositories;
using OMDSP.AccountService.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;



namespace OMDSP.AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repo;
        private readonly IConfiguration configuration;
        public AccountController(IAccountRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            this.configuration = configuration;
        }
        [HttpGet]
        [Route("userSignin/{userName}/{userPwd}")]
        public IActionResult userSignin(string userName, string userPwd)
        {
            Token token = null;
            try
            {
                Registration registration = _repo.userSignin(userName, userPwd);
                if (registration != null)
                {
                    token = new Token() { userId = registration.UserId, token = GenerateJwtToken(userName), msg = "Success" };
                }
                else
                {
                    token = new Token() { token = "", msg = "Unsuccess" };
                }
                return Ok(token);
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        private string GenerateJwtToken(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userName),
                new Claim(ClaimTypes.Role,userName)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // recommended is 5 min
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            //var response = new Token
            //{
            //    username = username,
            //    token = new JwtSecurityTokenHandler().WriteToken(token)
            //};
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost]
        [Route("userSignup")]
        public IActionResult userSignup(Registration obj)
        {
            try
            {
                _repo.userSignup(obj);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
       

    }
}
