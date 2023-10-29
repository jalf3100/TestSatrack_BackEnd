//-----------------------------------------------------------------------
// <copyright file = "ICategoryRepository.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Satrack.Persistences.Interfaces
{
    using Domain.Satrack.Entities;

    /// <summary>Interfaz que define las operaciones básicas para un repositorio de Category</summary>
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}