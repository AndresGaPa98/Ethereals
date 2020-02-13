using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using scm.Service;
using Scm.Controllers;
using Scm.Controllers.Dtos;
using Scm.Domain;
using Scm.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Scm.Infrastructure.ManagedResponses;

namespace Ethereals.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void BoardService_AgregarTableroNormalmente()
        {
            var boardService = new Mock<IBoardService>();
            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<BoardDto,Board>(It.IsAny<BoardDto>())).Returns(new Board());
            
            // Arrange
            var controller = new BoardController(boardService.Object, mapper.Object);

            // Act
            BoardRegisterDto model = new BoardRegisterDto{Player1Id = "1", Player2Id = "2"};
            boardService.Setup(s => s.Save(model))
                .Returns(new ServiceResult<Board> {
                    isSuccess = true,
                    Errors = new List<string> {"Error"}
                }
            );

            // Assert
            IActionResult response = controller.Agregar(model);
            Console.WriteLine(response);
            Assert.AreEqual(response.GetType(), new OkObjectResult("").GetType());
        }
        [Test]
        public void BoardService_AgregarTableroConUnaIdFaltante()
        {
            var boardService = new Mock<IBoardService>();
            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<BoardDto,Board>(It.IsAny<BoardDto>())).Returns(new Board());
            
            // Arrange
            var controller = new BoardController(boardService.Object, mapper.Object);

            // Act
            BoardRegisterDto model = new BoardRegisterDto{Player1Id = "1", Player2Id = ""};
            boardService.Setup(s => s.Save(model))
                .Returns(new ServiceResult<Board> {
                    isSuccess = true,
                    Errors = new List<string> {"Error"}
                }
            );

            // Assert
            IActionResult response = controller.Agregar(model);
            Console.WriteLine(response);
            Assert.AreEqual(response.GetType(), new BadRequestObjectResult("").GetType());
        }
    }
}