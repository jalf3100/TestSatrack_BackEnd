//-----------------------------------------------------------------------
// <copyright file = "TasksController.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Api.Satrack.Controllers
{
    using Application.Satrack.Commons.Bases;
    using Application.Satrack.Dtos.Request;
    using Application.Satrack.Dtos.Response;
    using Application.Satrack.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>Controlador para obtener los datos de las diferentes Tareas</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        #region [Variables]
        /// <summary>Variable global de la Interfaz para poder acceder a los métodos de TasksApplication</summary>
        private readonly ITasksApplication _TasksApplication;
        #endregion [Variables]

        #region [Constructor]
        /// <summary>Constructor del Controlador</summary>
        /// <param name="tasksApplication">Interfaz para poder acceder a los métodos de TasksApplication</param>
        public TasksController(ITasksApplication tasksApplication)
        {
            _TasksApplication = tasksApplication;
        }
        #endregion [Constructor]

        #region [Methods]
        /// <summary>Consultar el listado de todas las Tareas</summary>
        /// <returns>Listado de todas las Tareas</returns>
        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectTasks()
        {
            BaseResponse<IEnumerable<TasksResponseDto>> response = await _TasksApplication.ListTasks();
            return Ok(response);
        }

        /// <summary>Consultar la tarea especifica según el Id enviado</summary>
        /// <param name="TasksId">Id de la Tarea que se requiere buscar</param>
        /// <returns>Tarea según el Id enviado</returns>
        [HttpGet("TasksById")]
        public async Task<IActionResult> TasksById(int TasksId)
        {
            BaseResponse<TasksResponseDto> response = await _TasksApplication.TasksById(TasksId);
            return Ok(response);
        }

        /// <summary>Registrar una tarea Nueva</summary>
        /// <param name="requestDto">Tarea a registrar</param>
        /// <returns>Retorna si fue creada o no</returns>
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterTasks([FromBody] TasksRequestDto requestDto)
        {
            BaseResponse<bool> response = await _TasksApplication.RegisterTasks(requestDto);
            return Ok(response);
        }

        /// <summary>Editar datos de una tarea</summary>
        /// <param name="requestDto">Tarea a Editar</param>
        /// <returns>Retorna si fue editada o no</returns>
        [HttpPut("Edit")]
        public async Task<IActionResult> EditTasks([FromBody] TasksRequestDto requestDto)
        {
            BaseResponse<bool> response = await _TasksApplication.EditTasks(requestDto.Id, requestDto);
            return Ok(response);
        }

        /// <summary>Eliminar una Tarea</summary>
        /// <param name="TasksId">Id de la tarea a eliminar</param>
        /// <returns>Retorna si fue eliminada o no</returns>
        [HttpPut("Remove")]
        public async Task<IActionResult> RemoveTasks(int TasksId)
        {
            BaseResponse<bool> response = await _TasksApplication.RemoveTasks(TasksId);
            return Ok(response);
        }
        #endregion [Methods]
    }
}