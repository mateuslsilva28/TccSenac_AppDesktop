using ColegioImperio.API.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ColegioImperio.API.JWT
{
    public class TokenGenerate
    {
        internal Token CreateToken(string username)
        {
            //Data do Token
            DateTime issuedAt = DateTime.UtcNow;

            //Tempo de expiraçao em dias
            DateTime expires = DateTime.UtcNow.AddDays(1);

            var tokenHandler = new JwtSecurityTokenHandler();

            //cria a identidade do usuário que será concedido acesso
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username.ToUpper())
            });

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            //cria o token propriamente dito
            JwtSecurityToken jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:50191", audience: "http://localhost:50191",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);

            Token token = new Token
            {
                Username = username.ToUpper(),
                Expires = jwtSecurityToken.ValidTo,
                Code = tokenHandler.WriteToken(jwtSecurityToken)
            };

            return token;
        }
    }
}