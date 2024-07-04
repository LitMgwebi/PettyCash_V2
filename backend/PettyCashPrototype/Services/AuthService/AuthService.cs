using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PettyCashPrototype.Services.AuthService
{
    public class AuthService: IAuth
    {
        private readonly UserManager<User> _userManager;
        private readonly IUser _user;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<User> userManager, IUser user, IConfiguration configuration) { 
            _userManager = userManager;
            _user = user;
            _configuration = configuration;
        }


        public async Task<JWTToken> CreateToken(User user)
        {
            try
            {
                JWTToken jwtToken = new JWTToken();
                string issuer = _configuration["Jwt:Issuer"]!;
                string audience = _configuration["Jwt:Audience"]!;
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);

                SigningCredentials signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                );
                IList<string> roles = await _userManager.GetRolesAsync(user);
                List<Claim> claims = new List<Claim>();
                if (roles.Count() > 0)
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.FirstOrDefault()!));
                    claims.Add(new Claim(ClaimTypes.Sid, user.Id!.ToString()));
                    claims.Add(new Claim(ClaimTypes.Email, user.Email!));
                    claims.Add(new Claim(ClaimTypes.Name, user.FullName));
                    claims.Add(new Claim("Division", user.DivisionId.ToString()));
                }
                else
                    throw new InvalidOperationException("You have not been authorized for access by the system's administration. Please contact system administration to gain access.");

                JwtSecurityToken tokenOptions = new JwtSecurityToken
                (
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(20),
                    issuer: issuer,
                    audience: audience,
                    signingCredentials: signingCredentials
                );

                jwtToken.Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return jwtToken;
            }
            catch { throw; }
        }

        public async Task<bool> ValidateUser(string password, User user)
        {
            try
            {
                var validator = new PasswordValidator<User>();
                IdentityResult result = await validator.ValidateAsync(_userManager, user, password);

                if(result.Succeeded)
                    return true;
                else return false;
            } catch { throw; }
        }

        
    }
}
