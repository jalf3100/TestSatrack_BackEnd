//-----------------------------------------------------------------------
// <copyright file = "CategoryMappingsProfile.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Satrack.Mappers
{
    using Application.Satrack.Dtos.Response;
    using AutoMapper;
    using Domain.Satrack.Entities;

    /// <summary>Clase para el Mapeo de la Clase Category y CategoryResponseDto</summary>
    public class CategoryMappingsProfile : Profile
    {
        #region [Constructor]
        /// <summary>Constructor para el Mapeo de la Clase Category y CategoryResponseDto</summary>
        public CategoryMappingsProfile()
        {

            CreateMap<Category, CategoryResponseDto>().ReverseMap()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id));
        }
        #endregion [Constructor]
    }
}