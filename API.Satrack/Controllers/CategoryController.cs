//-----------------------------------------------------------------------
// <copyright file = "CategoryController.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Api.Satrack.Controllers
{
    using Application.Satrack.Commons.Bases;
    using Application.Satrack.Dtos.Response;
    using Application.Satrack.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>Controlador para obtener los datos de las diferentes Categorías</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region [Variables]
        /// <summary>Variable global de la Interfaz para poder acceder a los métodos de CategoryApplication</summary>
        private readonly ICategoryApplication _CategoryApplication;
        #endregion [Variables]

        #region [Constructor]
        /// <summary>Constructor del Controlador</summary>
        /// <param name="categoryApplication">Interfaz para poder acceder a los métodos de CategoryApplication</param>
        public CategoryController(ICategoryApplication categoryApplication)
        {
            _CategoryApplication = categoryApplication;
        }
        #endregion [Constructor]

        #region [Methods]
        /// <summary>Consultar el listado de todas las Categorías</summary>
        /// <returns>Listado de todas las categorías</returns>
        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectCategory()
        {
            BaseResponse<IEnumerable<CategoryResponseDto>> response = await _CategoryApplication.ListCategory();
            return Ok(response);
        }
        #endregion [Methods]
    }
}