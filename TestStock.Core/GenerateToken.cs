using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStock.Core
{
    public class JwtTokenGenerator
    {

        public void GenerateToken()
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EbruEbruEbru1."));
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(1),signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            handler.WriteToken(token);  
        }
    }
}
