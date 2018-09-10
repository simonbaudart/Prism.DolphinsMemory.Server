// -----------------------------------------------------------------------
//  <copyright file="Catalog.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represent a catalog
    /// </summary>
    [DataContract]
    public class Catalog
    {
        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember(Name = "name")]
        [Required]
        [MaxLength(8000)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the notes count.
        /// </summary>
        /// <value>
        /// The notes count.
        /// </value>
        [DataMember(Name = "notesCount")]
        public int NotesCount { get; set; }

        /// <summary>
        /// Gets or sets the updated.
        /// </summary>
        /// <value>
        /// The updated.
        /// </value>
        [DataMember(Name = "updated")]
        public DateTime Updated { get; set; }
    }
}