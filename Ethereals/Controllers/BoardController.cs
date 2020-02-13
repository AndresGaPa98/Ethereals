using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scm.Domain;
using Scm.Data;
using Scm.Controllers.Dtos;
using Scm.Data.Repositories;
using AutoMapper;
using System.Security.Claims;
using Scm.Infrastructure.ManagedResponses;
using Scm.Service;
using Scm.Interfaces;

namespace Scm.Controllers
{
    [ApiController]    
    [Route("api/[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService boardService;
        private IMapper _mapper;
        private ScmContext _context;
        public BoardController(IBoardService _boardService, IMapper mapper)
        {
            boardService = _boardService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Agregar([FromBody] BoardRegisterDto model){ //Dto

            try {
                //Si falta una id, evitar el insertar
                if(model.Player1Id.Length < 1 || model.Player2Id.Length < 1)
                    return BadRequest("Faltan Datos");

                var boardResult = boardService.Save(model);
                if (boardResult.isSuccess) {
                    return Ok(_mapper.Map<BoardDto>(boardResult.Result));
                }
                else{
                    return BadRequest(boardResult.Errors);
                }
            }
            catch(Exception ex){
                var errorResponse = 
                new ManagedErrorResponse(ManagedErrorCode.Exception,"hay errores",ex);
                return BadRequest("Error");
            }
        }
        
        [HttpGet]
        public IActionResult Obtener(int id){ //Dto

            try {
                var boardResult = boardService.getBoardById(id);
                if (boardResult.isSuccess) {
                    return Ok(boardResult.Result);
                }
                else{
                    return BadRequest(boardResult.Errors);
                }
            }
            catch(Exception ex){
                var errorResponse = 
                new ManagedErrorResponse(ManagedErrorCode.Exception,"hay errores",ex);
                return BadRequest(errorResponse);
            }
        }
    }
}
