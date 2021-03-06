﻿using Microsoft.IdentityModel.Tokens;
using Order_V2.Domain.Users.Authentication;
using Order_V2.Services.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Order_V2.Services.Users.Security
{
    public class UserAuthenticationServices
    {
        public static readonly string SECRET_KEY = "MyVerySecretKeyThatShouldNotBePlacedLikeThisHere";

        private readonly IUserServices _userService;
        private readonly Hasher _hasher;
        private readonly Salter _salter;

        public UserAuthenticationServices(IUserServices userRepository, Hasher hasher, Salter salter)
        {
            _userService = userRepository;
            _hasher = hasher;
            _salter = salter;
        }

        public JwtSecurityToken Authenticate(string providedEmail, string providedPassword)
        {
            LoginInformation foundUser = _userService.FindByLoginEmail(providedEmail);

            if (IsSuccessfullyAuthenticated(providedEmail, providedPassword, foundUser.UserSecurity))
            {
                return new JwtSecurityTokenHandler().CreateToken(CreateTokenDescription(foundUser)) as JwtSecurityToken;
            }
            return null;
        }

        public UserSecurity CreateUserSecurity(string userPassword)
        {
            var saltToBeUsed = _salter.CreateRandomSalt();
            return new UserSecurity(
                _hasher.CreateHashOfPasswordAndSalt(userPassword, saltToBeUsed),
                saltToBeUsed);
        }

        private SecurityTokenDescriptor CreateTokenDescription(LoginInformation foundUser)
        {
            var key = Encoding.ASCII.GetBytes(SECRET_KEY);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    { new Claim(ClaimTypes.Email, foundUser.Email) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenDescriptor;
        }

        private bool IsSuccessfullyAuthenticated(string providedEmail, string providedPassword, UserSecurity persistedUserSecurity)
        {
            return _hasher.DoesProvidedPasswordMatchPersistedPassword(providedPassword, persistedUserSecurity);
        }
    }
}
