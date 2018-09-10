// -----------------------------------------------------------------------
//  <copyright file="UserRepository.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Data.Sql
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    using Microsoft.Extensions.Options;

    using NPoco;

    using Prism.DolphinsMemory.Server.Configuration;

    /// <summary>
    /// All methods to access to the user
    /// </summary>
    /// <seealso cref="Prism.DolphinsMemory.Server.Data.IUserRepository" />
    public class UserRepository : BaseSqlRepository, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="connectionStringsSettings">The connection strings settings.</param>
        public UserRepository(IOptions<ConnectionStrings> connectionStringsSettings)
            : base(connectionStringsSettings)
        {
        }

        /// <inheritdoc />
        public Guid GetUserId(string userName)
        {
            using (var db = this.GetDatabase())
            {
                return db.SingleOrDefault<Guid>("SELECT Id FROM [User] WHERE UserName = @userName", new { userName });
            }
        }
    }
}