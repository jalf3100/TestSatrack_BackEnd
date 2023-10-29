//-----------------------------------------------------------------------
// <copyright file = "SatrackContext.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
using Domain.Satrack.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrestructure.Satrack.Persistences.Contexts
{
    /// <summary>Representa el contexto de la base de datos para la aplicación</summary>
    public partial class SatrackContext : DbContext
    {
        #region [Variables]
        /// <summary>Variable para poder realizar conexión con la entidad Category</summary>
        public virtual DbSet<Category> Categories { get; set; }
        /// <summary>Variable para poder realizar conexión con la entidad Tasks</summary>
        public virtual DbSet<Tasks> Taskes { get; set; }
        #endregion [Variables]

        #region [Constructor]
        /// <summary>Constructor de la Clase para la Conexión</summary>
        public SatrackContext()
        {
        }

        /// <summary>Constructor de la Clase para la Conexión</summary>
        /// <param name="options">Opciones para la configuración del contexto de la base de datos</param>
        public SatrackContext(DbContextOptions<SatrackContext> options)
            : base(options)
        {
        }
        #endregion [Constructor]

        #region [Methods]
        /// <summary>Configura el modelo de datos que se utilizará para mapear las entidades a la base de datos</summary>
        /// <param name="modelBuilder">Constructor de modelos utilizado para configurar las entidades y relaciones</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            OnModelCreatingPartial(modelBuilder);
        }

        /// <summary>Método parcial que permite implementaciones personalizadas en archivos separados para configuraciones adicionales del modelo</summary>
        /// <param name="modelBuilder">Constructor de modelos utilizado para configurar las entidades y relaciones</param>
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion [Methods]
    }
}