//-----------------------------------------------------------------------
// <copyright file = "ITasksApplication.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Satrack.Interfaces
{
    using Application.Satrack.Commons.Bases;
    using Application.Satrack.Dtos.Request;
    using Application.Satrack.Dtos.Response;

    /// <summary>Interfaz para la clase TasksApplication</summary>
    public interface ITasksApplication
    {
        #region [Methods]
        /// <summary>Consultar el listado de todas las Tareas</summary>
        /// <returns>Listado de todas las Tareas</returns>
        Task<BaseResponse<IEnumerable<TasksResponseDto>>> ListTasks();
        //Task<BaseResponse<List<TasksResponseDto>>> ListTasks();
        /// <summary>Consultar la tarea especifica según el Id enviado</summary>
        /// <param name="TasksId">Id de la Tarea que se requiere buscar</param>
        /// <returns>Tarea según el Id enviado</returns>
        Task<BaseResponse<TasksResponseDto>> TasksById(int TasksId);
        /// <summary>Registrar una tarea Nueva</summary>
        /// <param name="requestDto">Tarea a registrar</param>
        /// <returns>Retorna si fue creada o no</returns>
        Task<BaseResponse<bool>> RegisterTasks(TasksRequestDto requestDto);
        /// <summary>Editar datos de una tarea</summary>
        /// <param name="TasksId">Id de la Tarea que se requiere editar</param>
        /// <param name="requestDto">Tarea a Editar</param>
        /// <returns>Retorna si fue editada o no</returns>
        Task<BaseResponse<bool>> EditTasks(int TasksId, TasksRequestDto requestDto);
        /// <summary>Eliminar una Tarea</summary>
        /// <param name="TasksId">Id de la tarea a eliminar</param>
        /// <returns>Retorna si fue eliminada o no</returns>
        Task<BaseResponse<bool>> RemoveTasks(int TasksId);
        #endregion [Methods]
    }
}