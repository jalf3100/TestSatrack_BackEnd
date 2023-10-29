//-----------------------------------------------------------------------
// <copyright file = "CategoryResponseDto.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Satrack.Dtos.Response
{
    /// <summary></summary>
    public partial class CategoryResponseDto
    {
        /// <summary>Clave primaria autoincremental para identificar de forma única cada categoría.</summary>
        public int Id { get; set; }

        /// <summary>Almacena el nombre de la categoría de tareas.</summary>
        public string CategoryName { get; set; } = null!;
    }
}