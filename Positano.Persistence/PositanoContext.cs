using Microsoft.EntityFrameworkCore;
using Positano.Domain.Entities;
using System;
using System.Linq;

namespace Positano.Persistence
    
{
    public class PositanoContext : DbContext
{
    public PositanoContext(DbContextOptions<PositanoContext> options) : base(options)
    {
    }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                var cascadeFKs = modelBuilder
                    .Model
                    .GetEntityTypes()
                    .SelectMany(t => t.GetForeignKeys())
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

                foreach (var fk in cascadeFKs)
                    fk.DeleteBehavior = DeleteBehavior.Restrict;

                base.OnModelCreating(modelBuilder);
            } 
        
        
            public DbSet<User> Users { get; set; }
            
            public DbSet<Purchase> Purchases { get; set; }

            public DbSet<Taste> Tastes { get; set; }

             public DbSet<TypeOrder> TypeOrders { get; set; }

            public DbSet<Order> Orders { get; set; }
    }

        
}