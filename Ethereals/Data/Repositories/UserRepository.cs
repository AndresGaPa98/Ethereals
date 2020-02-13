using System.Collections.Generic;
using System.Linq;
using Scm.Domain;
using Microsoft.EntityFrameworkCore;

namespace Scm.Data.Repositories
{
    public class UserRepository: BaseRepository<AppUser>
    {
        public UserRepository(ScmContext context):base(context)
        {
          
        }
    }
}