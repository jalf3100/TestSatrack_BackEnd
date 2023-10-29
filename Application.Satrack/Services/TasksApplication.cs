//-----------------------------------------------------------------------
// <copyright file = "TasksApplication.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Satrack.Services
{
    using Application.Satrack.Commons.Bases;
    using Application.Satrack.Dtos.Request;
    using Application.Satrack.Dtos.Response;
    using Application.Satrack.Interfaces;
    using AutoMapper;
    using Domain.Satrack.Entities;
    using Infrestructure.Satrack.Persistences.Interfaces;
    using Utilities.Satrack.Statics;

    /// <summary>Clase para la entidad Tasks donde se manejan los diversos procesos</summary>
    public class TasksApplication : ITasksApplication
    {
        #region [Variables]
        /// <summary>Variable global de la Interfaz para poder acceder a los métodos de UnitOfWork</summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>Variable global de la Interfaz para poder acceder a los métodos de Mapper</summary>
        private readonly IMapper _mapper;
        #endregion [Variables]

        #region [Constructor]
        /// <summary>Constructor de la clase TasksApplication</summary>
        /// <param name="unitOfWork">Interfaz para poder acceder a los métodos de UnitOfWork<</param>
        /// <param name="mapper">Interfaz para poder acceder a los métodos de Mapper</param>
        public TasksApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion [Constructor]

        #region [Methods]
        /// <summary>Consultar el listado de todas las Tareas</summary>
        /// <returns>Listado de todas las Tareas</returns>
        public async Task<BaseResponse<IEnumerable<TasksResponseDto>>> ListTasks()
        {
            BaseResponse<IEnumerable<TasksResponseDto>> response = new BaseResponse<IEnumerable<TasksResponseDto>>();
            IEnumerable<Tasks> Tasks = await _unitOfWork.Tasks.GetAllAsync();
            if (Tasks is not null)
            {
                response.IsSuccess = true;
                response.Data = AsignarValoresFaltantes(_mapper.Map<IEnumerable<TasksResponseDto>>(Tasks).ToList());
                response.Message = ReplyMessage.Message_Query;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.Message_Query_Empty;
            }
            return response;
        }

        /// <summary>Consultar la tarea especifica según el Id enviado</summary>
        /// <param name="TasksId">Id de la Tarea que se requiere buscar</param>
        /// <returns>Tarea según el Id enviado</returns>
        public async Task<BaseResponse<TasksResponseDto>> TasksById(int TasksId)
        {
            BaseResponse<TasksResponseDto> response = new BaseResponse<TasksResponseDto>();
            Tasks Taskss = await _unitOfWork.Tasks.GetByIdAsync(TasksId);
            if (Taskss is not null)
            {
                response.IsSuccess = true;
                response.Data = AsignarValoresFaltantes(_mapper.Map<TasksResponseDto>(Taskss));
                response.Message = ReplyMessage.Message_Query;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.Message_Query_Empty;
            }
            return response;
        }

        /// <summary>Registrar una tarea Nueva</summary>
        /// <param name="requestDto">Tarea a registrar</param>
        /// <returns>Retorna si fue creada o no</returns>
        public async Task<BaseResponse<bool>> RegisterTasks(TasksRequestDto requestDto)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();
            Tasks Tasks = _mapper.Map<Tasks>(requestDto);
            response.Data = await _unitOfWork.Tasks.RegisterAsync(Tasks);
            if (response.Data)
            {
                response.IsSuccess = response.Data;
                response.Message = ReplyMessage.Message_Save;
            }
            else
            {
                response.IsSuccess = response.Data;
                response.Message = ReplyMessage.Message_Failed;
            }
            return response;
        }

        /// <summary>Editar datos de una tarea</summary>
        /// <param name="TasksId">Id de la Tarea que se requiere editar</param>
        /// <param name="requestDto">Tarea a Editar</param>
        /// <returns>Retorna si fue editada o no</returns>
        public async Task<BaseResponse<bool>> EditTasks(int TasksId, TasksRequestDto requestDto)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();
            BaseResponse<TasksResponseDto> TasksEdit = await TasksById(TasksId);
            if (TasksEdit.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.Message_Query_Empty;
                return response;
            }
            Tasks Tasks = _mapper.Map<Tasks>(requestDto);
            Tasks.Id = TasksId;
            response.Data = await _unitOfWork.Tasks.EditAsync(Tasks);
            if (response.Data)
            {
                response.IsSuccess = response.Data;
                response.Message = ReplyMessage.Message_Update;
            }
            else
            {
                response.IsSuccess = response.Data;
                response.Message = ReplyMessage.Message_Failed;
            }
            return response;
        }

        /// <summary>Eliminar una Tarea</summary>
        /// <param name="TasksId">Id de la tarea a eliminar</param>
        /// <returns>Retorna si fue eliminada o no</returns>
        public async Task<BaseResponse<bool>> RemoveTasks(int TasksId)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();
            BaseResponse<TasksResponseDto> Tasks = await TasksById(TasksId);
            if (Tasks.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.Message_Query_Empty;
                return response;
            }
            response.Data = await _unitOfWork.Tasks.RemoveAsync(TasksId);
            if (response.Data)
            {
                response.IsSuccess = response.Data;
                response.Message = ReplyMessage.Message_Delete;
            }
            else
            {
                response.IsSuccess = response.Data;
                response.Message = ReplyMessage.Message_Failed;
            }
            return response;
        }
        /// <summary>Método que realiza el mapeo de los nuevos campos</summary>
        /// <param name="lstTasksResponseDto">Listado a asignar los nuevos campos</param>
        /// <returns>Lista con los nuevos campos asignados</returns>
        private List<TasksResponseDto> AsignarValoresFaltantes(List<TasksResponseDto> lstTasksResponseDto)
        {
            lstTasksResponseDto.ForEach(x => x.CategoryName = _unitOfWork.Category.GetByIdAsync(x.CategoryId).Result.CategoryName);
            lstTasksResponseDto.ForEach(x => x.IsCompletedString = (x.IsCompleted ? ReplyMessage.Yes : ReplyMessage.No));
            return lstTasksResponseDto;
        }
        /// <summary>Polimorfismo - Método que realiza el mapeo de los nuevos campos</summary>
        /// <param name="tasksResponseDto">Objeto a asignar los nuevos campos</param>
        /// <returns>Objeto con los nuevos campos asignados</returns>
        private TasksResponseDto AsignarValoresFaltantes(TasksResponseDto tasksResponseDto)
        {
            tasksResponseDto.CategoryName = _unitOfWork.Category.GetByIdAsync(tasksResponseDto.CategoryId).Result.CategoryName;
            tasksResponseDto.IsCompletedString = tasksResponseDto.IsCompleted ? ReplyMessage.Yes : ReplyMessage.No;
            return tasksResponseDto;
        }
        #endregion [Methods]
    }
}