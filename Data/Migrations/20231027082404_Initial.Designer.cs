﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(EfCoreContext))]
    [Migration("20231027082404_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.CustomerInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("CustomerInformation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "etstedidanmark",
                            Country = "Denmark",
                            OrderId = 1
                        });
                });

            modelBuilder.Entity("Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CardDetails")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<int>("CustomerInformationId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.Property<string>("SocialSecurity")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.ToTable("Order", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardDetails = "1234567891234567",
                            CustomerInformationId = 0,
                            Email = "a@gmail.com",
                            OrderDate = new DateTime(2023, 10, 27, 8, 24, 4, 680, DateTimeKind.Utc).AddTicks(2920),
                            PokemonId = 1,
                            SocialSecurity = "1234567891"
                        });
                });

            modelBuilder.Entity("Data.Entities.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Pokemon", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bulbasaur",
                            Url = "https://pokeapi.co/api/v2/pokemon/1"
                        });
                });

            modelBuilder.Entity("Data.Entities.PokemonStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId")
                        .IsUnique();

                    b.ToTable("PokemonStats", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A grass and poison type Pokémon.",
                            Experience = 64,
                            Height = 7,
                            PokemonId = 1,
                            Weight = 69
                        });
                });

            modelBuilder.Entity("Data.Entities.CustomerInformation", b =>
                {
                    b.HasOne("Data.Entities.Order", "Order")
                        .WithOne("CustomerInformation")
                        .HasForeignKey("Data.Entities.CustomerInformation", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Data.Entities.Pokemon", b =>
                {
                    b.HasOne("Data.Entities.Order", null)
                        .WithMany("Pokemon")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Data.Entities.PokemonStats", b =>
                {
                    b.HasOne("Data.Entities.Pokemon", "Pokemon")
                        .WithOne("PokemonStats")
                        .HasForeignKey("Data.Entities.PokemonStats", "PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("Data.Entities.Order", b =>
                {
                    b.Navigation("CustomerInformation")
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("Data.Entities.Pokemon", b =>
                {
                    b.Navigation("PokemonStats")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}