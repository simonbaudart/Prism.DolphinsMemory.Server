// -----------------------------------------------------------------------
//  <copyright file="SecurityDomain.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Business.Concrete
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    using Microsoft.AspNetCore.Cryptography.KeyDerivation;

    using Prism.DolphinsMemory.Server.Data;

    /// <summary>
    /// The security domain
    /// </summary>
    /// <seealso cref="Prism.DolphinsMemory.Server.Business.ISecurityDomain" />
    public class SecurityDomain : ISecurityDomain
    {
        /// <summary>
        /// The random chars.
        /// </summary>
        private static readonly string RandomChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";

        /// <summary>
        /// The authentication repository
        /// </summary>
        private IAuthenticationRepository authenticationRepository;

        /// <summary>
        /// The user repository
        /// </summary>
        private IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityDomain" /> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="authenticationRepository">The authentication repository.</param>
        public SecurityDomain(IUserRepository userRepository, IAuthenticationRepository authenticationRepository)
        {
            this.userRepository = userRepository;
            this.authenticationRepository = authenticationRepository;
        }

        /// <inheritdoc />
        public void AddAuthenticationPassword(string userName, byte[] hash, byte[] salt, int iterations)
        {
            var userId = this.userRepository.GetUserId(userName);
            this.authenticationRepository.UpsertAuthenticationPassword(userId, hash, salt, iterations);
        }

        /// <inheritdoc />
        public string GeneratePassword()
        {
            var dice = new Random(Environment.TickCount);

            var builder = new StringBuilder();

            for (var i = 0; i < 12; i++)
            {
                var index = dice.Next(RandomChars.Length);
                builder.Append(RandomChars[index]);
            }

            return builder.ToString();
        }

        /// <inheritdoc />
        public byte[] GenerateSalt()
        {
            var salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        /// <inheritdoc />
        public byte[] Hash(string password, byte[] salt, int iterations)
        {
            return KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA512,
                iterations,
                256 / 8);
        }
    }
}