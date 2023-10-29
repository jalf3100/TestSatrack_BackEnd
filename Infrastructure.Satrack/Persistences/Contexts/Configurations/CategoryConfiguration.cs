//-----------------------------------------------------------------------
// <copyright file = "CategoryConfiguration.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Satrack.Persistences.Contexts.Configurations
{
    using Domain.Satrack.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>Clase de Mapeo para la entidad Category y sus respectivos campos</summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        #region [Methods]
        /// <summary>Método de configuración para la entidad Category y sus respectivos campos</summary>
        /// <param name="builder">Objeto para construir la Entidad Category</param>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasKey(e => e.Id).HasName("PK__Categori__19093A0BFC7CAA31");

            builder.ToTable("Categories", "dbo");

            builder.Property(e => e.Id).HasColumnName("CategoryId");

            builder.Property(e => e.Id).HasComment("Clave primaria autoincremental para identificar de forma única cada categoría.");

            builder.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasComment("Almacena el nombre de la categoría de tareas.");
        }
        #endregion [Methods]
    }
}