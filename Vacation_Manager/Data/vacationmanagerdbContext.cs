using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vacation_Manager
{
    public partial class vacationmanagerdbContext : DbContext
    {
        public vacationmanagerdbContext()
        {
        }

        public vacationmanagerdbContext(DbContextOptions<vacationmanagerdbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vacations> Vacations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("user id=root;password=1234;server=127.0.0.1;database=vacationmanagerdb;persistsecurityinfo=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                     

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PRIMARY");

                entity.ToTable("projects");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => e.TeamId)
                    .HasName("PRIMARY");

                entity.ToTable("teams");

                entity.HasIndex(e => e.TeamLead)
                    .HasName("FK_Leader");

                entity.HasIndex(e => e.TeamProject)
                    .HasName("FK_Project");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.TeamLeadNavigation)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.TeamLead)
                    .HasConstraintName("FK_Leader");

                entity.HasOne(d => d.TeamProjectNavigation)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.TeamProject)
                    .HasConstraintName("FK_Project");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserTeam)
                    .HasName("FK_UserTeam");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnType("enum('CEO','Team Lead','Developer','Unassigned')");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.UserTeamNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTeam)
                    .HasConstraintName("FK_UserTeam");
            });

            modelBuilder.Entity<Vacations>(entity =>
            {
                entity.HasKey(e => e.VacationId)
                    .HasName("PRIMARY");

                entity.ToTable("vacations");

                entity.HasIndex(e => e.VacUser)
                    .HasName("FK_User");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.IsApprovedByCeo).HasColumnName("IsApprovedByCEO");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.VacType).HasColumnType("enum('Paid','Unpaid','Sick')");

                entity.HasOne(d => d.VacUserNavigation)
                    .WithMany(p => p.Vacations)
                    .HasForeignKey(d => d.VacUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
