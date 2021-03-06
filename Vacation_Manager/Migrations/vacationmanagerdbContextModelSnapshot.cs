// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vacation_Manager;

namespace Vacation_Manager.Migrations
{
    [DbContext(typeof(vacationmanagerdbContext))]
    partial class vacationmanagerdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Vacation_Manager.Projects", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ProjectId")
                        .HasName("PRIMARY");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("Vacation_Manager.Teams", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("TeamLead")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<int?>("TeamProject")
                        .HasColumnType("int");

                    b.HasKey("TeamId")
                        .HasName("PRIMARY");

                    b.HasIndex("TeamLead")
                        .HasName("FK_Leader");

                    b.HasIndex("TeamProject")
                        .HasName("FK_Project");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("Vacation_Manager.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("enum('CEO','Team Lead','Developer','Unassigned')");

                    b.Property<int?>("UserTeam")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("UserId")
                        .HasName("PRIMARY");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasName("UserId_UNIQUE");

                    b.HasIndex("UserTeam")
                        .HasName("FK_UserTeam");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Vacation_Manager.Vacations", b =>
                {
                    b.Property<int>("VacationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool?>("IsApproved")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsApprovedByCeo")
                        .HasColumnName("IsApprovedByCEO")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("VacType")
                        .HasColumnType("enum('Paid','Unpaid','Sick')");

                    b.Property<int>("VacUser")
                        .HasColumnType("int");

                    b.HasKey("VacationId")
                        .HasName("PRIMARY");

                    b.HasIndex("VacUser")
                        .HasName("FK_User");

                    b.ToTable("vacations");
                });

            modelBuilder.Entity("Vacation_Manager.Teams", b =>
                {
                    b.HasOne("Vacation_Manager.Users", "TeamLeadNavigation")
                        .WithMany("Teams")
                        .HasForeignKey("TeamLead")
                        .HasConstraintName("FK_Leader");

                    b.HasOne("Vacation_Manager.Projects", "TeamProjectNavigation")
                        .WithMany("Teams")
                        .HasForeignKey("TeamProject")
                        .HasConstraintName("FK_Project");
                });

            modelBuilder.Entity("Vacation_Manager.Users", b =>
                {
                    b.HasOne("Vacation_Manager.Teams", "UserTeamNavigation")
                        .WithMany("Users")
                        .HasForeignKey("UserTeam")
                        .HasConstraintName("FK_UserTeam");
                });

            modelBuilder.Entity("Vacation_Manager.Vacations", b =>
                {
                    b.HasOne("Vacation_Manager.Users", "VacUserNavigation")
                        .WithMany("Vacations")
                        .HasForeignKey("VacUser")
                        .HasConstraintName("FK_User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
