using DekstopTest.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DekstopTest.Server.Entities
{
	public class ClientContext: DbContext
	{
		private readonly IConfiguration _configuration;
        public ClientContext(IConfiguration configuration): base()
        {
            _configuration = configuration;
        }



        public DbSet<Course> Cursos { get; set; }
		public DbSet<Client> Clients { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ETLTest"));
			//optionsBuilder.UseSqlServer("Server={localhost};Database={TESTING_ETL};UserId={sa};Password={Testing123@};");
		}
	}
}
