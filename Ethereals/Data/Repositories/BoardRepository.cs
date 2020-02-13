using System.Collections.Generic;
using System.Linq;
using Scm.Domain;
using Microsoft.EntityFrameworkCore;

namespace Scm.Data.Repositories
{
    public class BoardRepository: BaseRepository<Board>
    {
        public BoardRepository(ScmContext context):base(context)
        {
          
        }
    }
}