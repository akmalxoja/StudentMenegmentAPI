using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Permission_Domen.Entityes;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Permission_Infrastructure.JWT_Token
{
    public class GeneretTokenServies
    {
        private readonly IConfiguration _configuration;

        public GeneretTokenServies(IConfiguration configuration) => _configuration = configuration;
        public async Task<string> GenerateToken(User user)
        {

            var permissions = new List<int>();

            if (user.ERole.ToString() == "Admin")
            {
                permissions = new List<int>() { 1, 2, 3, 4, 5 };
            }
            else if (user.ERole.ToString() == "Manangment")
            {
                permissions = new List<int>() { 1, 2, 3 };
            }
            else if (user.ERole.ToString() == "User")
            {
                permissions = new List<int>() { 1 };
            }

            var jsonContent = JsonSerializer.Serialize(permissions);


            List<Claim> claims = new List<Claim>()
                {
                    new Claim("UserName", user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("password" , user.Password),
                    new Claim(ClaimTypes.Role , user.ERole.ToString()),
                    new Claim("CreatedDate", DateTime.UtcNow.ToString()),
                    new Claim("Permissions", jsonContent),

                };

            return await GenerateToken(claims);
        }
        public async Task<string> GenerateToken(IEnumerable<Claim> additionalClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var exDate = Convert.ToInt32(_configuration["JWT:ExpireDate"] ?? "10");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64)
            };

            if (additionalClaims?.Any() == true)
                claims.AddRange(additionalClaims);

            var token = new JwtSecurityToken(
            issuer: _configuration["JWT:Issuer"],
            audience: _configuration["JWT:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(exDate),
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
