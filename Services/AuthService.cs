using To_Do_List.Repository;
using To_Do_List.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace To_Do_List.Service
{
    public class AuthService 
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration , DataContext context) 
        { 
            _configuration = configuration;
            _context = context;
        }
        public TokenResponse? LoginRequest(LoginUser request)
        {
            var user = _context.Users.FirstOrDefault(user => user.Name == request.Name);

            if(user is null ||
            !BCrypt.Net.BCrypt.Verify(request.Password, user.Passwordhash))
            {
                return null;
            }

            var accessToken = GenerateAccessToken(user);
            var refreshToken = GenerateRefreshToken(user);
            return new TokenResponse
            {
                AcessToken = accessToken,
                RefreshToken = refreshToken.Token
            };
        }

        private string GenerateAccessToken(User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);
            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name,user.Name),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var creds = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer:jwtSettings["Issuer"],
            audience:jwtSettings["Audience"],
            claims:claims,
            expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["AccessTokenExpirationMinutes"]!)),
            signingCredentials:creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private RefreshToken GenerateRefreshToken(User user)
        {
            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                UserId = user.Id,
                Expires = DateTime.UtcNow.AddDays(
                    double.Parse(_configuration["Jwt:RefreshTokenExpirationDays"]!)
                )
            };

            _context.RefreshTokens.Add(refreshToken);
            _context.SaveChanges();
            return refreshToken;
        }
    }

}