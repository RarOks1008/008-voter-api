﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Voter.EfDataAccess;

namespace Voter.EfDataAccess.Migrations
{
    [DbContext(typeof(VoterContext))]
    partial class VoterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Voter.Domain.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PartyId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartyId");

                    b.HasIndex("StateId");

                    b.ToTable("Options");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Info = "Some data 1",
                            Name = "Vote Option 1",
                            StateId = 1
                        },
                        new
                        {
                            Id = 2,
                            Info = "Some data 2",
                            Name = "Vote Option 2",
                            StateId = 1
                        },
                        new
                        {
                            Id = 3,
                            Info = "Some data 3",
                            Name = "Vote Option 3",
                            StateId = 1
                        },
                        new
                        {
                            Id = 4,
                            Info = "Neki podaci 1",
                            Name = "Opcija 1",
                            StateId = 2
                        },
                        new
                        {
                            Id = 5,
                            Info = "Neki podaci 2",
                            Name = "Opcija 2",
                            StateId = 2
                        });
                });

            modelBuilder.Entity("Voter.Domain.Party", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Partys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Republican"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Democrats"
                        });
                });

            modelBuilder.Entity("Voter.Domain.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OptionId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.HasIndex("PersonalId")
                        .IsUnique();

                    b.HasIndex("RegionId");

                    b.HasIndex("RoleId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Neka bb",
                            FirstName = "Marko",
                            LastName = "Markovic",
                            OptionId = 1,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "0102448272957",
                            RegionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Druga bb",
                            FirstName = "Nikola",
                            LastName = "Nikolic",
                            OptionId = 1,
                            Password = "/25pa29sYTE=",
                            PersonalId = "9475038857393",
                            RegionId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Address = "Adresa na Zemlji",
                            FirstName = "Ana",
                            LastName = "Anic",
                            OptionId = 1,
                            Password = "/2FuYTE=",
                            PersonalId = "4947330764844",
                            RegionId = 1,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 4,
                            Address = "Neka bb",
                            FirstName = "Mare",
                            LastName = "Maric",
                            OptionId = 1,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "1102448272957",
                            RegionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 5,
                            Address = "Neka bb",
                            FirstName = "Branko",
                            LastName = "Branic",
                            OptionId = 1,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "1102448472957",
                            RegionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 6,
                            Address = "Neka bb",
                            FirstName = "Jana",
                            LastName = "Janic",
                            OptionId = 1,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "2102448272957",
                            RegionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 7,
                            Address = "Neka bb",
                            FirstName = "Kata",
                            LastName = "Katic",
                            OptionId = 1,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "3102448272957",
                            RegionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 8,
                            Address = "Neka bb",
                            FirstName = "Aleks",
                            LastName = "Aleksic",
                            OptionId = 5,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "4102448272957",
                            RegionId = 5,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 9,
                            Address = "Neka bb",
                            FirstName = "Jelena",
                            LastName = "Jelenic",
                            OptionId = 5,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "5102448272957",
                            RegionId = 5,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 10,
                            Address = "Neka bb",
                            FirstName = "Mladen",
                            LastName = "Mladenovic",
                            OptionId = 5,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "6102448272957",
                            RegionId = 5,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 11,
                            Address = "Neka bb",
                            FirstName = "Bilja",
                            LastName = "Biljic",
                            OptionId = 5,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "7102448272957",
                            RegionId = 5,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 12,
                            Address = "Neka bb",
                            FirstName = "Djordje",
                            LastName = "Djordjevic",
                            OptionId = 5,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "8102448272957",
                            RegionId = 6,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 13,
                            Address = "Neka bb",
                            FirstName = "Uros",
                            LastName = "Urosevic",
                            OptionId = 5,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "9102448272957",
                            RegionId = 6,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 14,
                            Address = "Neka bb",
                            FirstName = "Stefan",
                            LastName = "Stefanovic",
                            OptionId = 5,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "1202448272957",
                            RegionId = 6,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 15,
                            Address = "Neka bb",
                            FirstName = "Milena",
                            LastName = "Milenic",
                            OptionId = 2,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "1302448272957",
                            RegionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 16,
                            Address = "Neka bb",
                            FirstName = "Nevena",
                            LastName = "Nevenkic",
                            OptionId = 2,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "1402448272957",
                            RegionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 17,
                            Address = "Neka bb",
                            FirstName = "Vladimir",
                            LastName = "Vladimirovic",
                            OptionId = 2,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "1502448272957",
                            RegionId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 18,
                            Address = "Neka bb",
                            FirstName = "Dijana",
                            LastName = "Dijanic",
                            OptionId = 2,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "1602448272957",
                            RegionId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 19,
                            Address = "Neka bb",
                            FirstName = "Jovana",
                            LastName = "Jovanic",
                            OptionId = 2,
                            Password = "/21hcmtvMQ==",
                            PersonalId = "1702448272957",
                            RegionId = 2,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Voter.Domain.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rasinski Okrug",
                            StateId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sumadija",
                            StateId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Vojvodina",
                            StateId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Kosovo",
                            StateId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Primorje",
                            StateId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "Zeta",
                            StateId = 2
                        });
                });

            modelBuilder.Entity("Voter.Domain.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Voter.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Voter"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("Voter.Domain.RoleUseCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UseCaseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleUseCase");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleId = 3,
                            UseCaseId = 1
                        },
                        new
                        {
                            Id = 2,
                            RoleId = 3,
                            UseCaseId = 2
                        },
                        new
                        {
                            Id = 3,
                            RoleId = 3,
                            UseCaseId = 3
                        },
                        new
                        {
                            Id = 4,
                            RoleId = 2,
                            UseCaseId = 4
                        },
                        new
                        {
                            Id = 5,
                            RoleId = 3,
                            UseCaseId = 4
                        },
                        new
                        {
                            Id = 6,
                            RoleId = 1,
                            UseCaseId = 5
                        },
                        new
                        {
                            Id = 7,
                            RoleId = 2,
                            UseCaseId = 5
                        },
                        new
                        {
                            Id = 8,
                            RoleId = 3,
                            UseCaseId = 5
                        },
                        new
                        {
                            Id = 9,
                            RoleId = 1,
                            UseCaseId = 6
                        },
                        new
                        {
                            Id = 10,
                            RoleId = 2,
                            UseCaseId = 6
                        },
                        new
                        {
                            Id = 11,
                            RoleId = 3,
                            UseCaseId = 6
                        },
                        new
                        {
                            Id = 12,
                            RoleId = 2,
                            UseCaseId = 7
                        },
                        new
                        {
                            Id = 13,
                            RoleId = 3,
                            UseCaseId = 7
                        },
                        new
                        {
                            Id = 14,
                            RoleId = 2,
                            UseCaseId = 8
                        },
                        new
                        {
                            Id = 15,
                            RoleId = 3,
                            UseCaseId = 8
                        },
                        new
                        {
                            Id = 16,
                            RoleId = 2,
                            UseCaseId = 9
                        },
                        new
                        {
                            Id = 17,
                            RoleId = 3,
                            UseCaseId = 9
                        },
                        new
                        {
                            Id = 18,
                            RoleId = 2,
                            UseCaseId = 10
                        },
                        new
                        {
                            Id = 19,
                            RoleId = 3,
                            UseCaseId = 10
                        },
                        new
                        {
                            Id = 20,
                            RoleId = 2,
                            UseCaseId = 11
                        },
                        new
                        {
                            Id = 21,
                            RoleId = 3,
                            UseCaseId = 11
                        },
                        new
                        {
                            Id = 22,
                            RoleId = 2,
                            UseCaseId = 12
                        },
                        new
                        {
                            Id = 23,
                            RoleId = 3,
                            UseCaseId = 12
                        },
                        new
                        {
                            Id = 24,
                            RoleId = 2,
                            UseCaseId = 13
                        },
                        new
                        {
                            Id = 25,
                            RoleId = 3,
                            UseCaseId = 13
                        },
                        new
                        {
                            Id = 26,
                            RoleId = 2,
                            UseCaseId = 14
                        },
                        new
                        {
                            Id = 27,
                            RoleId = 3,
                            UseCaseId = 14
                        },
                        new
                        {
                            Id = 28,
                            RoleId = 3,
                            UseCaseId = 15
                        },
                        new
                        {
                            Id = 29,
                            RoleId = 2,
                            UseCaseId = 16
                        },
                        new
                        {
                            Id = 30,
                            RoleId = 3,
                            UseCaseId = 16
                        },
                        new
                        {
                            Id = 31,
                            RoleId = 2,
                            UseCaseId = 17
                        },
                        new
                        {
                            Id = 32,
                            RoleId = 3,
                            UseCaseId = 17
                        },
                        new
                        {
                            Id = 33,
                            RoleId = 2,
                            UseCaseId = 18
                        },
                        new
                        {
                            Id = 34,
                            RoleId = 3,
                            UseCaseId = 18
                        },
                        new
                        {
                            Id = 35,
                            RoleId = 2,
                            UseCaseId = 19
                        },
                        new
                        {
                            Id = 36,
                            RoleId = 3,
                            UseCaseId = 19
                        },
                        new
                        {
                            Id = 37,
                            RoleId = 3,
                            UseCaseId = 20
                        },
                        new
                        {
                            Id = 38,
                            RoleId = 2,
                            UseCaseId = 21
                        },
                        new
                        {
                            Id = 39,
                            RoleId = 3,
                            UseCaseId = 21
                        },
                        new
                        {
                            Id = 40,
                            RoleId = 2,
                            UseCaseId = 22
                        },
                        new
                        {
                            Id = 41,
                            RoleId = 3,
                            UseCaseId = 22
                        },
                        new
                        {
                            Id = 42,
                            RoleId = 3,
                            UseCaseId = 23
                        },
                        new
                        {
                            Id = 43,
                            RoleId = 1,
                            UseCaseId = 24
                        },
                        new
                        {
                            Id = 44,
                            RoleId = 2,
                            UseCaseId = 24
                        },
                        new
                        {
                            Id = 45,
                            RoleId = 3,
                            UseCaseId = 24
                        },
                        new
                        {
                            Id = 46,
                            RoleId = 1,
                            UseCaseId = 14
                        },
                        new
                        {
                            Id = 47,
                            RoleId = 1,
                            UseCaseId = 25
                        },
                        new
                        {
                            Id = 48,
                            RoleId = 2,
                            UseCaseId = 25
                        },
                        new
                        {
                            Id = 49,
                            RoleId = 3,
                            UseCaseId = 25
                        },
                        new
                        {
                            Id = 50,
                            RoleId = 1,
                            UseCaseId = 26
                        },
                        new
                        {
                            Id = 51,
                            RoleId = 2,
                            UseCaseId = 26
                        },
                        new
                        {
                            Id = 52,
                            RoleId = 3,
                            UseCaseId = 26
                        },
                        new
                        {
                            Id = 53,
                            RoleId = 1,
                            UseCaseId = 27
                        },
                        new
                        {
                            Id = 54,
                            RoleId = 2,
                            UseCaseId = 27
                        },
                        new
                        {
                            Id = 55,
                            RoleId = 3,
                            UseCaseId = 27
                        },
                        new
                        {
                            Id = 56,
                            RoleId = 1,
                            UseCaseId = 15
                        },
                        new
                        {
                            Id = 57,
                            RoleId = 2,
                            UseCaseId = 15
                        },
                        new
                        {
                            Id = 58,
                            RoleId = 1,
                            UseCaseId = 3
                        },
                        new
                        {
                            Id = 59,
                            RoleId = 2,
                            UseCaseId = 3
                        },
                        new
                        {
                            Id = 60,
                            RoleId = 1,
                            UseCaseId = 16
                        },
                        new
                        {
                            Id = 61,
                            RoleId = 1,
                            UseCaseId = 10
                        });
                });

            modelBuilder.Entity("Voter.Domain.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Serbia"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Montenegro"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Macedonia"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Greece"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Russia"
                        });
                });

            modelBuilder.Entity("Voter.Domain.UseCaseLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UseCaseLogs");
                });

            modelBuilder.Entity("Voter.Domain.Option", b =>
                {
                    b.HasOne("Voter.Domain.Party", "Party")
                        .WithMany("Options")
                        .HasForeignKey("PartyId");

                    b.HasOne("Voter.Domain.State", "State")
                        .WithMany("Options")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Voter.Domain.Person", b =>
                {
                    b.HasOne("Voter.Domain.Option", "Option")
                        .WithMany("Persons")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Voter.Domain.Region", "Region")
                        .WithMany("Persons")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Voter.Domain.Role", "Role")
                        .WithMany("Persons")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Voter.Domain.Region", b =>
                {
                    b.HasOne("Voter.Domain.State", "State")
                        .WithMany("Regions")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Voter.Domain.RoleUseCase", b =>
                {
                    b.HasOne("Voter.Domain.Role", "Role")
                        .WithMany("RoleUseCases")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
