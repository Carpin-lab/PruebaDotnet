using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using PruebaDotnet.src.Auth.dto;
using PruebaDotnet.src.Auth.model;
using PruebaDotnet.src.interfaces;
using PruebaDotnet.src.user.entity;

namespace PruebaDotnet.src.Auth
{
    public class AuthService : IAuthServices
    {

        public IConfiguration _configuration;
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _authRepository = authRepository;
        }

        public async Task<UserEntity> FindUser(AuthDto Credencials)
        {
            var user = await _authRepository.FindUser(Credencials);
            return user;
        }

        public JwtDto SignTokens(UserEntity Credencials)
        {
            var jwt = _configuration.GetSection("jwt").Get<JwtModel>();
            Console.WriteLine($"Subject: {jwt.Subject}, Issuer: {jwt.Issuer}, Audience: {jwt.Audience}");

            var keyBytes = Encoding.UTF8.GetBytes(jwt.Key);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Credencials.id.ToString()));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
            string tokenCreated = tokenHandler.WriteToken(tokenConfig);
            return new JwtDto()
            {
                AccessToken = tokenCreated
            };

            // var claim = new[]{
            //     new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
            //     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //     // new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            //     new Claim(JwtRegisteredClaimNames.Exp, DateTime.UtcNow.ToString()),
            //     new Claim("id", Credencials.id.ToString()),
            //     new Claim("user", Credencials.username.ToString()),
            // };
            // var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            // var SignIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // var tokes = new JwtSecurityToken(
            //     jwt.Issuer,
            //     jwt.Audience,
            //     claim,
            //     expires: DateTime.UtcNow.AddMinutes(60),
            //     signingCredentials: SignIn
            // );
            // return new JwtDto()
            // {
            //     AccessToken = new JwtSecurityTokenHandler().WriteToken(tokes),
            // };
        }
    }
}