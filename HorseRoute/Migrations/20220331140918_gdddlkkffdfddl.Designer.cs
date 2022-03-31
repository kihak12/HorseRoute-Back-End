﻿// <auto-generated />
using System;
using HorseRoute.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HorseRoute.Migrations
{
    [DbContext(typeof(HorseRouteContext))]
    [Migration("20220331140918_gdddlkkffdfddl")]
    partial class gdddlkkffdfddl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HorseRoute.Entities.Adresse", b =>
                {
                    b.Property<Guid>("AdresseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdresseId");

                    b.ToTable("Adresses");

                    b.HasData(
                        new
                        {
                            AdresseId = new Guid("d28888e9-2ba9-473a-a40f-e38cba4f9b35"),
                            Address = "4961 Bettie Ports",
                            City = "Conway",
                            Country = "Oman",
                            Latitude = -122.514899,
                            Longitude = 47.168135999999997,
                            PostalCode = "57669"
                        },
                        new
                        {
                            AdresseId = new Guid("202f0289-8d5d-4d86-83b1-d06fbe44d938"),
                            Address = "38832 Nia Wells",
                            City = "Rapid City",
                            Country = "Macedonia",
                            Latitude = 49.244136321879409,
                            Longitude = 0.72070626561467233,
                            PostalCode = "28664"
                        },
                        new
                        {
                            AdresseId = new Guid("707d2bc8-ee71-418a-86da-f5bc0827c3aa"),
                            Address = "38832 Nia Wells",
                            City = "Rapid City",
                            Country = "Macedonia",
                            Latitude = 48.425946851524181,
                            Longitude = 3.3519433690499678,
                            PostalCode = "28664"
                        },
                        new
                        {
                            AdresseId = new Guid("1e9aec0c-6008-442f-9602-e0c2632c6894"),
                            Address = "2bis Place Bir-Hakeim",
                            City = "Rennes",
                            Country = "France",
                            Latitude = 48.092463805175349,
                            Longitude = -1.6676154192630999,
                            PostalCode = "35200"
                        },
                        new
                        {
                            AdresseId = new Guid("122db83d-e9eb-4202-ab45-f0d83c8c2269"),
                            Address = "12 Rue Mirepoix",
                            City = "Toulouse",
                            Country = "France",
                            Latitude = 43.604435000000002,
                            Longitude = 1.4417690000000001,
                            PostalCode = "31000"
                        },
                        new
                        {
                            AdresseId = new Guid("a380bc80-d9ec-44b8-baa3-02cb0e13dfcc"),
                            Address = "34 Rue du Docteur Schweitzer",
                            City = "Chaumont",
                            Country = "France",
                            Latitude = 48.103270660394628,
                            Longitude = 5.1379911058195349,
                            PostalCode = "52000"
                        },
                        new
                        {
                            AdresseId = new Guid("426d6f39-15a4-431b-bc42-3b4e22114e66"),
                            Address = "45 ter Rue de Brest",
                            City = "Saint-Brieuc",
                            Country = "France",
                            Latitude = 48.513644158133374,
                            Longitude = -2.7696866456014724,
                            PostalCode = "22000"
                        });
                });

            modelBuilder.Entity("HorseRoute.Entities.Trajet", b =>
                {
                    b.Property<Guid>("TrajetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdresseEndId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdresseStartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableSits")
                        .HasColumnType("int");

                    b.Property<string>("CheckPoints")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayFlexibility")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DriverUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("TrajetDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TrajetId");

                    b.HasIndex("AdresseEndId");

                    b.HasIndex("AdresseStartId")
                        .IsUnique();

                    b.HasIndex("DriverUserId");

                    b.ToTable("Trajets");

                    b.HasData(
                        new
                        {
                            TrajetId = new Guid("8e92d2b1-47e1-4cf1-8116-f4bcc3d2ee47"),
                            AdresseEndId = new Guid("122db83d-e9eb-4202-ab45-f0d83c8c2269"),
                            AdresseStartId = new Guid("1e9aec0c-6008-442f-9602-e0c2632c6894"),
                            AvailableSits = 2,
                            CheckPoints = "1.441769&!&43.604435,1.441785&!&43.604175,1.440683&!&43.60403,1.441524&!&43.602814,1.440983&!&43.602274,1.439697&!&43.60154,1.439287&!&43.600913,1.440537&!&43.599617,1.434243&!&43.598452,1.430036&!&43.598977,1.428303&!&43.607434,1.420064&!&43.610462,1.419918&!&43.611483,1.417786&!&43.61198,1.424873&!&43.652874,1.280883&!&43.959931,1.125889&!&44.054807,0.876876&!&44.056294,0.333408&!&44.230212,0.168752&!&44.422126,-0.101097&!&44.534486,-0.190616&!&44.530808,-0.350349&!&44.588226,-0.556154&!&44.773932,-0.509989&!&44.879623,-0.427148&!&45.004509,-0.603478&!&45.385948,-0.589528&!&45.59825,-0.67214&!&45.75865,-0.558114&!&45.942187,-0.526824&!&46.140017,-0.452089&!&46.218145,-0.375375&!&46.296393,-0.305766&!&46.342944,-0.40932&!&46.418978,-0.664861&!&46.391449,-1.073828&!&46.533246,-1.166982&!&46.753252,-1.514337&!&47.17231,-1.514768&!&47.173754,-1.612823&!&47.182343,-1.593665&!&47.264545,-1.591456&!&47.264752,-1.58609&!&47.265937,-1.654445&!&47.34045,-1.627969&!&47.605261,-1.715241&!&47.747104,-1.675088&!&48.076938,-1.674809&!&48.081259,-1.674839&!&48.082261,-1.674846&!&48.082855,-1.674204&!&48.092082,-1.672748&!&48.091947,-1.667485&!&48.091315,-1.667805&!&48.092225,-1.667508&!&48.092342",
                            CreationDate = new DateTime(2022, 3, 31, 16, 9, 17, 667, DateTimeKind.Local).AddTicks(5570),
                            DayFlexibility = 5,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Diam maecenas sed enim ut sem viverra aliquet. Vestibulum rhoncus est pellentesque elit ullamcorper dignissim. Elementum curabitur vitae nunc sed velit. Magna ac placerat vestibulum lectus mauris ultrices eros in. In aliquam sem fringilla ut morbi tincidunt augue interdum.",
                            DriverUserId = new Guid("d28888e9-2ba9-473a-a40f-e38cba4f9b35"),
                            Price = 12.4,
                            TrajetDate = new DateTime(2022, 3, 31, 16, 9, 17, 667, DateTimeKind.Local).AddTicks(3849)
                        },
                        new
                        {
                            TrajetId = new Guid("18f2c44a-68c4-4a64-af9a-b01fe23fd684"),
                            AdresseEndId = new Guid("426d6f39-15a4-431b-bc42-3b4e22114e66"),
                            AdresseStartId = new Guid("a380bc80-d9ec-44b8-baa3-02cb0e13dfcc"),
                            AvailableSits = 1,
                            CheckPoints = "-2.769316&!&48.513815,-2.76778&!&48.512438,-2.766243&!&48.51188,-2.759347&!&48.51097,-2.759164&!&48.510895,-2.75707&!&48.510288,-2.755536&!&48.51215,-2.743406&!&48.511894,-2.487625&!&48.453014,-2.107154&!&48.219692,-1.747466&!&48.127747,-1.60341&!&48.149907,-1.572823&!&48.120779,-1.181209&!&48.069991,-0.78182&!&48.115861,-0.195484&!&48.00273,0.136451&!&48.039945,0.477076&!&48.076238,1.103831&!&48.243031,1.39521&!&48.33488,1.547989&!&48.460667,1.91009&!&48.544276,2.174513&!&48.652571,2.398937&!&48.62624,2.401285&!&48.632301,2.527367&!&48.631937,2.618331&!&48.593836,2.736477&!&48.58165,2.996084&!&48.384932,3.152592&!&48.363731,3.289102&!&48.270651,3.389976&!&48.234578,3.950724&!&48.271368,4.328607&!&48.169018,4.576368&!&48.170854,4.775896&!&48.114233,4.787758&!&48.116152,4.782602&!&48.094829,4.925594&!&48.080552,4.925782&!&48.080805,4.961144&!&48.074352,5.060103&!&48.100775,5.109198&!&48.10879,5.118711&!&48.111242,5.126983&!&48.109499,5.127219&!&48.109238,5.127805&!&48.109199,5.127724&!&48.10839,5.130378&!&48.104859,5.130857&!&48.105284,5.133041&!&48.105198,5.139716&!&48.104125,5.139959&!&48.103383,5.138448&!&48.103166",
                            CreationDate = new DateTime(2022, 3, 31, 16, 9, 17, 667, DateTimeKind.Local).AddTicks(7238),
                            DayFlexibility = 0,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Diam maecenas sed enim ut sem viverra aliquet. Vestibulum rhoncus est pellentesque elit ullamcorper dignissim. Elementum curabitur vitae nunc sed velit. Magna ac placerat vestibulum lectus mauris ultrices eros in. In aliquam sem fringilla ut morbi tincidunt augue interdum.",
                            DriverUserId = new Guid("707d2bc8-ee71-418a-86da-f5bc0827c3aa"),
                            Price = 16.0,
                            TrajetDate = new DateTime(2022, 3, 31, 16, 9, 17, 667, DateTimeKind.Local).AddTicks(7185)
                        });
                });

            modelBuilder.Entity("HorseRoute.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pseudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("RegisterDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("d28888e9-2ba9-473a-a40f-e38cba4f9b35"),
                            Active = true,
                            FirstName = "William",
                            LastName = "L. Collette",
                            Mail = "WilliamLCollette@dayrep.com",
                            Password = "aiM1Oogei",
                            Pseudo = "Asher",
                            RegisterDate = new DateTimeOffset(new DateTime(1942, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            Tel = "253-272-0514"
                        },
                        new
                        {
                            UserId = new Guid("202f0289-8d5d-4d86-83b1-d06fbe44d938"),
                            Active = true,
                            FirstName = "David",
                            LastName = "B. Cotton",
                            Mail = "DavidBCotton@armyspy.com",
                            Password = "que2puT9Ui2",
                            Pseudo = "Moures",
                            RegisterDate = new DateTimeOffset(new DateTime(1967, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            Tel = "308-879-2411"
                        },
                        new
                        {
                            UserId = new Guid("707d2bc8-ee71-418a-86da-f5bc0827c3aa"),
                            Active = true,
                            FirstName = "David",
                            LastName = "B.",
                            Mail = "fdfd@armyspy.com",
                            Password = "fd9Ui2",
                            Pseudo = "Kiev",
                            RegisterDate = new DateTimeOffset(new DateTime(1967, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            Tel = "308-879-24451"
                        });
                });

            modelBuilder.Entity("HorseRoute.Entities.UserTrajet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PassengerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrajetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("TrajetId");

                    b.ToTable("UserTrajets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5d3a96c9-298b-4e57-99e3-109af0f6b688"),
                            PassengerId = new Guid("707d2bc8-ee71-418a-86da-f5bc0827c3aa"),
                            TrajetId = new Guid("8e92d2b1-47e1-4cf1-8116-f4bcc3d2ee47")
                        },
                        new
                        {
                            Id = new Guid("e4a715d4-3ed6-400d-878e-9ac63b821224"),
                            PassengerId = new Guid("d28888e9-2ba9-473a-a40f-e38cba4f9b35"),
                            TrajetId = new Guid("8e92d2b1-47e1-4cf1-8116-f4bcc3d2ee47")
                        });
                });

            modelBuilder.Entity("HorseRoute.Entities.Trajet", b =>
                {
                    b.HasOne("HorseRoute.Entities.Adresse", "AdresseEnd")
                        .WithMany()
                        .HasForeignKey("AdresseEndId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HorseRoute.Entities.Adresse", "AdresseStart")
                        .WithOne("Trajet")
                        .HasForeignKey("HorseRoute.Entities.Trajet", "AdresseStartId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HorseRoute.Entities.User", "DriverUser")
                        .WithMany()
                        .HasForeignKey("DriverUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HorseRoute.Entities.User", b =>
                {
                    b.HasOne("HorseRoute.Entities.Adresse", "Adresse")
                        .WithOne("User")
                        .HasForeignKey("HorseRoute.Entities.User", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("HorseRoute.Entities.UserTrajet", b =>
                {
                    b.HasOne("HorseRoute.Entities.User", "Passenger")
                        .WithMany("UserTrajets")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HorseRoute.Entities.Trajet", "Trajet")
                        .WithMany("UserTrajets")
                        .HasForeignKey("TrajetId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
