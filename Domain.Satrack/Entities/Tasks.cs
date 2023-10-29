//-----------------------------------------------------------------------
// <copyright file = "Tasks.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Domain.Satrack.Entities;
public partial class Tasks : BaseEntity
{
    /// <summary>Almacena el nombre de la tarea.</summary>
    public string TaskName { get; set; } = null!;

    /// <summary>Clave externa que referencia el "CategoryId" correspondiente en la tabla "dbo.Categories".</summary>
    public int? CategoryId { get; set; }

    /// <summary>Almacena la fecha límite de la tarea.</summary>
    public DateTime? Deadline { get; set; }

    /// <summary>Valor booleano para indicar si la tarea está completada o no.</summary>
    public bool? IsCompleted { get; set; }

    public virtual Category? Category { get; set; }
}