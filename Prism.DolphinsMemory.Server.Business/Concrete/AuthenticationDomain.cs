// -----------------------------------------------------------------------
//  <copyright file="AuthenticationDomain.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Business.Concrete
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;

    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    using Prism.DolphinsMemory.Server.Configuration;
    using Prism.DolphinsMemory.Server.Data;
    using Prism.DolphinsMemory.Server.Model;
    using Prism.DolphinsMemory.Server.Security;

    /// <summary>
    /// All methods for authentication
    /// </summary>
    /// <seealso cref="Prism.DolphinsMemory.Server.Business.IAuthenticationDomain" />
    public class AuthenticationDomain : IAuthenticationDomain
    {
        /// <summary>
        /// The authentication repository
        /// </summary>
        private readonly IAuthenticationRepository authenticationRepository;

        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// The security settings
        /// </summary>
        private readonly SecuritySettings securitySettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationDomain" /> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="authenticationRepository">The authentication repository.</param>
        /// <param name="securitySettingsOptions">The security settings options.</param>
        public AuthenticationDomain(IUserRepository userRepository, IAuthenticationRepository authenticationRepository, IOptions<SecuritySettings> securitySettingsOptions)
        {
            this.userRepository = userRepository;
            this.authenticationRepository = authenticationRepository;
            this.securitySettings = securitySettingsOptions.Value;
        }

        /// <inheritdoc />
        public Guid GetUserId(string userName)
        {
            return this.userRepository.GetUserId(userName);
        }

        /// <inheritdoc />
        public string ValidateUser(UserAuthentication authentication)
        {
            var userId = this.GetUserId(authentication.UserName);

            if (userId == default(Guid))
            {
                return null;
            }

            var authenticationPassword = this.authenticationRepository.GetUserPassword(userId);

            if (authenticationPassword == null)
            {
                return null;
            }

            var computedHash = PasswordHasher.Hash(authentication.Password, authenticationPassword.Salt, authenticationPassword.Iterations);

            if (!computedHash.SequenceEqual(authenticationPassword.Hash))
            {
                return null;
            }

            return this.GenerateBearer(userId);
        }

        /// <summary>
        /// Generates the bearer.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The bearer</returns>
        private string GenerateBearer(Guid userId)
        {
            var handler = new JwtSecurityTokenHandler();
            handler.SetDefaultTimesOnTokenCreation = true;
            handler.TokenLifetimeInMinutes = 60;

            var signingKey = new SymmetricSecurityKey(KeyGenerator.GetSigninByteKey(this.securitySettings.BearerDerivationKey));
            var encryptKey = new SymmetricSecurityKey(KeyGenerator.GetEncryptByteKey(this.securitySettings.BearerDerivationKey));

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha512);
            var encryptCredentials = new EncryptingCredentials(encryptKey, SecurityAlgorithms.Aes256KW, SecurityAlgorithms.Aes256CbcHmacSha512);

            var claims = new ClaimsIdentity(
                new[] { new Claim(ClaimTypes.Sid, userId.ToString()) });

            var token = handler.CreateJwtSecurityToken(
                this.securitySettings.Issuer,
                "api://default",
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                DateTime.UtcNow,
                signingCredentials,
                encryptCredentials);

            return handler.WriteToken(token);
        }
    }
}