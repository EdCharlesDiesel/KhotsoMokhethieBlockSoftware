using Microsoft.EntityFrameworkCore;
using Trains.API.Entities;

namespace Trains.API.Context
{
    public class TrainsDbContext: DbContext
     {
        public TrainsDbContext(DbContextOptions options) : base(options)
        {
        }     

        public DbSet<FileDetails> FileDetails { get; set; }
      
    }
}

