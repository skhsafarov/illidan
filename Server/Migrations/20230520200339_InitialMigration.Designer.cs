﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Server.Services;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230520200339_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Server.Models.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FromCurrency")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<decimal>("OwnedAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("OwnerDestinationCard")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<decimal>("RequiredAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ToCurrency")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("СounteragentDestinationCard")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<int?>("СounteragentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("СounteragentId");

                    b.ToTable("Bids");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8473),
                            FromCurrency = "RUB",
                            OwnedAmount = 1000m,
                            OwnerDestinationCard = "1234567890123456",
                            OwnerId = 1,
                            RequiredAmount = 150000m,
                            Status = "Active",
                            ToCurrency = "UZS",
                            UpdatedAt = new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8482),
                            СounteragentDestinationCard = "9876543210987654",
                            СounteragentId = 2
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8483),
                            FromCurrency = "UZS",
                            OwnedAmount = 200000m,
                            OwnerDestinationCard = "9876543210987654",
                            OwnerId = 2,
                            RequiredAmount = 2000m,
                            Status = "Active",
                            ToCurrency = "RUB",
                            UpdatedAt = new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8484),
                            СounteragentDestinationCard = "1234567890123456",
                            СounteragentId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8485),
                            FromCurrency = "RUB",
                            OwnedAmount = 500m,
                            OwnerDestinationCard = "2345678901234567",
                            OwnerId = 3,
                            RequiredAmount = 75000m,
                            Status = "Active",
                            ToCurrency = "UZS",
                            UpdatedAt = new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8486)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8487),
                            FromCurrency = "RUB",
                            OwnedAmount = 3000m,
                            OwnerDestinationCard = "3456789012345678",
                            OwnerId = 4,
                            RequiredAmount = 450000m,
                            Status = "Active",
                            ToCurrency = "UZS",
                            UpdatedAt = new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8487),
                            СounteragentDestinationCard = "8765432109876543",
                            СounteragentId = 5
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8488),
                            FromCurrency = "UZS",
                            OwnedAmount = 1000000m,
                            OwnerDestinationCard = "8765432109876543",
                            OwnerId = 5,
                            RequiredAmount = 10000m,
                            Status = "Active",
                            ToCurrency = "RUB",
                            UpdatedAt = new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8488),
                            СounteragentDestinationCard = "3456789012345678",
                            СounteragentId = 4
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8490),
                            FromCurrency = "RUB",
                            OwnedAmount = 200m,
                            OwnerDestinationCard = "4567890123456789",
                            OwnerId = 6,
                            RequiredAmount = 30000m,
                            Status = "Active",
                            ToCurrency = "UZS",
                            UpdatedAt = new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8490)
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8491),
                            FromCurrency = "RUB",
                            OwnedAmount = 8000m,
                            OwnerDestinationCard = "5678901234567890",
                            OwnerId = 7,
                            RequiredAmount = 1200000m,
                            Status = "Active",
                            ToCurrency = "UZS",
                            UpdatedAt = new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8491),
                            СounteragentDestinationCard = "7654321098765432",
                            СounteragentId = 8
                        });
                });

            modelBuilder.Entity("Server.Models.Queue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("ImageLink")
                        .HasColumnType("text");

                    b.Property<int>("LastAnimal")
                        .HasColumnType("integer");

                    b.Property<int>("LastColor")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Queues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 0,
                            ImageLink = "https://is4-ssl.mzstatic.com/image/thumb/Purple113/v4/c6/87/aa/c687aa88-9688-1d00-b150-af95049dcf6b/pr_source.png/643x0w.jpg",
                            LastAnimal = 0,
                            LastColor = 0,
                            Name = "Стоматолог",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 2,
                            Count = 0,
                            ImageLink = "https://example.com/fitnes.jpg",
                            LastAnimal = 0,
                            LastColor = 0,
                            Name = "Фитнес",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 3,
                            Count = 0,
                            ImageLink = "https://example.com/parikmaherskaya.jpg",
                            LastAnimal = 0,
                            LastColor = 0,
                            Name = "Парикмахерская",
                            OwnerId = 3
                        },
                        new
                        {
                            Id = 4,
                            Count = 0,
                            ImageLink = "https://example.com/cafe.jpg",
                            LastAnimal = 0,
                            LastColor = 0,
                            Name = "Кафе",
                            OwnerId = 4
                        },
                        new
                        {
                            Id = 5,
                            Count = 0,
                            ImageLink = "https://example.com/autoservice.jpg",
                            LastAnimal = 0,
                            LastColor = 0,
                            Name = "Автосервис",
                            OwnerId = 5
                        },
                        new
                        {
                            Id = 6,
                            Count = 0,
                            ImageLink = "https://example.com/shop.jpg",
                            LastAnimal = 0,
                            LastColor = 0,
                            Name = "Магазин",
                            OwnerId = 6
                        },
                        new
                        {
                            Id = 7,
                            Count = 0,
                            ImageLink = "https://example.com/bank.jpg",
                            LastAnimal = 0,
                            LastColor = 0,
                            Name = "Банк",
                            OwnerId = 7
                        },
                        new
                        {
                            Id = 8,
                            Count = 0,
                            ImageLink = "https://example.com/pharmacy.jpg",
                            LastAnimal = 0,
                            LastColor = 0,
                            Name = "Аптека",
                            OwnerId = 8
                        },
                        new
                        {
                            Id = 9,
                            Count = 0,
                            ImageLink = "https://example.com/theater.jpg",
                            LastAnimal = 0,
                            LastColor = 0,
                            Name = "Театр",
                            OwnerId = 9
                        },
                        new
                        {
                            Id = 10,
                            Count = 0,
                            ImageLink = "https://example.com/post.jpg",
                            LastAnimal = 0,
                            LastColor = 0,
                            Name = "Почта",
                            OwnerId = 10
                        });
                });

            modelBuilder.Entity("Server.Models.QueueToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Animal")
                        .HasColumnType("integer");

                    b.Property<int>("Color")
                        .HasColumnType("integer");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int>("QueueId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("QueueId");

                    b.ToTable("QueueTokens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Animal = 0,
                            Color = 0,
                            OwnerId = 1,
                            QueueId = 1
                        },
                        new
                        {
                            Id = 2,
                            Animal = 1,
                            Color = 1,
                            OwnerId = 2,
                            QueueId = 1
                        },
                        new
                        {
                            Id = 3,
                            Animal = 2,
                            Color = 2,
                            OwnerId = 3,
                            QueueId = 1
                        },
                        new
                        {
                            Id = 4,
                            Animal = 3,
                            Color = 3,
                            OwnerId = 4,
                            QueueId = 1
                        },
                        new
                        {
                            Id = 5,
                            Animal = 4,
                            Color = 4,
                            OwnerId = 5,
                            QueueId = 2
                        },
                        new
                        {
                            Id = 6,
                            Animal = 5,
                            Color = 5,
                            OwnerId = 6,
                            QueueId = 2
                        },
                        new
                        {
                            Id = 7,
                            Animal = 6,
                            Color = 6,
                            OwnerId = 7,
                            QueueId = 2
                        },
                        new
                        {
                            Id = 8,
                            Animal = 7,
                            Color = 7,
                            OwnerId = 8,
                            QueueId = 3
                        },
                        new
                        {
                            Id = 9,
                            Animal = 8,
                            Color = 8,
                            OwnerId = 9,
                            QueueId = 3
                        },
                        new
                        {
                            Id = 10,
                            Animal = 9,
                            Color = 9,
                            OwnerId = 10,
                            QueueId = 3
                        },
                        new
                        {
                            Id = 11,
                            Animal = 10,
                            Color = 10,
                            OwnerId = 1,
                            QueueId = 3
                        },
                        new
                        {
                            Id = 12,
                            Animal = 11,
                            Color = 0,
                            OwnerId = 2,
                            QueueId = 3
                        },
                        new
                        {
                            Id = 13,
                            Animal = 12,
                            Color = 1,
                            OwnerId = 3,
                            QueueId = 4
                        },
                        new
                        {
                            Id = 14,
                            Animal = 13,
                            Color = 2,
                            OwnerId = 4,
                            QueueId = 5
                        },
                        new
                        {
                            Id = 15,
                            Animal = 14,
                            Color = 3,
                            OwnerId = 5,
                            QueueId = 7
                        },
                        new
                        {
                            Id = 16,
                            Animal = 15,
                            Color = 4,
                            OwnerId = 6,
                            QueueId = 8
                        },
                        new
                        {
                            Id = 17,
                            Animal = 16,
                            Color = 5,
                            OwnerId = 7,
                            QueueId = 9
                        },
                        new
                        {
                            Id = 18,
                            Animal = 17,
                            Color = 6,
                            OwnerId = 8,
                            QueueId = 9
                        },
                        new
                        {
                            Id = 19,
                            Animal = 18,
                            Color = 7,
                            OwnerId = 9,
                            QueueId = 10
                        },
                        new
                        {
                            Id = 20,
                            Animal = 19,
                            Color = 8,
                            OwnerId = 10,
                            QueueId = 10
                        });
                });

            modelBuilder.Entity("Server.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Attempts")
                        .HasColumnType("integer");

                    b.Property<string>("Code")
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Attempts = 10,
                            Expiration = new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8265),
                            FirstName = "John",
                            LastName = "Doe",
                            Phone = "+79123456789",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Attempts = 10,
                            Expiration = new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8274),
                            FirstName = "Jane",
                            LastName = "Smith",
                            Phone = "+79012345678",
                            Role = "User"
                        },
                        new
                        {
                            Id = 3,
                            Attempts = 10,
                            Expiration = new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8275),
                            FirstName = "Alex",
                            LastName = "Johnson",
                            Phone = "+79123456780",
                            Role = "User"
                        },
                        new
                        {
                            Id = 4,
                            Attempts = 10,
                            Expiration = new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8275),
                            FirstName = "Sarah",
                            LastName = "Williams",
                            Phone = "+79012345670",
                            Role = "User"
                        },
                        new
                        {
                            Id = 5,
                            Attempts = 10,
                            Expiration = new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8276),
                            FirstName = "Michael",
                            LastName = "Brown",
                            Phone = "+79123456760",
                            Role = "User"
                        },
                        new
                        {
                            Id = 6,
                            Attempts = 10,
                            Expiration = new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8277),
                            FirstName = "Emily",
                            LastName = "Davis",
                            Phone = "+79012345650",
                            Role = "User"
                        },
                        new
                        {
                            Id = 7,
                            Attempts = 10,
                            Expiration = new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8278),
                            FirstName = "David",
                            LastName = "Miller",
                            Phone = "+79123456740",
                            Role = "User"
                        },
                        new
                        {
                            Id = 8,
                            Attempts = 10,
                            Expiration = new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8278),
                            FirstName = "Emma",
                            LastName = "Anderson",
                            Phone = "+79012345630",
                            Role = "User"
                        },
                        new
                        {
                            Id = 9,
                            Attempts = 10,
                            Expiration = new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8279),
                            FirstName = "Daniel",
                            LastName = "Wilson",
                            Phone = "+79123456720",
                            Role = "User"
                        },
                        new
                        {
                            Id = 10,
                            Attempts = 10,
                            Expiration = new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8280),
                            FirstName = "Olivia",
                            LastName = "Taylor",
                            Phone = "+79012345610",
                            Role = "User"
                        });
                });

            modelBuilder.Entity("Server.Models.Bid", b =>
                {
                    b.HasOne("Server.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Models.User", "Сounteragent")
                        .WithMany()
                        .HasForeignKey("СounteragentId");

                    b.Navigation("Owner");

                    b.Navigation("Сounteragent");
                });

            modelBuilder.Entity("Server.Models.Queue", b =>
                {
                    b.HasOne("Server.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Server.Models.QueueToken", b =>
                {
                    b.HasOne("Server.Models.User", "Owner")
                        .WithMany("QueueTokens")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Models.Queue", "Queue")
                        .WithMany("QueueTokens")
                        .HasForeignKey("QueueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Queue");
                });

            modelBuilder.Entity("Server.Models.Queue", b =>
                {
                    b.Navigation("QueueTokens");
                });

            modelBuilder.Entity("Server.Models.User", b =>
                {
                    b.Navigation("QueueTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
