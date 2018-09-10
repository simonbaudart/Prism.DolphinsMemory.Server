// -----------------------------------------------------------------------
//  <copyright file="CatalogRepository.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Data.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Extensions.Options;

    using Prism.DolphinsMemory.Server.Configuration;
    using Prism.DolphinsMemory.Server.Model;

    /// <summary>
    /// Manage catalog storage
    /// </summary>
    /// <seealso cref="Prism.DolphinsMemory.Server.Data.Sql.BaseSqlRepository" />
    /// <seealso cref="Prism.DolphinsMemory.Server.Data.ICatalogRepository" />
    public class CatalogRepository : BaseSqlRepository, ICatalogRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogRepository" /> class.
        /// </summary>
        /// <param name="connectionStringsSettings">The connection strings settings.</param>
        public CatalogRepository(IOptions<ConnectionStrings> connectionStringsSettings)
            : base(connectionStringsSettings)
        {
        }

        /// <inheritdoc />
        public List<Catalog> GetCatalogs(Guid userId)
        {
            using (var db = this.GetDatabase())
            {
                return db.Fetch<Catalog>(
                    "SELECT C.Id, C.Name, C.Created, C.Updated, COUNT(N.Id) AS NotesCount "
                    + "FROM Catalog C LEFT JOIN Note N ON N.CatalogId = C.Id "
                    + "WHERE C.UserId = @userId "
                    + "GROUP BY C.Id, C.Name, C.Created, C.Updated "
                    + "ORDER BY C.Name",
                    new { userId });
            }
        }
    }
}