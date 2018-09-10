// -----------------------------------------------------------------------
//  <copyright file="AuthenticationRepository.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Data.Sql
{
    using System;
    using System.Linq;

    using Microsoft.Extensions.Options;

    using Prism.DolphinsMemory.Server.Configuration;
    using Prism.DolphinsMemory.Server.Model;

    /// <summary>
    /// Class to manage authentication data
    /// </summary>
    /// <seealso cref="Prism.DolphinsMemory.Server.Data.IAuthenticationRepository" />
    public class AuthenticationRepository : BaseSqlRepository, IAuthenticationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationRepository" /> class.
        /// </summary>
        /// <param name="connectionStringsSettings">The connection strings settings.</param>
        public AuthenticationRepository(IOptions<ConnectionStrings> connectionStringsSettings)
            : base(connectionStringsSettings)
        {
        }

        /// <inheritdoc />
        public AuthenticationPassword GetUserPassword(Guid userId)
        {
            using (var db = this.GetDatabase())
            {
                return db.SingleOrDefault<AuthenticationPassword>("SELECT * FROM AuthenticationPassword WHERE UserId = @userId", new { userId });
            }
        }

        /// <inheritdoc />
        public void UpsertAuthenticationPassword(Guid userId, byte[] hash, byte[] salt, int iterations)
        {
            using (var db = this.GetDatabase())
            {
                db.BeginTransaction();

                db.Execute("DELETE FROM AuthenticationPassword WHERE UserId = @userId", new { userId });
                db.Execute(
                    "INSERT INTO AuthenticationPassword (UserId, Salt, Hash, Iterations) VALUES (@userId, @salt, @hash, @iterations)",
                    new { userId, hash, salt, iterations });

                db.CompleteTransaction();
            }
        }
    }
}