//-----------------------------------------------------------------------
// <copyright file = "CategoryRepository.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Satrack.Persistences.Repositories
{
    using Domain.Satrack.Entities;
    using Infrestructure.Satrack.Persistences.Contexts;
    using Infrestructure.Satrack.Persistences.Interfaces;

    /// <summary>Clase que implementa la lógica para operaciones de acceso a datos de la entidad Category</summary>
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        #region [Constructor]
        /// <summary>Inicializa una nueva instancia de la clase CategoryRepository</summary>
        /// <param name="context">El DbContext utilizado para acceder a las categorías</param>
        public CategoryRepository(SatrackContext context) : base(context) { }
        #endregion [Constructor]
    }
}