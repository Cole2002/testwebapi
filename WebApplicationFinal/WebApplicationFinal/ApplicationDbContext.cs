namespace WebApplicationFinal
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using WebApplicationFinal.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<BreakfastFood> BreakfastFoods { get; set; }
        public DbSet<FavoriteBook> FavoriteBooks { get; set; }

        internal object Entry(FavoriteBook favoriteBook)
        {
            throw new NotImplementedException();
        }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}


