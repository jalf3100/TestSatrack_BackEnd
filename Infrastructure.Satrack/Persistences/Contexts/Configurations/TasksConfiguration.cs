//-----------------------------------------------------------------------
// <copyright file = "TasksConfiguration.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Satrack.Persistences.Contexts.Configurations
{
    using Domain.Satrack.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>Clase de Mapeo para la entidad Tasks y sus respectivos campos</summary>
    public class TasksConfiguration : IEntityTypeConfiguration<Tasks>
    {
        #region [Methods]
        /// <summary>Método de configuración para la entidad Tasks y sus respectivos campos</summary>
        /// <param name="builder">Objeto para construir la Entidad Tasks</param>
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasKey(e => e.Id).HasName("PK__Tasks__7C6949B163A07542");

            builder.ToTable("Tasks", "dbo");

            builder.Property(e => e.Id).HasColumnName("TaskId");

            builder.Property(e => e.Id).HasComment("Clave primaria autoincremental para identificar de forma única cada tarea.");
            builder.Property(e => e.CategoryId).HasComment("Clave externa que referencia el \"CategoryId\" correspondiente en la tabla \"dbo.Categories\".");
            builder.Property(e => e.Deadline).HasComment("Almacena la fecha límite de la tarea.");
            builder.Property(e => e.IsCompleted).HasComment("Valor booleano para indicar si la tarea está completada o no.");
            builder.Property(e => e.TaskName)
                .HasMaxLength(255)
                .HasComment("Almacena el nombre de la tarea.");

            builder.HasOne(d => d.Category).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Tasks__CategoryI__300424B4");
        }
        #endregion [Methods]
    }
}