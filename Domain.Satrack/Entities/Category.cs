//-----------------------------------------------------------------------
// <copyright file = "Category.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Domain.Satrack.Entities;
public partial class Category : BaseEntity
{
    /// <summary>
    /// Almacena el nombre de la categoría de tareas.
    /// </summary>
    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Tasks> Tasks { get; } = new List<Tasks>();
}