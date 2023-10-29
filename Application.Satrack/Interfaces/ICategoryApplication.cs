//-----------------------------------------------------------------------
// <copyright file = "ICategoryApplication.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Satrack.Interfaces
{
    using Application.Satrack.Commons.Bases;
    using Application.Satrack.Dtos.Response;

    /// <summary>Interfaz para la clase CategoryApplication</summary>
    public interface ICategoryApplication
    {
        #region [Methods]
        /// <summary>Consultar el listado de todas las Categorías</summary>
        /// <returns>Listado de todas las categorías</returns>
        Task<BaseResponse<IEnumerable<CategoryResponseDto>>> ListCategory();
        #endregion [Methods]
    }
}