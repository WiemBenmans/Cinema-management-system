﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cinema.data;

#nullable disable

namespace cinema.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230506132534_bqjhs")]
    partial class bqjhs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Date", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("année")
                        .HasColumnType("int");

                    b.Property<int>("jour")
                        .HasColumnType("int");

                    b.Property<int>("mois")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Date");
                });

            modelBuilder.Entity("Planification", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("DateId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int?>("IdDate")
                        .HasColumnType("int");

                    b.Property<int>("SalleId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("DateId");

                    b.HasIndex("FilmId");

                    b.HasIndex("SalleId");

                    b.ToTable("planifications");
                });

            modelBuilder.Entity("cinema.Model.FilmDTO", b =>
                {
                    b.Property<int>("idFilm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idFilm"));

                    b.Property<string>("categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idFilm");

                    b.ToTable("FilmDTOs");
                });

            modelBuilder.Entity("cinema.Model.ReservationDTO", b =>
                {
                    b.Property<int>("idRéservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idRéservation"));

                    b.Property<int>("clientID")
                        .HasColumnType("int");

                    b.Property<int>("planificationID")
                        .HasColumnType("int");

                    b.HasKey("idRéservation");

                    b.HasIndex("clientID");

                    b.HasIndex("planificationID");

                    b.ToTable("reservationDTOs");
                });

            modelBuilder.Entity("cinema.Model.salleDTO", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("nombrePlaces")
                        .HasColumnType("int");

                    b.Property<string>("statut")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("salleDTOs");
                });

            modelBuilder.Entity("cinema.Model.userDTO", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("userDTO");

                    b.HasDiscriminator<string>("Discriminator").HasValue("userDTO");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("positionDTO", b =>
                {
                    b.Property<int>("idPos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPos"));

                    b.Property<int>("SalleId")
                        .HasColumnType("int");

                    b.Property<int>("colonne")
                        .HasColumnType("int");

                    b.Property<int>("ligne")
                        .HasColumnType("int");

                    b.HasKey("idPos");

                    b.HasIndex("SalleId");

                    b.ToTable("positionDTOs");
                });

            modelBuilder.Entity("Admin", b =>
                {
                    b.HasBaseType("cinema.Model.userDTO");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.HasBaseType("cinema.Model.userDTO");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Planification", b =>
                {
                    b.HasOne("Date", "Date")
                        .WithMany()
                        .HasForeignKey("DateId");

                    b.HasOne("cinema.Model.FilmDTO", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinema.Model.salleDTO", "Salle")
                        .WithMany()
                        .HasForeignKey("SalleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Date");

                    b.Navigation("Film");

                    b.Navigation("Salle");
                });

            modelBuilder.Entity("cinema.Model.ReservationDTO", b =>
                {
                    b.HasOne("Client", "clientres")
                        .WithMany()
                        .HasForeignKey("clientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Planification", "planification")
                        .WithMany()
                        .HasForeignKey("planificationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clientres");

                    b.Navigation("planification");
                });

            modelBuilder.Entity("positionDTO", b =>
                {
                    b.HasOne("cinema.Model.salleDTO", "Salle")
                        .WithMany("Positions")
                        .HasForeignKey("SalleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salle");
                });

            modelBuilder.Entity("cinema.Model.salleDTO", b =>
                {
                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}
