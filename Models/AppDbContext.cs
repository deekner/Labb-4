using Microsoft.EntityFrameworkCore;

namespace Labb_4.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Hobby> Hobbys { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Person
            modelBuilder.Entity<Person>().HasData(new Person { ID = 1, Name = "Dennis", Phone = "0743884618" });
            modelBuilder.Entity<Person>().HasData(new Person { ID = 2, Name = "John", Phone = "0742143245" });
            modelBuilder.Entity<Person>().HasData(new Person { ID = 3, Name = "King", Phone = "0743453447" });
            modelBuilder.Entity<Person>().HasData(new Person { ID = 4, Name = "Thomas", Phone = "0756756467" });
            modelBuilder.Entity<Person>().HasData(new Person { ID = 5, Name = "Igor", Phone = "0767456446" });
            modelBuilder.Entity<Person>().HasData(new Person { ID = 6, Name = "Affe", Phone = "0744564472" });
            modelBuilder.Entity<Person>().HasData(new Person { ID = 7, Name = "Vivien", Phone = "0713454565" });
            modelBuilder.Entity<Person>().HasData(new Person { ID = 8, Name = "Cecilia", Phone = "0746867285" });

            modelBuilder.Entity<Hobby>().HasData(new Hobby { ID = 1, HobbyName = "Cars", Description = "Loves to go to car meets as well as car shows" });
            modelBuilder.Entity<Hobby>().HasData(new Hobby { ID = 2, HobbyName = "Fishing", Description = "Nothing beats fishing with a nice summerbreeze" });
            modelBuilder.Entity<Hobby>().HasData(new Hobby { ID = 3, HobbyName = "Computers", Description = "There's something satisfying with building computers" });
            modelBuilder.Entity<Hobby>().HasData(new Hobby { ID = 4, HobbyName = "Books", Description = "What a way to relax when reading a book and earn knowledge" });

            modelBuilder.Entity<Link>().HasData(new Link { ID = 1, LinkName = "SchmiedMann", URL = "https://www.schmiedmann.se/", PersonID = 1, HobbyID = 1 });
            modelBuilder.Entity<Link>().HasData(new Link { ID = 2, LinkName = "Fiske", URL = "https://www.fiske.se/", PersonID = 2, HobbyID = 2 });
            modelBuilder.Entity<Link>().HasData(new Link { ID = 3, LinkName = "Komplett", URL = "https://www.komplett.se/", PersonID = 3, HobbyID = 3 });
            modelBuilder.Entity<Link>().HasData(new Link { ID = 4, LinkName = "AkademiBokHandeln", URL = "https://www.akademibokhandeln.se/", PersonID = 4, HobbyID = 4 });
            modelBuilder.Entity<Link>().HasData(new Link { ID = 5, LinkName = "SchmiedMann", URL = "https://www.schmiedmann.se/", PersonID = 5, HobbyID = 1 });
            modelBuilder.Entity<Link>().HasData(new Link { ID = 6, LinkName = "Fiske", URL = "https://www.fiske.se/", PersonID = 6, HobbyID = 2 });
            modelBuilder.Entity<Link>().HasData(new Link { ID = 7, LinkName = "Komplett", URL = "https://www.komplett.se/", PersonID = 7, HobbyID = 3 });
            modelBuilder.Entity<Link>().HasData(new Link { ID = 8, LinkName = "AkademiBokHandeln", URL = "https://www.akademibokhandeln.se/", PersonID = 8, HobbyID = 4 });


        }
    }
}
