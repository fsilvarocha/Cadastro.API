using Cadastro.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
