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
                    + "WHERE C.UserId = @userId AND Deleted = 0 "
                    + "GROUP BY C.Id, C.Name, C.Created, C.Updated "
                    + "ORDER BY C.Name",
                    new { userId });
            }
        }

        /// <inheritdoc />
        public bool IsMyCatalog(Guid userId, Guid catalogId)
        {
            using (var db = this.GetDatabase())
            {
                return db.Single<int>("SELECT COUNT(1) FROM Catalog WHERE UserId = @userId AND Id = @catalogId AND Deleted = 0", new { userId, catalogId }) != 0;
            }
        }

        /// <inheritdoc />
        public void UpsertCatalog(Guid userId, Catalog catalog)
        {
            using (var db = this.GetDatabase())
            {
                if (catalog.Id == default(Guid))
                {
                    catalog.Id = Guid.NewGuid();
                    catalog.Created = DateTime.UtcNow;
                    catalog.Updated = DateTime.UtcNow;

                    db.Execute(
                        "INSERT INTO Catalog (Id, UserId, Name, Created, Updated) VALUES (@id, @userId, @name, @created, @updated)",
                        new
                            {
                                id = catalog.Id,
                                userId,
                                name = catalog.Name,
                                created = catalog.Created,
                                updated = catalog.Updated
                            });
                }
                else
                {
                    catalog.Updated = DateTime.UtcNow;

                    db.Execute(
                        "UPDATE Catalog SET Name = @name, Updated = @updated WHERE Id = @id AND UserId = @userId",
                        new { id = catalog.Id, userId, name = catalog.Name, updated = catalog.Updated });
                }
            }
        }
    }
}