using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Domain;
using Voter.EfDataAccess.Configurations;
using Voter.Implementation;

namespace Voter.EfDataAccess
{
    public class VoterContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var roles = new List<Role>
            {
                new Role { Id = 1, Name = "Voter" },
                new Role { Id = 2, Name = "Admin" },
                new Role { Id = 3, Name = "SuperAdmin" }
            };
            var states = new List<State>
            {
                new State { Id = 1, Name = "Serbia" },
                new State { Id = 2, Name = "Montenegro" },
                new State { Id = 3, Name = "Macedonia" },
                new State { Id = 4, Name = "Greece" },
                new State { Id = 5, Name = "Russia" }
            };
            var regions = new List<Region>
            {
                new Region { Id = 1, Name = "Rasinski Okrug", StateId = 1 },
                new Region { Id = 2, Name = "Sumadija", StateId = 1 },
                new Region { Id = 3, Name = "Vojvodina", StateId = 1 },
                new Region { Id = 4, Name = "Kosovo", StateId = 1 },
                new Region { Id = 5, Name = "Primorje", StateId = 2},
                new Region { Id = 6, Name = "Zeta", StateId = 2}
            };
            var options = new List<Option>
            {
                new Option { Id = 1, Name = "Vote Option 1", Info = "Some data 1", StateId = 1},
                new Option { Id = 2, Name = "Vote Option 2", Info = "Some data 2", StateId = 1},
                new Option { Id = 3, Name = "Vote Option 3", Info = "Some data 3", StateId = 1},
                new Option { Id = 4, Name = "Opcija 1", Info = "Neki podaci 1", StateId = 2},
                new Option { Id = 5, Name = "Opcija 2", Info = "Neki podaci 2", StateId = 2}
            };
            var persons = new List<Person>
            {
                new Person { Id = 1, FirstName = "Marko", LastName = "Markovic", Address = "Neka bb", PersonalId = "0102448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 1, RoleId = 1, OptionId = 1},
                new Person { Id = 2, FirstName = "Nikola", LastName = "Nikolic", Address = "Druga bb", PersonalId = "9475038857393", Password = HashHelper.ConvertPasswordFormat("nikola1", 0xFF), RegionId = 1, RoleId = 2, OptionId = 1},
                new Person { Id = 3, FirstName = "Ana", LastName = "Anic", Address = "Adresa na Zemlji", PersonalId = "4947330764844", Password = HashHelper.ConvertPasswordFormat("ana1", 0xFF), RegionId = 1, RoleId = 3, OptionId = 1},
                new Person { Id = 4, FirstName = "Mare", LastName = "Maric", Address = "Neka bb", PersonalId = "1102448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 1, RoleId = 1, OptionId = 1},
                new Person { Id = 5, FirstName = "Branko", LastName = "Branic", Address = "Neka bb", PersonalId = "1102448472957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 1, RoleId = 1, OptionId = 1},
                new Person { Id = 6, FirstName = "Jana", LastName = "Janic", Address = "Neka bb", PersonalId = "2102448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 1, RoleId = 1, OptionId = 1},
                new Person { Id = 7, FirstName = "Kata", LastName = "Katic", Address = "Neka bb", PersonalId = "3102448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 1, RoleId = 1, OptionId = 1},
                new Person { Id = 8, FirstName = "Aleks", LastName = "Aleksic", Address = "Neka bb", PersonalId = "4102448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 5, RoleId = 1, OptionId = 5},
                new Person { Id = 9, FirstName = "Jelena", LastName = "Jelenic", Address = "Neka bb", PersonalId = "5102448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 5, RoleId = 1, OptionId = 5},
                new Person { Id = 10, FirstName = "Mladen", LastName = "Mladenovic", Address = "Neka bb", PersonalId = "6102448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 5, RoleId = 1, OptionId = 5},
                new Person { Id = 11, FirstName = "Bilja", LastName = "Biljic", Address = "Neka bb", PersonalId = "7102448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 5, RoleId = 1, OptionId = 5},
                new Person { Id = 12, FirstName = "Djordje", LastName = "Djordjevic", Address = "Neka bb", PersonalId = "8102448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 6, RoleId = 1, OptionId = 5},
                new Person { Id = 13, FirstName = "Uros", LastName = "Urosevic", Address = "Neka bb", PersonalId = "9102448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 6, RoleId = 1, OptionId = 5},
                new Person { Id = 14, FirstName = "Stefan", LastName = "Stefanovic", Address = "Neka bb", PersonalId = "1202448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 6, RoleId = 1, OptionId = 5},
                new Person { Id = 15, FirstName = "Milena", LastName = "Milenic", Address = "Neka bb", PersonalId = "1302448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 1, RoleId = 1, OptionId = 2},
                new Person { Id = 16, FirstName = "Nevena", LastName = "Nevenkic", Address = "Neka bb", PersonalId = "1402448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 1, RoleId = 1, OptionId = 2},
                new Person { Id = 17, FirstName = "Vladimir", LastName = "Vladimirovic", Address = "Neka bb", PersonalId = "1502448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 2, RoleId = 1, OptionId = 2},
                new Person { Id = 18, FirstName = "Dijana", LastName = "Dijanic", Address = "Neka bb", PersonalId = "1602448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 2, RoleId = 1, OptionId = 2},
                new Person { Id = 19, FirstName = "Jovana", LastName = "Jovanic", Address = "Neka bb", PersonalId = "1702448272957", Password = HashHelper.ConvertPasswordFormat("marko1", 0xFF), RegionId = 2, RoleId = 1, OptionId = 2}
            };
            var useCases = new List<RoleUseCase>
            {
                new RoleUseCase { Id = 1, RoleId = 3, UseCaseId = 1},
                new RoleUseCase { Id = 2, RoleId = 3, UseCaseId = 2},
                new RoleUseCase { Id = 3, RoleId = 3, UseCaseId = 3},
                new RoleUseCase { Id = 4, RoleId = 2, UseCaseId = 4},
                new RoleUseCase { Id = 5, RoleId = 3, UseCaseId = 4},
                new RoleUseCase { Id = 6, RoleId = 1, UseCaseId = 5},
                new RoleUseCase { Id = 7, RoleId = 2, UseCaseId = 5},
                new RoleUseCase { Id = 8, RoleId = 3, UseCaseId = 5},
                new RoleUseCase { Id = 9, RoleId = 1, UseCaseId = 6},
                new RoleUseCase { Id = 10, RoleId = 2, UseCaseId = 6},
                new RoleUseCase { Id = 11, RoleId = 3, UseCaseId = 6},
                new RoleUseCase { Id = 12, RoleId = 2, UseCaseId = 7},
                new RoleUseCase { Id = 13, RoleId = 3, UseCaseId = 7},
                new RoleUseCase { Id = 14, RoleId = 2, UseCaseId = 8},
                new RoleUseCase { Id = 15, RoleId = 3, UseCaseId = 8},
                new RoleUseCase { Id = 16, RoleId = 2, UseCaseId = 9},
                new RoleUseCase { Id = 17, RoleId = 3, UseCaseId = 9},
                new RoleUseCase { Id = 18, RoleId = 2, UseCaseId = 10},
                new RoleUseCase { Id = 19, RoleId = 3, UseCaseId = 10},
                new RoleUseCase { Id = 20, RoleId = 2, UseCaseId = 11},
                new RoleUseCase { Id = 21, RoleId = 3, UseCaseId = 11},
                new RoleUseCase { Id = 22, RoleId = 2, UseCaseId = 12},
                new RoleUseCase { Id = 23, RoleId = 3, UseCaseId = 12},
                new RoleUseCase { Id = 24, RoleId = 2, UseCaseId = 13},
                new RoleUseCase { Id = 25, RoleId = 3, UseCaseId = 13},
                new RoleUseCase { Id = 26, RoleId = 2, UseCaseId = 14},
                new RoleUseCase { Id = 27, RoleId = 3, UseCaseId = 14},
                new RoleUseCase { Id = 28, RoleId = 3, UseCaseId = 15},
                new RoleUseCase { Id = 29, RoleId = 2, UseCaseId = 16},
                new RoleUseCase { Id = 30, RoleId = 3, UseCaseId = 16},
                new RoleUseCase { Id = 31, RoleId = 2, UseCaseId = 17},
                new RoleUseCase { Id = 32, RoleId = 3, UseCaseId = 17},
                new RoleUseCase { Id = 33, RoleId = 2, UseCaseId = 18},
                new RoleUseCase { Id = 34, RoleId = 3, UseCaseId = 18},
                new RoleUseCase { Id = 35, RoleId = 2, UseCaseId = 19},
                new RoleUseCase { Id = 36, RoleId = 3, UseCaseId = 19},
                new RoleUseCase { Id = 37, RoleId = 3, UseCaseId = 20},
                new RoleUseCase { Id = 38, RoleId = 2, UseCaseId = 21},
                new RoleUseCase { Id = 39, RoleId = 3, UseCaseId = 21},
                new RoleUseCase { Id = 40, RoleId = 2, UseCaseId = 22},
                new RoleUseCase { Id = 41, RoleId = 3, UseCaseId = 22},
                new RoleUseCase { Id = 42, RoleId = 3, UseCaseId = 23},
                new RoleUseCase { Id = 43, RoleId = 1, UseCaseId = 24},
                new RoleUseCase { Id = 44, RoleId = 2, UseCaseId = 24},
                new RoleUseCase { Id = 45, RoleId = 3, UseCaseId = 24},
                new RoleUseCase { Id = 46, RoleId = 1, UseCaseId = 14},
                new RoleUseCase { Id = 47, RoleId = 1, UseCaseId = 25},
                new RoleUseCase { Id = 48, RoleId = 2, UseCaseId = 25},
                new RoleUseCase { Id = 49, RoleId = 3, UseCaseId = 25},
                new RoleUseCase { Id = 50, RoleId = 1, UseCaseId = 26},
                new RoleUseCase { Id = 51, RoleId = 2, UseCaseId = 26},
                new RoleUseCase { Id = 52, RoleId = 3, UseCaseId = 26},
                new RoleUseCase { Id = 53, RoleId = 1, UseCaseId = 27},
                new RoleUseCase { Id = 54, RoleId = 2, UseCaseId = 27},
                new RoleUseCase { Id = 55, RoleId = 3, UseCaseId = 27},
                new RoleUseCase { Id = 56, RoleId = 1, UseCaseId = 15},
                new RoleUseCase { Id = 57, RoleId = 2, UseCaseId = 15},
                new RoleUseCase { Id = 58, RoleId = 1, UseCaseId = 3},
                new RoleUseCase { Id = 59, RoleId = 2, UseCaseId = 3},
                new RoleUseCase { Id = 60, RoleId = 1, UseCaseId = 16},
                new RoleUseCase { Id = 61, RoleId = 1, UseCaseId = 10}
            };

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<State>().HasData(states);
            modelBuilder.Entity<Region>().HasData(regions);
            modelBuilder.Entity<Option>().HasData(options);
            modelBuilder.Entity<Person>().HasData(persons);
            modelBuilder.Entity<RoleUseCase>().HasData(useCases);

            modelBuilder.ApplyConfiguration(new OptionConfiguration());
            modelBuilder.ApplyConfiguration(new RoleUseCaseConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new StateConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-U7GDL5M\SQLEXPRESS;Initial Catalog=Vote;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<State> States { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
    }
}
