using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Common.Helpers
{
    public class JwtService
    {
        private readonly string secureKey = "yJQX736WxRSXy6m4x4UMd4VSKaWx9K2g";
        //private readonly byte[] key;

        //public JwtService(byte[] key)
        //{
        //  this.key = key;
        //}
        public static string Generate(string username)
        {
            var claims = new List<Claim>
        {
          new Claim(ClaimTypes.Name, username)
        };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yJQX736WxRSXy6m4x4UMd4VSKaWx9K2g"));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(issuer: username, audience: null, claims: claims, notBefore: null, expires: DateTime.UtcNow.AddMinutes(30));
            var securityToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public static string GenerateRefreshToken(string username)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yJQX736WxRSXy6m4x4UMd4VSKaWx9K2g"));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(issuer: username, audience: null, claims: null, notBefore: null, expires: DateTime.UtcNow.AddHours(6));
            var securityToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }


        public static JwtSecurityToken JwtVerify(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("yJQX736WxRSXy6m4x4UMd4VSKaWx9K2g");

            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,

            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }

        public string ValidateRefreshToken(string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;

            var pricipal = tokenHandler.ValidateToken(refreshToken,
              new TokenValidationParameters
              {
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey)),
                  ValidateIssuer = false,
                  ValidateAudience = false
              }, out validatedToken);

            var jwttoken = validatedToken as JwtSecurityToken;

            return jwttoken.Issuer; ;

        }
    }
}