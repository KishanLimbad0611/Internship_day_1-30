using Microsoft.EntityFrameworkCore;
using PublisherDomain;
namespace PublisherData
{
    public class PubContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Cover> Covers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubDatabase2"
             );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 2, FirstName = "Deep", LastName = "Mewada" });
            var authorList = new Author[]
            {
                new Author { AuthorId = 3, FirstName = "Pratik", LastName = "Malaviya"},
                new Author { AuthorId = 4, FirstName = "Jatin", LastName = "Solanki"},
                new Author { AuthorId = 5, FirstName = "Mihir", LastName = "Vyas"},
                new Author { AuthorId = 6, FirstName = "Kishan", LastName = "Limbad"},
            };
            modelBuilder.Entity<Author>().HasData(authorList);

            var someBooks = new Book[]
            {
                new Book {BookId = 1, AuthorId = 5, Title = "New Book1" , PublishDate = new DateTime(1989,3,1) },
                new Book {BookId = 2, AuthorId = 4, Title = "New Book2" , PublishDate = new DateTime(1999,1,3) },
                new Book {BookId = 3, AuthorId = 3, Title = "New Book3" , PublishDate = new DateTime(2009,2,3) }
            };
            modelBuilder.Entity<Book>().HasData(someBooks);

            var someArtists = new Artist[]
            {
                new Artist {ArtistId = 1,FirstName = "Pablo", LastName = "Picasso"},
                new Artist {ArtistId = 2,FirstName = "Dee", LastName = "Bell"},
                new Artist {ArtistId = 3, FirstName = "Kartharine", LastName = "Kuharic"}
            };
            modelBuilder.Entity<Artist>().HasData(someArtists);

            var someCovers = new Cover[]
            {
                new Cover {CoverId = 1,BookId = 3,DesignIdeas = "How about a left hand in the dark?",DigitalOnly= false},
                new Cover {CoverId = 2,BookId = 2,DesignIdeas = "Should we put a clock?", DigitalOnly = true},
                new Cover {CoverId = 3,BookId = 1,DesignIdeas =  "A big ear in cloud ", DigitalOnly = false} };
            modelBuilder.Entity<Cover>().HasData(someCovers); 
        }
    }
}  