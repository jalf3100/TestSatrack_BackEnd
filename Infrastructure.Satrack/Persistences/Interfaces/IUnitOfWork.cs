//-----------------------------------------------------------------------
// <copyright file = "IUnitOfWork.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Satrack.Persistences.Interfaces
{
    /// <summary>Interfaz que define la unidad de trabajo para manejar transacciones y operaciones relacionadas con múltiples entidades</summary>
    public interface IUnitOfWork : IDisposable
    {
        #region [Methods]
        /// <summary>Obtiene el repositorio específico para Category</summary>
        ICategoryRepository Category { get; }
        /// <summary>Obtiene el repositorio específico para Tasks</summary>
        ITasksRepository Tasks { get; }
        /// <summary>Guarda los cambios en la base de datos y confirma la transacción</summary>
        void SaveChanges();
        /// <summary>Guarda los cambios asincrónicamente en la base de datos y confirma la transacción</summary>
        Task SaveChangesAsync();
        #endregion [Methods]
    }
}