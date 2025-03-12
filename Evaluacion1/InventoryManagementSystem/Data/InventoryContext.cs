// Data/InventoryContext.cs
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class InventoryContext : IdentityDbContext
{
    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
    {
    }

    public DbSet<Producto> Productos { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<OrdenCompra> OrdenesCompra { get; set; }
}