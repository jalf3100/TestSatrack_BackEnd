//-----------------------------------------------------------------------
// <copyright file = "CategoryApplication.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Satrack.Services
{
    using Application.Satrack.Commons.Bases;
    using Application.Satrack.Dtos.Response;
    using Application.Satrack.Interfaces;
    using AutoMapper;
    using Domain.Satrack.Entities;
    using Infrestructure.Satrack.Persistences.Interfaces;
    using Utilities.Satrack.Statics;

    /// <summary>Clase para la entidad Category donde se manejan los diversos procesos</summary>
    public class CategoryApplication : ICategoryApplication
    {
        #region [Variables]
        /// <summary>Variable global de la Interfaz para poder acceder a los métodos de UnitOfWork</summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>Variable global de la Interfaz para poder acceder a los métodos de Mapper</summary>
        private readonly IMapper _mapper;
        #endregion [Variables]

        #region [Constructor]
        /// <summary>Constructor de la clase CategoryApplication</summary>
        /// <param name="unitOfWork">Interfaz para poder acceder a los métodos de UnitOfWork</param>
        /// <param name="mapper">Interfaz para poder acceder a los métodos de Mapper</param>
        public CategoryApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion [Constructor]

        #region [Methods]
        /// <summary>Consultar el listado de todas las Categorías</summary>
        /// <returns>Listado de todas las categorías</returns>
        public async Task<BaseResponse<IEnumerable<CategoryResponseDto>>> ListCategory()
        {
            BaseResponse<IEnumerable<CategoryResponseDto>> response = new BaseResponse<IEnumerable<CategoryResponseDto>>();
            IEnumerable<Category> Category = await _unitOfWork.Category.GetAllAsync();
            if (Category is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<CategoryResponseDto>>(Category);
                response.Message = ReplyMessage.Message_Query;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.Message_Query_Empty;
            }
            return response;
        }
        #endregion [Methods]
    }
}