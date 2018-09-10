// -----------------------------------------------------------------------
//  <copyright file="CatalogDomain.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Business.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Prism.DolphinsMemory.Server.Data;
    using Prism.DolphinsMemory.Server.Model;

    /// <summary>
    /// All methods for catalogs
    /// </summary>
    /// <seealso cref="Prism.DolphinsMemory.Server.Business.ICatalogDomain" />
    public class CatalogDomain : ICatalogDomain
    {
        /// <summary>
        /// The catalog repository
        /// </summary>
        private readonly ICatalogRepository catalogRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogDomain"/> class.
        /// </summary>
        /// <param name="catalogRepository">The catalog repository.</param>
        public CatalogDomain(ICatalogRepository catalogRepository)
        {
            this.catalogRepository = catalogRepository;
        }

        public void DeleteCatalog(Guid userId, Guid catalogId)
        {
            if (catalogId == default(Guid))
            {
                return;
            }

            if (!this.catalogRepository.IsMyCatalog(userId, catalogId))
            {
                return;
            }

            this.catalogRepository.DeleteCatalog(catalogId);
        }

        /// <inheritdoc />
        public List<Catalog> GetCatalogs(Guid userId)
        {
            return this.catalogRepository.GetCatalogs(userId);
        }

        /// <inheritdoc />
        public void UpsertCatalog(Guid userId, Catalog catalog)
        {
            if (catalog.Id != default(Guid))
            {
                if (!this.catalogRepository.IsMyCatalog(userId, catalog.Id))
                {
                    return;
                }
            }

            this.catalogRepository.UpsertCatalog(userId, catalog);
        }
    }
}