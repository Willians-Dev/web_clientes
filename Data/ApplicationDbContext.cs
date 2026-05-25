using Microsoft.EntityFrameworkCore;
using web_clientes.Models;

namespace web_clientes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
    }
}