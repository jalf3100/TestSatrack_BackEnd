//-----------------------------------------------------------------------
// <copyright file = "CategoryControllerTest.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace UnitTest.Satrack
{
    using Api.Satrack.Controllers;
    using Application.Satrack.Commons.Bases;
    using Application.Satrack.Dtos.Response;
    using Application.Satrack.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Utilities.Satrack.Statics;
    using Xunit;

    public class CategoryControllerTest
    {
        #region [Pruebas_ListSelectCategory]
        /// <summary>Prueba unitaria para el caso en que se devuelven resultados</summary>
        /// <returns>Una tarea que representa la operación asincrónica y el resultado de la prueba unitaria</returns>
        [Fact]
        public async Task ListSelectCategory_ReturnsOkResult()
        {
            // Arrange
            var mockCategoryApplication = new Mock<ICategoryApplication>();
            mockCategoryApplication.Setup(app => app.ListCategory())
                .ReturnsAsync(new BaseResponse<IEnumerable<CategoryResponseDto>>
                {
                    IsSuccess = true,
                    Data = new List<CategoryResponseDto>
                    {
                        new CategoryResponseDto { Id = 1, CategoryName = "Category_1" },
                        new CategoryResponseDto { Id = 2, CategoryName = "Category_2" }
                    },
                    Message = ReplyMessage.Message_Query
                });

            var controller = new CategoryController(mockCategoryApplication.Object);

            // Act
            var result = await controller.ListSelectCategory();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<IEnumerable<CategoryResponseDto>>>(okResult.Value);
            Assert.True(model.IsSuccess);
            Assert.Equal(2, model.Data.Count());
            Assert.Equal(ReplyMessage.Message_Query, model.Message);
        }
        /// <summary>Prueba unitaria para el caso en que no hay resultados disponibles</summary>
        /// <returns>Una tarea que representa la operación asincrónica y el resultado de la prueba unitaria</returns>
        [Fact]
        public async Task ListSelectCategory_ReturnsNotFoundResult()
        {
            // Arrange
            var mockCategoryApplication = new Mock<ICategoryApplication>();
            mockCategoryApplication.Setup(app => app.ListCategory())
                .ReturnsAsync(new BaseResponse<IEnumerable<CategoryResponseDto>>
                {
                    IsSuccess = false,
                    Message = ReplyMessage.Message_Query_Empty
                });

            var controller = new CategoryController(mockCategoryApplication.Object);

            // Act
            var result = await controller.ListSelectCategory();

            // Assert
            var notFoundResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<IEnumerable<CategoryResponseDto>>>(notFoundResult.Value);
            Assert.False(model.IsSuccess);
            Assert.Equal(ReplyMessage.Message_Query_Empty, model.Message);
        }
        #endregion [Pruebas_ListSelectCategory]
    }
}