using cinema.Model;
using Microsoft.EntityFrameworkCore;

namespace cinema.data
{
    public class ApplicationDbContext :DbContext
    { 
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override  void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cinema;Integrated Security=True");
        }
        public DbSet<FilmDTO> FilmDTOs { get; set; }
        public DbSet<positionDTO> positionDTOs { get; set; }
      public  DbSet<salleDTO> salleDTOs { get; set;}
        public DbSet<Client> clients { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Planification> planifications { get; set; }
        public DbSet<ReservationDTO> reservationDTOs { get; set;} 
        public DbSet<cinema.Model.userDTO>? userDTO { get; set; }
        public DbSet<Date>? Date { get; set; }
    }
}
