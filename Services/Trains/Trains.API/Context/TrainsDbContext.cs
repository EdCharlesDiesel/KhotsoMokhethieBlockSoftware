using Microsoft.EntityFrameworkCore;
using Trains.API.Entities;

namespace Trains.API.Context
{
    public class TrainsDbContext: DbContext
     {
        public TrainsDbContext(DbContextOptions options) : base(options)
        {
        }     

        public DbSet<Attachment> attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO Make sure we fix this
            modelBuilder.Entity<Attachment>();
            //.HasData{
            //    Attachment attachment = new Attachment();
            //}
        }
    }
}

