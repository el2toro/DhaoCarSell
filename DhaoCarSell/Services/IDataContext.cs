using Microsoft.EntityFrameworkCore;

namespace DhaoCarSell.Services
{
    public interface IDataContext
    {
        void OnModelCreating(ModelBuilder modelBuilder);
        void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
    }
}
