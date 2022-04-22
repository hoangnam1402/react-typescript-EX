
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rookie.AssetManagement.Business.Extensions;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Authorize
{

    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private User _user;
        public AuthManager(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {

            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(
                JWTSettings.DurationInMinutes));

            var token = new JwtSecurityToken(
                issuer: JWTSettings.Issuer,
                claims: claims,
                expires: expiration,
                audience: JWTSettings.Audience,
                signingCredentials: signingCredentials
                );

            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var roles = await _userManager.GetRolesAsync(_user);
            var claims = new List<Claim>
             {
                new Claim(UserClaims.StaffCode,_user.StaffCode),
                new Claim(UserClaims.UserName,_user.UserName),
                new Claim(UserClaims.Location,_user.Location.ToString()),
                new Claim(UserClaims.Id,_user.Id.ToString()),
                new Claim(UserClaims.Role,roles[0]),
                new Claim(UserClaims.FullName,_user.GetFullName()),
                new Claim(UserClaims.FirstLogin,_user.FirstLogin.ToString()),
                new Claim(UserClaims.IsDisable,_user.IsDisable.ToString()),
             };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = JWTSettings.Key;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(UserLoginDTO userDTO)
        {
            _user = await _userManager.FindByNameAsync(userDTO.UserName);

            var result = await _signInManager.PasswordSignInAsync(userDTO.UserName, userDTO.Password, true, false);
            return result.Succeeded;
        }
    }

}
