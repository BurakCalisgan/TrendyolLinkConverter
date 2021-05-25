using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public class TrendyolDbContext : DbContext, ITrendyolDbContext
    {
        public DbSet<RequestResponseHistory> RequestResponseHistory { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "Trendyol";
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = "Trendyol";
                        entry.Entity.UpdatedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<RequestResponseHistory>()
                .Property(e => e.ConverterType)
                .HasConversion(
                    v => v.ToString(),
                    v => (ConverterTypeEnum)Enum.Parse(typeof(ConverterTypeEnum), v));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql(@"User ID=postgres;Password=123456789;Server=localhost;Port=5432;Database=TrendyolLink;Integrated Security=true;Pooling=true;");
    }
}
