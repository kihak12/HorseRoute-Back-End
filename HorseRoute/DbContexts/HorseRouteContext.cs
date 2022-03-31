using HorseRoute.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HorseRoute.DbContexts
{
    public class HorseRouteContext : DbContext
    {
        public HorseRouteContext(DbContextOptions<HorseRouteContext>options) : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Trajet> Trajets { get; set; }
        public DbSet<UserTrajet> UserTrajets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresse>()
                .HasOne(bc => bc.User)
                .WithOne(b => b.Adresse)
                .HasForeignKey<User>(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Adresse>()
                .HasOne(bc => bc.Trajet)
                .WithOne(b => b.AdresseStart)
                .HasForeignKey<Trajet>(b => b.AdresseStartId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserTrajet>()
                .HasOne(bc => bc.Passenger)
                .WithMany(b => b.UserTrajets)
                .HasForeignKey(bc => bc.PassengerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserTrajet>()
                .HasOne(bc => bc.Trajet)
                .WithMany(c => c.UserTrajets)
                .HasForeignKey(bc => bc.TrajetId)
                .OnDelete(DeleteBehavior.NoAction);

            // seed the database with dummy data
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cba4f9b35"),
                    Pseudo = "Asher",
                    FirstName = "William",
                    LastName = "L. Collette",
                    RegisterDate = new DateTime(1942, 03, 08),
                    Tel = "253-272-0514",
                    Mail = "WilliamLCollette@dayrep.com",
                    Password = "aiM1Oogei",
                    Active = true,
                },
                new User()
                {
                    UserId = Guid.Parse("202f0289-8d5d-4d86-83b1-d06fbe44d938"),
                    Pseudo = "Moures",
                    FirstName = "David",
                    LastName = "B. Cotton",
                    RegisterDate = new DateTime(1967, 02, 16),
                    Tel = "308-879-2411",
                    Mail = "DavidBCotton@armyspy.com",
                    Password = "que2puT9Ui2",
                    Active = true,
                },
                new User()
                {
                    UserId = Guid.Parse("707d2bc8-ee71-418a-86da-f5bc0827c3aa"),
                    Pseudo = "Kiev",
                    FirstName = "David",
                    LastName = "B.",
                    RegisterDate = new DateTime(1967, 02, 16),
                    Tel = "308-879-24451",
                    Mail = "fdfd@armyspy.com",
                    Password = "fd9Ui2",
                    Active = true,
                }
            );

            modelBuilder.Entity<Adresse>().HasData(
                new Adresse()
                {
                    AdresseId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cba4f9b35"),
                    City = "Conway",
                    Address = "4961 Bettie Ports",
                    PostalCode = "57669",
                    Country = "Oman",
                    Longitude = 47.168136,
                    Latitude = -122.514899,
                },
                new Adresse()
                {
                    AdresseId = Guid.Parse("202f0289-8d5d-4d86-83b1-d06fbe44d938"),
                    City = "Rapid City",
                    Address = "38832 Nia Wells",
                    PostalCode = "28664",
                    Country = "Macedonia",
                    Longitude = 0.7207062656146723,
                    Latitude = 49.24413632187941,
                },
                new Adresse()
                {
                    AdresseId = Guid.Parse("707d2bc8-ee71-418a-86da-f5bc0827c3aa"),
                    City = "Rapid City",
                    Address = "38832 Nia Wells",
                    PostalCode = "28664",
                    Country = "Macedonia",
                    Longitude = 3.351943369049968,
                    Latitude = 48.42594685152418,
                },
                new Adresse()
                {
                    AdresseId = Guid.Parse("1e9aec0c-6008-442f-9602-e0c2632c6894"),
                    City = "Rennes",
                    Address = "2bis Place Bir-Hakeim",
                    PostalCode = "35200",
                    Country = "France",
                    Longitude = -1.6676154192630999,
                    Latitude = 48.09246380517535,
                },
                new Adresse()
                {
                    AdresseId = Guid.Parse("122db83d-e9eb-4202-ab45-f0d83c8c2269"),
                    City = "Toulouse",
                    Address = "12 Rue Mirepoix",
                    PostalCode = "31000",
                    Country = "France",
                    Longitude = 1.441769,
                    Latitude = 43.604435,
                },
                new Adresse()
                {
                    AdresseId = Guid.Parse("a380bc80-d9ec-44b8-baa3-02cb0e13dfcc"),
                    City = "Chaumont",
                    Address = "34 Rue du Docteur Schweitzer",
                    PostalCode = "52000",
                    Country = "France",
                    Longitude = 5.137991105819535,
                    Latitude = 48.10327066039463,
                },
                new Adresse()
                {
                    AdresseId = Guid.Parse("426d6f39-15a4-431b-bc42-3b4e22114e66"),
                    City = "Saint-Brieuc",
                    Address = "45 ter Rue de Brest",
                    PostalCode = "22000",
                    Country = "France",
                    Longitude = -2.7696866456014724,
                    Latitude = 48.513644158133374,
                }
            );

            modelBuilder.Entity<Trajet>().HasData(
                new Trajet()
                {
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Diam maecenas sed enim ut sem viverra aliquet. Vestibulum rhoncus est pellentesque elit ullamcorper dignissim. Elementum curabitur vitae nunc sed velit. Magna ac placerat vestibulum lectus mauris ultrices eros in. In aliquam sem fringilla ut morbi tincidunt augue interdum.",
                    Price = 12.4,
                    AvailableSits = 2,
                    TrajetDate = DateTime.Now,
                    DayFlexibility = 5,
                    TrajetId = Guid.Parse("8e92d2b1-47e1-4cf1-8116-f4bcc3d2ee47"),
                    CreationDate = DateTime.Now,
                    DriverUserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cba4f9b35"),
                    AdresseStartId = Guid.Parse("1e9aec0c-6008-442f-9602-e0c2632c6894"),
                    AdresseEndId = Guid.Parse("122db83d-e9eb-4202-ab45-f0d83c8c2269"),
                    CheckPoints = "1.441769&!&43.604435,1.441785&!&43.604175,1.440683&!&43.60403,1.441524&!&43.602814,1.440983&!&43.602274,1.439697&!&43.60154,1.439287&!&43.600913,1.440537&!&43.599617,1.434243&!&43.598452,1.430036&!&43.598977,1.428303&!&43.607434,1.420064&!&43.610462,1.419918&!&43.611483,1.417786&!&43.61198,1.424873&!&43.652874,1.280883&!&43.959931,1.125889&!&44.054807,0.876876&!&44.056294,0.333408&!&44.230212,0.168752&!&44.422126,-0.101097&!&44.534486,-0.190616&!&44.530808,-0.350349&!&44.588226,-0.556154&!&44.773932,-0.509989&!&44.879623,-0.427148&!&45.004509,-0.603478&!&45.385948,-0.589528&!&45.59825,-0.67214&!&45.75865,-0.558114&!&45.942187,-0.526824&!&46.140017,-0.452089&!&46.218145,-0.375375&!&46.296393,-0.305766&!&46.342944,-0.40932&!&46.418978,-0.664861&!&46.391449,-1.073828&!&46.533246,-1.166982&!&46.753252,-1.514337&!&47.17231,-1.514768&!&47.173754,-1.612823&!&47.182343,-1.593665&!&47.264545,-1.591456&!&47.264752,-1.58609&!&47.265937,-1.654445&!&47.34045,-1.627969&!&47.605261,-1.715241&!&47.747104,-1.675088&!&48.076938,-1.674809&!&48.081259,-1.674839&!&48.082261,-1.674846&!&48.082855,-1.674204&!&48.092082,-1.672748&!&48.091947,-1.667485&!&48.091315,-1.667805&!&48.092225,-1.667508&!&48.092342"
                },
                new Trajet()
                {
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Diam maecenas sed enim ut sem viverra aliquet. Vestibulum rhoncus est pellentesque elit ullamcorper dignissim. Elementum curabitur vitae nunc sed velit. Magna ac placerat vestibulum lectus mauris ultrices eros in. In aliquam sem fringilla ut morbi tincidunt augue interdum.",
                    Price = 16,
                    AvailableSits = 1,
                    TrajetDate = DateTime.Now,
                    DayFlexibility = 0,
                    TrajetId = Guid.Parse("18f2c44a-68c4-4a64-af9a-b01fe23fd684"),
                    CreationDate = DateTime.Now,
                    DriverUserId = Guid.Parse("707d2bc8-ee71-418a-86da-f5bc0827c3aa"),
                    AdresseStartId = Guid.Parse("a380bc80-d9ec-44b8-baa3-02cb0e13dfcc"),
                    AdresseEndId = Guid.Parse("426d6f39-15a4-431b-bc42-3b4e22114e66"),
                    CheckPoints = "-2.769316&!&48.513815,-2.76778&!&48.512438,-2.766243&!&48.51188,-2.759347&!&48.51097,-2.759164&!&48.510895,-2.75707&!&48.510288,-2.755536&!&48.51215,-2.743406&!&48.511894,-2.487625&!&48.453014,-2.107154&!&48.219692,-1.747466&!&48.127747,-1.60341&!&48.149907,-1.572823&!&48.120779,-1.181209&!&48.069991,-0.78182&!&48.115861,-0.195484&!&48.00273,0.136451&!&48.039945,0.477076&!&48.076238,1.103831&!&48.243031,1.39521&!&48.33488,1.547989&!&48.460667,1.91009&!&48.544276,2.174513&!&48.652571,2.398937&!&48.62624,2.401285&!&48.632301,2.527367&!&48.631937,2.618331&!&48.593836,2.736477&!&48.58165,2.996084&!&48.384932,3.152592&!&48.363731,3.289102&!&48.270651,3.389976&!&48.234578,3.950724&!&48.271368,4.328607&!&48.169018,4.576368&!&48.170854,4.775896&!&48.114233,4.787758&!&48.116152,4.782602&!&48.094829,4.925594&!&48.080552,4.925782&!&48.080805,4.961144&!&48.074352,5.060103&!&48.100775,5.109198&!&48.10879,5.118711&!&48.111242,5.126983&!&48.109499,5.127219&!&48.109238,5.127805&!&48.109199,5.127724&!&48.10839,5.130378&!&48.104859,5.130857&!&48.105284,5.133041&!&48.105198,5.139716&!&48.104125,5.139959&!&48.103383,5.138448&!&48.103166"
                }
            );

            modelBuilder.Entity<UserTrajet>().HasData(
                new UserTrajet()
                {
                    Id = Guid.Parse("5d3a96c9-298b-4e57-99e3-109af0f6b688"),
                    PassengerId = Guid.Parse("707d2bc8-ee71-418a-86da-f5bc0827c3aa"),
                    TrajetId = Guid.Parse("8e92d2b1-47e1-4cf1-8116-f4bcc3d2ee47"),
                },
                new UserTrajet()
                {
                    Id = Guid.Parse("e4a715d4-3ed6-400d-878e-9ac63b821224"),
                    PassengerId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cba4f9b35"),
                    TrajetId = Guid.Parse("8e92d2b1-47e1-4cf1-8116-f4bcc3d2ee47"),
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
