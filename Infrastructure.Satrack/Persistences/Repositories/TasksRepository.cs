//-----------------------------------------------------------------------
// <copyright file = "TasksRepository.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Satrack.Persistences.Repositories
{
    using Domain.Satrack.Entities;
    using Infrestructure.Satrack.Persistences.Contexts;
    using Infrestructure.Satrack.Persistences.Interfaces;

    /// <summary>Clase que implementa la lógica para operaciones de acceso a datos de la entidad Tasks</summary>
    public class TasksRepository : GenericRepository<Tasks>, ITasksRepository
    {
        #region [Constructor]
        /// <summary>Inicializa una nueva instancia de la clase TasksRepository</summary>
        /// <param name="context">El DbContext utilizado para acceder a las tasks</param>
        public TasksRepository(SatrackContext context) : base(context) { }
        #endregion [Constructor]
    }
}