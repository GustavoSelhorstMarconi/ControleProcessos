using Microsoft.EntityFrameworkCore;
using StageCase.Domain.Entities;

namespace StageCase.Infra.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Process> Process { get; set; }

        public DbSet<ProcessType> ProcessTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Process>()
                .Property(x => x.Name).HasColumnType("varchar(100)");

            modelBuilder.Entity<Process>()
                .Property(x => x.Description).HasColumnType("varchar(200)");

            modelBuilder.Entity<Process>()
                .HasMany(x => x.SubProcesses)
                .WithOne(x => x.ProcessParent)
                .HasForeignKey(x => x.IdProcessParent)
                .HasConstraintName("IdProcessParent")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ProcessType>()
                .Property(x => x.Name).HasColumnType("varchar(100)");

            modelBuilder.Entity<ProcessType>()
                .Property(x => x.Description).HasColumnType("varchar(200)");

            modelBuilder.Entity<ProcessType>()
                .HasMany(x => x.Processes)
                .WithOne(x => x.ProcessType)
                .HasForeignKey(x => x.IdProcessType)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
