﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReadNoteWebApplication.Data.Helpers
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;
        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateToken(User user)
        {
            Claim[] claims = [new("userId", user.Id.ToString())];

            SigningCredentials signingCredentials = new SigningCredentials
            (
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),SecurityAlgorithms.HmacSha256
            );

            JwtSecurityToken token = new JwtSecurityToken
            (
                claims: claims,
                signingCredentials: signingCredentials,
                expires:DateTime.UtcNow.AddDays(_options.ExpiresHours)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
            
        }
    }
}
