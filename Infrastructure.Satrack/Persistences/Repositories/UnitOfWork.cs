//-----------------------------------------------------------------------
// <copyright file = "UnitOfWork.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Satrack.Persistences.Repositories
{
    using Infrestructure.Satrack.Persistences.Contexts;
    using Infrestructure.Satrack.Persistences.Interfaces;

    /// <summary>Clase que define la unidad de trabajo para manejar transacciones y operaciones relacionadas con múltiples entidades</summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region [Variables]
        /// <summary></summary>
        private readonly SatrackContext _context;
        /// <summary>Variable Global que representa el repositorio específico para Category</summary>
        public ICategoryRepository Category { get; set; }
        /// <summary>Variable Global que representa el repositorio específico para Tasks</summary>
        public ITasksRepository Tasks { get; set; }
        #endregion [Variables]

        #region [Constructor]
        /// <summary>Inicializa una nueva instancia de la clase UnitOfWork</summary>
        /// <param name="context">El DbContext utilizado para acceder a las entidades</param>
        public UnitOfWork(SatrackContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
            Tasks = new TasksRepository(_context);
        }
        #endregion [Constructor]

        #region [Methods]
        /// <summary>Libera los recursos no administrados utilizados por la clase UnitOfWork</summary>
        public void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>Guarda los cambios en la base de datos y confirma la transacción</summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>Guarda los cambios asincrónicamente en la base de datos y confirma la transacción</summary>
        /// <returns>Una tarea que representa la operación asincrónica</returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        #endregion [Methods]
    }
}