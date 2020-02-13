using IdentityServer4.EntityFramework.Options;
using Scm.Domain;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Scm.Data
{
    public class ScmContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public DbSet<Board> Boards {get; set;}
        public DbSet<Room> Rooms {get; set;}
        public ScmContext(DbContextOptions<ScmContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //put mappings database here
           /* builder.Entity<Board>(x => {
                x.HasKey(x=>x.BoardId);
                x.Property(x=>x.Player1).IsRequired();
                x.Property(x=>x.Player2).IsRequired();
                x.Property(x=>x.Status).IsRequired();
                x.Property(x=>x.Turno).IsRequired();
                x.Property(x=>x.Grid).HasMaxLength(350);
            });
            builder.Entity<Room>(x => {
                x.HasKey(x=>x.BoardId);
                x.Property(x=>x.Player1).IsRequired();
                x.Property(x=>x.Player2).IsRequired();
                x.Property(x=>x.Board).IsRequired();
            });*/

            base.OnModelCreating(builder);
        }
    }
}