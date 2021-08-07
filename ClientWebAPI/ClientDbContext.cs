using Microsoft.EntityFrameworkCore;

namespace ClientWebAPI
{
    public class ClientDbContext : DbContext
    {
        
        public DbSet<Client> Client { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // ReSharper disable once StringLiteralTypo
            const string connectionString = "data source=DESKTOP-N1VQPJU;Trusted_Connection=Yes;Integrated Security=SSPI;initial catalog=ClientDatabase";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}