using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace JWTLogin.WebApplication2.Code
{
    public class Auth
    {
        public static void CreateAuthentication(string loginToken, DateTime? expires = null)
        {
            expires = expires ?? DateTime.Now.AddDays(1);
            var claims = new List<Claim>(new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("loginId",loginToken)
            });

            var handler = new JwtSecurityTokenHandler();
            var securityToken = new JwtSecurityToken(
               claims: claims,
               expires: expires.Value
            );
            var token = handler.WriteToken(securityToken);

            HttpContext.Current.Response.Cookies.Add(CreateCookie("AuthCookieName", token, expires.Value));
        }

        public static HttpCookie CreateCookie(string name, string value, DateTime? expires = null)
       => new HttpCookie(name, value) { Expires = expires ?? DateTime.Now.AddYears(1), HttpOnly = true, Secure = true, SameSite = SameSiteMode.Strict };
    }
}