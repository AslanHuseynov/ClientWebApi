using Microsoft.EntityFrameworkCore;

namespace ClientWebAPI
{
    public class ClientDbContext : DbContext
    {
        
        public DbSet<Client> Client { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // ReSharper disable once StringLiteralTypo
            const string connectionString = "data source=DESKTOP-QG96KGI;initial catalog=ClientDatabase;user id=sa;password=NewPassw0rd";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}