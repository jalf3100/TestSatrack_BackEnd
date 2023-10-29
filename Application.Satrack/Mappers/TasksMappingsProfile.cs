//-----------------------------------------------------------------------
// <copyright file = "TasksMappingsProfile.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Satrack.Mappers
{
    using Application.Satrack.Dtos.Request;
    using Application.Satrack.Dtos.Response;
    using AutoMapper;
    using Domain.Satrack.Entities;

    /// <summary>Clase para el Mapeo de la Clase Tasks y TasksResponseDto</summary>
    public class TasksMappingsProfile : Profile
    {
        #region [Constructor]
        /// <summary>Constructor para el Mapeo de la Clase Tasks y TasksResponseDto</summary>
        public TasksMappingsProfile()
        {

            CreateMap<Tasks, TasksResponseDto>().ReverseMap()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id));
            CreateMap<TasksRequestDto, Tasks>().ReverseMap();
        }
        #endregion [Constructor]
    }
}