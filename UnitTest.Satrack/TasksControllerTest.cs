//-----------------------------------------------------------------------
// <copyright file = "TasksControllerTest.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace UnitTest.Satrack
{
    using Api.Satrack.Controllers;
    using Application.Satrack.Commons.Bases;
    using Application.Satrack.Dtos.Request;
    using Application.Satrack.Dtos.Response;
    using Application.Satrack.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Utilities.Satrack.Statics;
    using Xunit;

    public class TasksControllerTest
    {
        #region [Pruebas_ListSelectTasks]
        /// <summary>Prueba unitaria para el caso en que se devuelven resultados</summary>
        /// <returns>Una tarea que representa la operación asincrónica y el resultado de la prueba unitaria</returns>
        [Fact]
        public async Task ListSelectTasks_ReturnsOkResult()
        {
            // Arrange
            var mockTasksApplication = new Mock<ITasksApplication>();
            mockTasksApplication.Setup(app => app.ListTasks())
                .ReturnsAsync(new BaseResponse<IEnumerable<TasksResponseDto>>
                {
                    IsSuccess = true,
                    Data = new List<TasksResponseDto>
                    {
                        new TasksResponseDto { Id = 1, TaskName = "Hacer informe mensual", CategoryId=1,CategoryName = "Category_1", Deadline=new System.DateTime(), IsCompleted = false, IsCompletedString = ReplyMessage.No },
                        new TasksResponseDto { Id = 2, TaskName = "Completar proyecto de desarrollo", CategoryId=2,CategoryName = "Category_2", Deadline=new System.DateTime(), IsCompleted = false, IsCompletedString = ReplyMessage.No },
                    },
                    Message = ReplyMessage.Message_Query
                });

            var controller = new TasksController(mockTasksApplication.Object);

            // Act
            var result = await controller.ListSelectTasks();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<IEnumerable<TasksResponseDto>>>(okResult.Value);
            Assert.True(model.IsSuccess);
            Assert.Equal(2, model.Data.Count());
            Assert.Equal(ReplyMessage.Message_Query, model.Message);
        }
        /// <summary>Prueba unitaria para el caso en que no hay resultados disponibles</summary>
        /// <returns>Una tarea que representa la operación asincrónica y el resultado de la prueba unitaria</returns>
        [Fact]
        public async Task ListSelectTasks_ReturnsNotFoundResult()
        {
            // Arrange
            var mockTasksApplication = new Mock<ITasksApplication>();
            mockTasksApplication.Setup(app => app.ListTasks())
                .ReturnsAsync(new BaseResponse<IEnumerable<TasksResponseDto>>
                {
                    IsSuccess = false,
                    Message = ReplyMessage.Message_Query_Empty
                });

            var controller = new TasksController(mockTasksApplication.Object);

            // Act
            var result = await controller.ListSelectTasks();

            // Assert
            var notFoundResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<IEnumerable<TasksResponseDto>>>(notFoundResult.Value);
            Assert.False(model.IsSuccess);
            Assert.Equal(ReplyMessage.Message_Query_Empty, model.Message);
        }
        #endregion [Pruebas_ListSelectTasks]

        #region [Pruebas_TasksById]
        /// <summary>Prueba unitaria para el caso en que se devuelven resultados</summary>
        /// <returns>Una tarea que representa la operación asincrónica y el resultado de la prueba unitaria</returns>
        [Fact]
        public async Task TasksById_ReturnsOkResult()
        {
            // Arrange
            var mockTasksApplication = new Mock<ITasksApplication>();
            mockTasksApplication.Setup(app => app.TasksById(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<TasksResponseDto>
                {
                    IsSuccess = true,
                    Data = new TasksResponseDto
                    { Id = 1, TaskName = "Hacer informe mensual", CategoryId=1,CategoryName = "Category_1", Deadline=new System.DateTime(), IsCompleted = false, IsCompletedString = ReplyMessage.No },
                    Message = ReplyMessage.Message_Query
                });

            var controller = new TasksController(mockTasksApplication.Object);

            // Act
            var result = await controller.TasksById(new int());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<TasksResponseDto>>(okResult.Value);
            Assert.True(model.IsSuccess);
            Assert.Equal(ReplyMessage.Message_Query, model.Message);
        }
        /// <summary>Prueba unitaria para el caso en que no hay resultados disponibles</summary>
        /// <returns>Una tarea que representa la operación asincrónica y el resultado de la prueba unitaria</returns>
        [Fact]
        public async Task TasksById_ReturnsNotFoundResult()
        {
            // Arrange
            var mockTasksApplication = new Mock<ITasksApplication>();
            mockTasksApplication.Setup(app => app.TasksById(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<TasksResponseDto>
                {
                    IsSuccess = false,
                    Message = ReplyMessage.Message_Query_Empty
                });

            var controller = new TasksController(mockTasksApplication.Object);

            // Act
            var result = await controller.TasksById(new int());

            // Assert
            var notFoundResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<TasksResponseDto>>(notFoundResult.Value);
            Assert.False(model.IsSuccess);
            Assert.Equal(ReplyMessage.Message_Query_Empty, model.Message);
        }
        #endregion [Pruebas_TasksById]

        #region [Pruebas_RegisterTasks]
        /// <summary>Prueba unitaria para el caso en que se devuelven resultados</summary>
        /// <returns>Una tarea que representa la operación asincrónica y el resultado de la prueba unitaria</returns>
        [Fact]
        public async Task RegisterTasks_ReturnsOkResult()
        {
            // Arrange
            var mockTasksApplication = new Mock<ITasksApplication>();
            mockTasksApplication.Setup(app => app.RegisterTasks(It.IsAny<TasksRequestDto>()))
                .ReturnsAsync(new BaseResponse<bool>
                {
                    IsSuccess = true,
                    Data = true,
                    Message = ReplyMessage.Message_Save
                });

            var controller = new TasksController(mockTasksApplication.Object);

            // Act
            var result = await controller.RegisterTasks(new TasksRequestDto());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<bool>>(okResult.Value);
            Assert.True(model.IsSuccess);
            Assert.True(model.Data);
            Assert.Equal(ReplyMessage.Message_Save, model.Message);
        }
        /// <summary>Prueba unitaria para el caso en que se devuelven resultados</summary>
        /// <returns>Una tarea que representa la operación asincrónica y el resultado de la prueba unitaria</returns>
        [Fact]
        public async Task RegisterTasks_ReturnsBadRequestResult()
        {
            // Arrange
            var mockTasksApplication = new Mock<ITasksApplication>();
            mockTasksApplication.Setup(app => app.RegisterTasks(It.IsAny<TasksRequestDto>()))
                .ReturnsAsync(new BaseResponse<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = ReplyMessage.Message_Failed
                });

            var controller = new TasksController(mockTasksApplication.Object);

            // Act
            var result = await controller.RegisterTasks(new TasksRequestDto());

            // Assert
            var badRequestResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<bool>>(badRequestResult.Value);
            Assert.False(model.IsSuccess);
            Assert.False(model.Data);
            Assert.Equal(ReplyMessage.Message_Failed, model.Message);
        }
        #endregion [Pruebas_RegisterTasks]

        #region [Pruebas_EditTasks]
        /// <summary>Prueba unitaria para el caso en que se devuelven resultados</summary>
        /// <returns>Una tarea que representa la operación asincrónica y el resultado de la prueba unitaria</returns>
        [Fact]
        public async Task EditTasks_ReturnsOkResult()
        {
            // Arrange
            var mockTasksApplication = new Mock<ITasksApplication>();
            mockTasksApplication.Setup(app => app.EditTasks(It.IsAny<int>(), It.IsAny<TasksRequestDto>()))
                .ReturnsAsync(new BaseResponse<bool>
                {
                    IsSuccess = true,
                    Data = true,
                    Message = ReplyMessage.Message_Update
                });

            var controller = new TasksController(mockTasksApplication.Object);

            // Act
            var result = await controller.EditTasks(new TasksRequestDto());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<bool>>(okResult.Value);
            Assert.True(model.IsSuccess);
            Assert.True(model.Data);
            Assert.Equal(ReplyMessage.Message_Update, model.Message);
        }
        /// <summary>Prueba unitaria para el caso en que se devuelven resultados</summary>
        /// <returns>Una tarea que representa la operación asincrónica y el resultado de la prueba unitaria</returns>
        [Fact]
        public async Task EditTasks_ReturnsBadRequestResult()
        {
            // Arrange
            var mockTasksApplication = new Mock<ITasksApplication>();
            mockTasksApplication.Setup(app => app.EditTasks(It.IsAny<int>(), It.IsAny<TasksRequestDto>()))
                .ReturnsAsync(new BaseResponse<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = ReplyMessage.Message_Failed
                });

            var controller = new TasksController(mockTasksApplication.Object);

            // Act
            var result = await controller.EditTasks(new TasksRequestDto());

            // Assert
            var badRequestResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<bool>>(badRequestResult.Value);
            Assert.False(model.IsSuccess);
            Assert.False(model.Data);
            Assert.Equal(ReplyMessage.Message_Failed, model.Message);
        }
        /// <summary>Prueba unitaria para el caso en que se devuelven resultados</summary>
        /// <returns>Una tarea que representa la operación asincrónica y el resultado de la prueba unitaria</returns>
        [Fact]
        public async Task EditTasks_ReturnsQueryEmpty()
        {
            // Arrange
            var mockTasksApplication = new Mock<ITasksApplication>();
            mockTasksApplication.Setup(app => app.EditTasks(It.IsAny<int>(), It.IsAny<TasksRequestDto>()))
                .ReturnsAsync(new BaseResponse<bool>
                {
                    IsSuccess = false,
                    Message = ReplyMessage.Message_Query_Empty
                });

            var controller = new TasksController(mockTasksApplication.Object);

            // Act
            var result = await controller.EditTasks(new TasksRequestDto());

            // Assert
            var badRequestResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<bool>>(badRequestResult.Value);
            Assert.False(model.IsSuccess);
            Assert.Equal(ReplyMessage.Message_Query_Empty, model.Message);
        }
        #endregion [Pruebas_EditTasks]

        #region [Pruebas_RemoveTasks]
        /// <summary>Prueba unitaria para el caso en que se devuelven resultados</summary>
        /// <returns>Una tarea que representa la operación asincrónica y el resultado de la prueba unitaria</returns>
        [Fact]
        public async Task RemoveTasks_ReturnsOkResult()
        {
            // Arrange
            var mockTasksApplication = new Mock<ITasksApplication>();
            mockTasksApplication.Setup(app => app.RemoveTasks(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<bool>
                {
                    IsSuccess = true,
                    Data = true,
                    Message = ReplyMessage.Message_Update
                });

            var controller = new TasksController(mockTasksApplication.Object);

            // Act
            var result = await controller.RemoveTasks(new int());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<bool>>(okResult.Value);
            Assert.True(model.IsSuccess);
            Assert.True(model.Data);
            Assert.Equal(ReplyMessage.Message_Update, model.Message);
        }
        /// <summary>Prueba unitaria para el caso en que se devuelven resultados</summary>
        /// <returns>Una tarea que representa la operación asincrónica y el resultado de la prueba unitaria</returns>
        [Fact]
        public async Task RemoveTasks_ReturnsBadRequestResult()
        {
            // Arrange
            var mockTasksApplication = new Mock<ITasksApplication>();
            mockTasksApplication.Setup(app => app.RemoveTasks(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = ReplyMessage.Message_Failed
                });

            var controller = new TasksController(mockTasksApplication.Object);

            // Act
            var result = await controller.RemoveTasks(new int());

            // Assert
            var badRequestResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<bool>>(badRequestResult.Value);
            Assert.False(model.IsSuccess);
            Assert.False(model.Data);
            Assert.Equal(ReplyMessage.Message_Failed, model.Message);
        }
        /// <summary>Prueba unitaria para el caso en que se devuelven resultados</summary>
        /// <returns>Una tarea que representa la operación asincrónica y el resultado de la prueba unitaria</returns>
        [Fact]
        public async Task RemoveTasks_ReturnsQueryEmpty()
        {
            // Arrange
            var mockTasksApplication = new Mock<ITasksApplication>();
            mockTasksApplication.Setup(app => app.RemoveTasks(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<bool>
                {
                    IsSuccess = false,
                    Message = ReplyMessage.Message_Query_Empty
                });

            var controller = new TasksController(mockTasksApplication.Object);

            // Act
            var result = await controller.RemoveTasks(new int());

            // Assert
            var badRequestResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<bool>>(badRequestResult.Value);
            Assert.False(model.IsSuccess);
            Assert.Equal(ReplyMessage.Message_Query_Empty, model.Message);
        }
        #endregion [Pruebas_RemoveTasks]
    }
}