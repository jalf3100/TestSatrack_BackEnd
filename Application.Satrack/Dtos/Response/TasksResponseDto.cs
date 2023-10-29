//-----------------------------------------------------------------------
// <copyright file = "TasksResponseDto.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Satrack.Dtos.Response
{
    /// <summary></summary>
    public partial class TasksResponseDto
    {
        /// <summary>Clave primaria autoincremental para identificar de forma única cada tarea.</summary>
        public int Id { get; set; }
        /// <summary>Almacena el nombre de la tarea.</summary>
        public string TaskName { get; set; } = null!;
        /// <summary>Clave externa que referencia el "CategoryId" correspondiente en la tabla "dbo.Categories".</summary>
        public int CategoryId { get; set; }
        /// <summary>Almacena el nombre de la categoría de tareas.</summary>
        public string CategoryName { get; set; } = null!;
        /// <summary>Almacena la fecha límite de la tarea.</summary>
        public DateTime Deadline { get; set; }
        /// <summary>Valor booleano para indicar si la tarea está completada o no.</summary>
        public bool IsCompleted { get; set; }
        /// <summary>Valor string para indicar si la tarea está completada o no.</summary>
        public string IsCompletedString { get; set; } = null!;
    }
}