using System;
using System.Collections.Generic;
using Scm.Domain;
using scm.Service;
using Scm.Data;
using Scm.Data.Repositories;
using Scm.Controllers.Dtos;
using AutoMapper;

namespace Scm.Interfaces
{

    public interface IBoardService
    {   
        ServiceResult<Board> getBoardById(int id);
        ServiceResult<Board> Save(BoardRegisterDto model);
    }
}