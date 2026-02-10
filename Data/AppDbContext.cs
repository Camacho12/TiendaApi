using Microsoft.EntityFrameworkCore;
using TIENDAAPI.Models;
using TIENDAAPI.Services;

namespace TIENDAAPI.Data;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {           
        }
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
    }
