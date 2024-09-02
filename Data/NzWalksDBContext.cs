
using Microsoft.EntityFrameworkCore;
using apiNZWalks.Models.Domain;
namespace apiNZWalks.Data
{
	public class NzWalksDBContext : DbContext
	{
		public NzWalksDBContext(DbContextOptions dboptions):base(dboptions)
		{
				
		}
		public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}

