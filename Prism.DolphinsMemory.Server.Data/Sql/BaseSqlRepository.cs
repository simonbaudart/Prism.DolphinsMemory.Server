// -----------------------------------------------------------------------
//  <copyright file="BaseSqlRepository.cs" company="Prism">
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
    /// Base class for all repository
    /// </summary>
    public abstract class BaseSqlRepository
    {
        /// <summary>
        /// The connection strings settings
        /// </summary>
        private readonly IOptions<ConnectionStrings> connectionStringsSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSqlRepository" /> class.
        /// </summary>
        /// <param name="connectionStringsSettings">The connection strings settings.</param>
        protected BaseSqlRepository(IOptions<ConnectionStrings> connectionStringsSettings)
        {
            this.connectionStringsSettings = connectionStringsSettings;
        }

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <returns>The Database</returns>
        protected Database GetDatabase()
        {
            return new Database(this.connectionStringsSettings.Value.DefaultConnection, DatabaseType.SqlServer2012, SqlClientFactory.Instance);
        }
    }
}