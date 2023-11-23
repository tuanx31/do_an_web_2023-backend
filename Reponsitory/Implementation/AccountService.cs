﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using web_api.Data;
using web_api.Models;
using web_api.Reponsitory.Abastract;
    
namespace web_api.Reponsitory.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountService(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager ,IConfiguration configuration , RoleManager<IdentityRole> roleManager) {
            this.userManager = userManager; 
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager; 
        }
        public async Task<string> SignInAsync(SignInModel model)
        {
            var user = await userManager.FindByNameAsync(model.Email);
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {
                return string.Empty;
            }
            var userRole = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                
            };
            foreach (var item in userRole)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, item));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new ApplicationUser()
            {
                name = model.name,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
       
            };
            //if(await roleManager.RoleExistsAsync("User"))
            //{
            var result = await userManager.CreateAsync(user, model.Password);
            await userManager.AddToRoleAsync(user, "User");
            return result;
        }
    }
}
