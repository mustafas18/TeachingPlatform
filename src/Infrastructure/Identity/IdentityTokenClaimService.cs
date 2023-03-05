using Core;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class IdentityTokenClaimService : ITokenClaimsService
    {
        private readonly UserManager<AppUser> _userManager;


        public IdentityTokenClaimService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetTokenAsync(LoginInfoDto loginInfo)
        {
            var user = await _userManager.FindByNameAsync(loginInfo.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginInfo.Password))
                throw new Exception("UserName or Password is wrong.");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(AppConstants.securityKey);
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);


            var tokenOptions = new JwtSecurityToken(
               issuer: AppConstants.validIssuer,
               audience: AppConstants.validAudience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(Convert.ToDouble(AppConstants.expiryInMinutes)),
               signingCredentials: signingCredentials
               );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);


        }
    }

}
