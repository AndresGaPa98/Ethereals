using System;
using System.Collections.Generic;
using Scm.Domain;
using scm.Service;
using Scm.Data;
using Scm.Data.Repositories;
using Scm.Controllers.Dtos;
using AutoMapper;

namespace Scm.Service
{

    public class BoardService
    {   
        private BoardRepository _boardRepository;
        private UserRepository _userRepository;
        private ScmContext _context;
        private IMapper _mapper;
        public BoardService(ScmContext context, BoardRepository boardRepository, UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _boardRepository = boardRepository;
            _context = context;
            _mapper = mapper;
        }
        public ServiceResult<Board> getBoardById(int id){ ///FALTA RETORNO DE ERRORES
                Board vale = _boardRepository.GetById(id);
                var result = new ServiceResult<Board>();
                if(vale != null)
                {
                    result.isSuccess = true;
                    result.Result = vale;
                }
                else{
                    result.isSuccess = false;
                    result.Errors = new List<string>();
                    result.Errors.Add("No existe ninguno con ese id");
                }
                return result;
        }
        public ServiceResult<Board> Save(BoardRegisterDto model) 
        {
            //Creamos el tablero
            Board board = new Board{Status = 0, Grid = "-1,-1,-1,-1,-1,-1,-1,-1,-1"};
            board.Player1 = _userRepository.GetById(model.Player1Id);
            board.Player2 = _userRepository.GetById(model.Player2Id);
        
            //Turno Aleatorio
            List<AppUser> players = new List<AppUser>{board.Player1, board.Player2};
            Random rand = new Random();
            board.Turno = players[rand.Next(0,1)];

            //Respuesta
            var result = new ServiceResult<Board>();
            try {    
                _boardRepository.Insert(board); //Se registra la factura
                var affectedRows = _context.SaveChanges();
                if( affectedRows == 0) {
                    //Hubo un pex
                    result.isSuccess = false;
                    result.Errors = new List<string>();
                    result.Errors.Add("No se pudo guardar la factura");
                    return result;
                }
                else {                   
                    result.isSuccess = true;
                    result.Result = board;
                    return result;
                }
            }
            catch(Exception ex) //fix
            {
                result.isSuccess = false;
                result.Errors = new List<string>();
                result.Errors.Add("No se pudo guardar la factura.");
                Console.WriteLine(ex);
                return result;
            }
        }
    }
}