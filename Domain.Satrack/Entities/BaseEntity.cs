﻿//-----------------------------------------------------------------------
// <copyright file = "BaseEntity.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Domain.Satrack.Entities
{
    /// <summary>Entidad Base en la cuál se hereda el campo Id, que se incluye en las demás entidades</summary>
    public abstract class BaseEntity
    {
        /// <summary>Id de la Entidad que se mapea</summary>
        public int Id { get; set; }
    }
}