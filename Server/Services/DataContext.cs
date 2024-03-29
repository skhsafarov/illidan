using Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Services
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration configuration_;

        static DataContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DataContext(IConfiguration configuration)
        {

            configuration_ = configuration;
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(configuration_.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.User>().HasData(
                new User { Id = 1, FirstName =  "John", LastName = "Doe", Role = "Admin", Phone = "+79123456789" },
                new User { Id = 2, FirstName =  "Jane", LastName = "Smith", Role = "User", Phone = "+79012345678" },
                new User { Id = 3, FirstName =  "Alex", LastName = "Johnson", Role = "User", Phone = "+79123456780" },
                new User { Id = 4, FirstName =  "Sarah", LastName = "Williams", Role = "User", Phone = "+79012345670" },
                new User { Id = 5, FirstName =  "Michael", LastName = "Brown", Role = "User", Phone = "+79123456760" },
                new User { Id = 6, FirstName =  "Emily", LastName = "Davis", Role = "User", Phone = "+79012345650" },
                new User { Id = 7, FirstName =  "David", LastName = "Miller", Role = "User", Phone = "+79123456740" },
                new User { Id = 8, FirstName =  "Emma", LastName = "Anderson", Role = "User", Phone = "+79012345630" },
                new User { Id = 9, FirstName =  "Daniel", LastName = "Wilson", Role = "User", Phone = "+79123456720" },
                new User { Id = 10, FirstName =  "Olivia", LastName = "Taylor", Role = "User", Phone = "+79012345610" }
                );

            modelBuilder.Entity<Models.Queue>().HasData(
                new Queue { Id = 1, OwnerId = 1, Name = "Стоматолог", ImageLink = "https://is4-ssl.mzstatic.com/image/thumb/Purple113/v4/c6/87/aa/c687aa88-9688-1d00-b150-af95049dcf6b/pr_source.png/643x0w.jpg", Count = 0, LastAnimal = 0, LastColor = 0 },
                new Queue { Id = 2, OwnerId = 2, Name = "Фитнес", ImageLink = "https://example.com/fitnes.jpg", Count = 0, LastAnimal = 0, LastColor = 0 },
                new Queue { Id = 3, OwnerId = 3, Name = "Парикмахерская", ImageLink = "https://example.com/parikmaherskaya.jpg", Count = 0, LastAnimal = 0, LastColor = 0 },
                new Queue { Id = 4, OwnerId = 4, Name = "Кафе", ImageLink = "https://example.com/cafe.jpg", Count = 0, LastAnimal = 0, LastColor = 0 },
                new Queue { Id = 5, OwnerId = 5, Name = "Автосервис", ImageLink = "https://example.com/autoservice.jpg", Count = 0, LastAnimal = 0, LastColor = 0 },
                new Queue { Id = 6, OwnerId = 6, Name = "Магазин", ImageLink = "https://example.com/shop.jpg", Count = 0, LastAnimal = 0, LastColor = 0 },
                new Queue { Id = 7, OwnerId = 7, Name = "Банк", ImageLink = "https://example.com/bank.jpg", Count = 0, LastAnimal = 0, LastColor = 0 },
                new Queue { Id = 8, OwnerId = 8, Name = "Аптека", ImageLink = "https://example.com/pharmacy.jpg", Count = 0, LastAnimal = 0, LastColor = 0 },
                new Queue { Id = 9, OwnerId = 9, Name = "Театр", ImageLink = "https://example.com/theater.jpg", Count = 0, LastAnimal = 0, LastColor = 0 },
                new Queue { Id = 10, OwnerId = 10, Name = "Почта", ImageLink = "https://example.com/post.jpg", Count = 0, LastAnimal = 0, LastColor = 0 }
                );
            modelBuilder.Entity<Models.QueueToken>().HasData(
                new QueueToken { Id = 1, OwnerId = 1, QueueId = 1, Animal = 0, Color = 0 },
                new QueueToken { Id = 2, OwnerId = 2, QueueId = 1, Animal = 1, Color = 1 },
                new QueueToken { Id = 3, OwnerId = 3, QueueId = 1, Animal = 2, Color = 2 },
                new QueueToken { Id = 4, OwnerId = 4, QueueId = 1, Animal = 3, Color = 3 },
                new QueueToken { Id = 5, OwnerId = 5, QueueId = 2, Animal = 4, Color = 4 },
                new QueueToken { Id = 6, OwnerId = 6, QueueId = 2, Animal = 5, Color = 5 },
                new QueueToken { Id = 7, OwnerId = 7, QueueId = 2, Animal = 6, Color = 6 },
                new QueueToken { Id = 8, OwnerId = 8, QueueId = 3, Animal = 7, Color = 7 },
                new QueueToken { Id = 9, OwnerId = 9, QueueId = 3, Animal = 8, Color = 8 },
                new QueueToken { Id = 10, OwnerId = 10, QueueId = 3, Animal = 9, Color = 9 },
                new QueueToken { Id = 11, OwnerId = 1, QueueId = 3, Animal = 10, Color = 10 },
                new QueueToken { Id = 12, OwnerId = 2, QueueId = 3, Animal = 11, Color = 0 },
                new QueueToken { Id = 13, OwnerId = 3, QueueId = 4, Animal = 12, Color = 1 },
                new QueueToken { Id = 14, OwnerId = 4, QueueId = 5, Animal = 13, Color = 2 },
                new QueueToken { Id = 15, OwnerId = 5, QueueId = 7, Animal = 14, Color = 3 },
                new QueueToken { Id = 16, OwnerId = 6, QueueId = 8, Animal = 15, Color = 4 },
                new QueueToken { Id = 17, OwnerId = 7, QueueId = 9, Animal = 16, Color = 5 },
                new QueueToken { Id = 18, OwnerId = 8, QueueId = 9, Animal = 17, Color = 6 },
                new QueueToken { Id = 19, OwnerId = 9, QueueId = 10, Animal = 18, Color = 7 },
                new QueueToken { Id = 20, OwnerId = 10, QueueId = 10, Animal = 19, Color = 8 }
                );
            modelBuilder.Entity<Bid>().HasData(
                new Bid { Id = 1, OwnerId = 1, СounteragentId = 2, FromCurrency = "RUB", ToCurrency = "UZS", OwnedAmount = 1000, RequiredAmount = 150000, OwnerDestinationCard = "1234567890123456", СounteragentDestinationCard = "9876543210987654", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Active" },
                new Bid { Id = 2, OwnerId = 2, СounteragentId = 1, FromCurrency = "UZS", ToCurrency = "RUB", OwnedAmount = 200000, RequiredAmount = 2000, OwnerDestinationCard = "9876543210987654", СounteragentDestinationCard = "1234567890123456", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Active" },
                new Bid { Id = 3, OwnerId = 3, СounteragentId = null, FromCurrency = "RUB", ToCurrency = "UZS", OwnedAmount = 500, RequiredAmount = 75000, OwnerDestinationCard = "2345678901234567", СounteragentDestinationCard = null, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Active" },
                new Bid { Id = 4, OwnerId = 4, СounteragentId = 5, FromCurrency = "RUB", ToCurrency = "UZS", OwnedAmount = 3000, RequiredAmount = 450000, OwnerDestinationCard = "3456789012345678", СounteragentDestinationCard = "8765432109876543", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Active" },
                new Bid { Id = 5, OwnerId = 5, СounteragentId = 4, FromCurrency = "UZS", ToCurrency = "RUB", OwnedAmount = 1000000, RequiredAmount = 10000, OwnerDestinationCard = "8765432109876543", СounteragentDestinationCard = "3456789012345678", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Active" },
                new Bid { Id = 6, OwnerId = 6, СounteragentId = null, FromCurrency = "RUB", ToCurrency = "UZS", OwnedAmount = 200, RequiredAmount = 30000, OwnerDestinationCard = "4567890123456789", СounteragentDestinationCard = null, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Active" },
                new Bid { Id = 7, OwnerId = 7, СounteragentId = 8, FromCurrency = "RUB", ToCurrency = "UZS", OwnedAmount = 8000, RequiredAmount = 1200000, OwnerDestinationCard = "5678901234567890", СounteragentDestinationCard = "7654321098765432", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Active" }
            );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<QueueToken> QueueTokens { get; set; }
    }
}