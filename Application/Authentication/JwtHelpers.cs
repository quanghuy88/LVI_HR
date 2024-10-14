using Core.Dtos.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(JwtUserTokens userAccounts, Guid Id)
        {
            IEnumerable<Claim> claims = new Claim[]
            {
                new Claim("Id",userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccounts.UserName),
                new Claim(ClaimTypes.NameIdentifier,Id.ToString()),
                new Claim(ClaimTypes.Expiration,DateTime.Now.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt")),
                //new Claim(ClaimTypes.Role, JsonConvert.SerializeObject(userAccounts.Role))
            };
            return claims;
        }
        public static IEnumerable<Claim> GetClaims(JwtUserTokens userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccounts, Id);
        }
        //public static JwtUserTokens GenTokenkey(JwtUserTokens model, JwtSetting jwtSettings)
        //{
        //    if (model == null) throw new ArgumentException(nameof(model));
        //    try
        //    {
        //        // Get secret key
        //        var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
        //        Guid Id = Guid.Empty;
        //        DateTime expireTime = DateTime.Now.AddDays(jwtSettings.ClockSkew);
        //        model.Validaty = expireTime.TimeOfDay;
        //        var JWToken = new JwtSecurityToken(
        //            issuer: jwtSettings.ValidIssuer,
        //            audience: jwtSettings.ValidAudience,
        //            claims: GetClaims(model, out Id),
        //            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
        //            expires: new DateTimeOffset(expireTime).DateTime,
        //            signingCredentials: new SigningCredentials
        //            (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        //        );

        //        model.Token = new JwtSecurityTokenHandler().WriteToken(JWToken);
        //        var idRefreshToken = Guid.NewGuid();

        //        model.GuidId = Id;
        //        model.ExpiredTime = expireTime;
        //        model.RefreshToken = idRefreshToken.ToString();
        //        return model;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public static string GenTokenkey(JwtUserTokens model, JwtSetting jwtSettings)
        {
            if (model == null) throw new ArgumentException(nameof(model));
            try
            {
                // Get secret key
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
                Guid Id = Guid.Empty;
                DateTime expireTime = DateTime.Now.AddDays(jwtSettings.ClockSkew);
                model.Validaty = expireTime.TimeOfDay;
                var JWToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudience,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                );
                return new JwtSecurityTokenHandler().WriteToken(JWToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool ValidToken(string Token, JwtSetting jwtSettings)
        {
            var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(Token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidAudience = jwtSettings.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
