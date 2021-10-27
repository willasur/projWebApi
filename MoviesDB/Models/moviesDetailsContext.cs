using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoviesDB.Models
{
    public class MoviesDBContext : DbContext
    {
        public MoviesDBContext(DbContextOptions<MoviesDBContext> options)
            : base(options)
        {
        }

        public DbSet<movieDetails> MoviesDB { get; set; }

        public DbSet<TVShows> TVShowsDB { get; set; }
 
    }
}