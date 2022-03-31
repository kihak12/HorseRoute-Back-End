using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRoute.Migrations
{
    public partial class gdddlkkffdfdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    AdresseId = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AdresseId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Pseudo = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    RegisterDate = table.Column<DateTimeOffset>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Adresses_UserId",
                        column: x => x.UserId,
                        principalTable: "Adresses",
                        principalColumn: "AdresseId");
                });

            migrationBuilder.CreateTable(
                name: "Trajets",
                columns: table => new
                {
                    TrajetId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DriverUserId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    AvailableSits = table.Column<int>(nullable: false),
                    TrajetDate = table.Column<DateTime>(nullable: false),
                    DayFlexibility = table.Column<int>(nullable: false),
                    CheckPoints = table.Column<string>(nullable: true),
                    AdresseStartId = table.Column<Guid>(nullable: false),
                    AdresseEndId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trajets", x => x.TrajetId);
                    table.ForeignKey(
                        name: "FK_Trajets_Adresses_AdresseEndId",
                        column: x => x.AdresseEndId,
                        principalTable: "Adresses",
                        principalColumn: "AdresseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trajets_Adresses_AdresseStartId",
                        column: x => x.AdresseStartId,
                        principalTable: "Adresses",
                        principalColumn: "AdresseId");
                    table.ForeignKey(
                        name: "FK_Trajets_Users_DriverUserId",
                        column: x => x.DriverUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTrajets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PassengerId = table.Column<Guid>(nullable: false),
                    TrajetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrajets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTrajets_Users_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_UserTrajets_Trajets_TrajetId",
                        column: x => x.TrajetId,
                        principalTable: "Trajets",
                        principalColumn: "TrajetId");
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "AdresseId", "Address", "City", "Country", "Latitude", "Longitude", "PostalCode" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cba4f9b35"), "4961 Bettie Ports", "Conway", "Oman", -122.514899, 47.168135999999997, "57669" },
                    { new Guid("202f0289-8d5d-4d86-83b1-d06fbe44d938"), "38832 Nia Wells", "Rapid City", "Macedonia", 49.244136321879409, 0.72070626561467233, "28664" },
                    { new Guid("707d2bc8-ee71-418a-86da-f5bc0827c3aa"), "38832 Nia Wells", "Rapid City", "Macedonia", 48.425946851524181, 3.3519433690499678, "28664" },
                    { new Guid("1e9aec0c-6008-442f-9602-e0c2632c6894"), "2bis Place Bir-Hakeim", "Rennes", "France", 48.092463805175349, -1.6676154192630999, "35200" },
                    { new Guid("122db83d-e9eb-4202-ab45-f0d83c8c2269"), "12 Rue Mirepoix", "Toulouse", "France", 43.604435000000002, 1.4417690000000001, "31000" },
                    { new Guid("a380bc80-d9ec-44b8-baa3-02cb0e13dfcc"), "34 Rue du Docteur Schweitzer", "Chaumont", "France", 48.103270660394628, 5.1379911058195349, "52000" },
                    { new Guid("426d6f39-15a4-431b-bc42-3b4e22114e66"), "45 ter Rue de Brest", "Saint-Brieuc", "France", 48.513644158133374, -2.7696866456014724, "22000" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Active", "FirstName", "LastName", "Mail", "Password", "Pseudo", "RegisterDate", "Tel" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cba4f9b35"), true, "William", "L. Collette", "WilliamLCollette@dayrep.com", "aiM1Oogei", "Asher", new DateTimeOffset(new DateTime(1942, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "253-272-0514" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Active", "FirstName", "LastName", "Mail", "Password", "Pseudo", "RegisterDate", "Tel" },
                values: new object[] { new Guid("202f0289-8d5d-4d86-83b1-d06fbe44d938"), true, "David", "B. Cotton", "DavidBCotton@armyspy.com", "que2puT9Ui2", "Moures", new DateTimeOffset(new DateTime(1967, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "308-879-2411" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Active", "FirstName", "LastName", "Mail", "Password", "Pseudo", "RegisterDate", "Tel" },
                values: new object[] { new Guid("707d2bc8-ee71-418a-86da-f5bc0827c3aa"), true, "David", "B.", "fdfd@armyspy.com", "fd9Ui2", "Kiev", new DateTimeOffset(new DateTime(1967, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "308-879-24451" });

            migrationBuilder.InsertData(
                table: "Trajets",
                columns: new[] { "TrajetId", "AdresseEndId", "AdresseStartId", "AvailableSits", "CheckPoints", "CreationDate", "DayFlexibility", "Description", "DriverUserId", "Price", "TrajetDate" },
                values: new object[] { new Guid("8e92d2b1-47e1-4cf1-8116-f4bcc3d2ee47"), new Guid("122db83d-e9eb-4202-ab45-f0d83c8c2269"), new Guid("1e9aec0c-6008-442f-9602-e0c2632c6894"), 2, "1.44176&!&3.604435,1.44178&!&3.604175,1.44068&!&3.60403,1.44152&!&3.602814,1.44098&!&3.602274,1.43969&!&3.60154,1.43928&!&3.600913,1.44053&!&3.599617,1.43424&!&3.598452,1.43003&!&3.598977,1.42830&!&3.607434,1.42006&!&3.610462,1.41991&!&3.611483,1.41778&!&3.61198,1.42487&!&3.652874,1.28088&!&3.959931,1.12588&!&4.054807,0.87687&!&4.056294,0.33340&!&4.230212,0.16875&!&4.422126,-0.10109&!&4.534486,-0.19061&!&4.530808,-0.35034&!&4.588226,-0.55615&!&4.773932,-0.50998&!&4.879623,-0.42714&!&5.004509,-0.60347&!&5.385948,-0.58952&!&5.59825,-0.6721&!&5.75865,-0.55811&!&5.942187,-0.52682&!&6.140017,-0.45208&!&6.218145,-0.37537&!&6.296393,-0.30576&!&6.342944,-0.4093&!&6.418978,-0.66486&!&6.391449,-1.07382&!&6.533246,-1.16698&!&6.753252,-1.51433&!&7.17231,-1.51476&!&7.173754,-1.61282&!&7.182343,-1.59366&!&7.264545,-1.59145&!&7.264752,-1.5860&!&7.265937,-1.65444&!&7.34045,-1.62796&!&7.605261,-1.71524&!&7.747104,-1.67508&!&8.076938,-1.67480&!&8.081259,-1.67483&!&8.082261,-1.67484&!&8.082855,-1.67420&!&8.092082,-1.67274&!&8.091947,-1.66748&!&8.091315,-1.66780&!&8.092225,-1.66750&!&8.092342", new DateTime(2022, 3, 31, 15, 29, 35, 811, DateTimeKind.Local).AddTicks(5425), 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Diam maecenas sed enim ut sem viverra aliquet. Vestibulum rhoncus est pellentesque elit ullamcorper dignissim. Elementum curabitur vitae nunc sed velit. Magna ac placerat vestibulum lectus mauris ultrices eros in. In aliquam sem fringilla ut morbi tincidunt augue interdum.", new Guid("d28888e9-2ba9-473a-a40f-e38cba4f9b35"), 12.4, new DateTime(2022, 3, 31, 15, 29, 35, 811, DateTimeKind.Local).AddTicks(3799) });

            migrationBuilder.InsertData(
                table: "Trajets",
                columns: new[] { "TrajetId", "AdresseEndId", "AdresseStartId", "AvailableSits", "CheckPoints", "CreationDate", "DayFlexibility", "Description", "DriverUserId", "Price", "TrajetDate" },
                values: new object[] { new Guid("18f2c44a-68c4-4a64-af9a-b01fe23fd684"), new Guid("426d6f39-15a4-431b-bc42-3b4e22114e66"), new Guid("a380bc80-d9ec-44b8-baa3-02cb0e13dfcc"), 1, "-2.76931&!&8.513815,-2.7677&!&8.512438,-2.76624&!&8.51188,-2.75934&!&8.51097,-2.75916&!&8.510895,-2.7570&!&8.510288,-2.75553&!&8.51215,-2.74340&!&8.511894,-2.48762&!&8.453014,-2.10715&!&8.219692,-1.74746&!&8.127747,-1.6034&!&8.149907,-1.57282&!&8.120779,-1.18120&!&8.069991,-0.7818&!&8.115861,-0.19548&!&8.00273,0.13645&!&8.039945,0.47707&!&8.076238,1.10383&!&8.243031,1.3952&!&8.33488,1.54798&!&8.460667,1.9100&!&8.544276,2.17451&!&8.652571,2.39893&!&8.62624,2.40128&!&8.632301,2.52736&!&8.631937,2.61833&!&8.593836,2.73647&!&8.58165,2.99608&!&8.384932,3.15259&!&8.363731,3.28910&!&8.270651,3.38997&!&8.234578,3.95072&!&8.271368,4.32860&!&8.169018,4.57636&!&8.170854,4.77589&!&8.114233,4.78775&!&8.116152,4.78260&!&8.094829,4.92559&!&8.080552,4.92578&!&8.080805,4.96114&!&8.074352,5.06010&!&8.100775,5.10919&!&8.10879,5.11871&!&8.111242,5.12698&!&8.109499,5.12721&!&8.109238,5.12780&!&8.109199,5.12772&!&8.10839,5.13037&!&8.104859,5.13085&!&8.105284,5.13304&!&8.105198,5.13971&!&8.104125,5.13995&!&8.103383,5.13844&!&8.103166", new DateTime(2022, 3, 31, 15, 29, 35, 811, DateTimeKind.Local).AddTicks(7022), 0, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Diam maecenas sed enim ut sem viverra aliquet. Vestibulum rhoncus est pellentesque elit ullamcorper dignissim. Elementum curabitur vitae nunc sed velit. Magna ac placerat vestibulum lectus mauris ultrices eros in. In aliquam sem fringilla ut morbi tincidunt augue interdum.", new Guid("707d2bc8-ee71-418a-86da-f5bc0827c3aa"), 16.0, new DateTime(2022, 3, 31, 15, 29, 35, 811, DateTimeKind.Local).AddTicks(6973) });

            migrationBuilder.InsertData(
                table: "UserTrajets",
                columns: new[] { "Id", "PassengerId", "TrajetId" },
                values: new object[] { new Guid("5d3a96c9-298b-4e57-99e3-109af0f6b688"), new Guid("707d2bc8-ee71-418a-86da-f5bc0827c3aa"), new Guid("8e92d2b1-47e1-4cf1-8116-f4bcc3d2ee47") });

            migrationBuilder.InsertData(
                table: "UserTrajets",
                columns: new[] { "Id", "PassengerId", "TrajetId" },
                values: new object[] { new Guid("e4a715d4-3ed6-400d-878e-9ac63b821224"), new Guid("d28888e9-2ba9-473a-a40f-e38cba4f9b35"), new Guid("8e92d2b1-47e1-4cf1-8116-f4bcc3d2ee47") });

            migrationBuilder.CreateIndex(
                name: "IX_Trajets_AdresseEndId",
                table: "Trajets",
                column: "AdresseEndId");

            migrationBuilder.CreateIndex(
                name: "IX_Trajets_AdresseStartId",
                table: "Trajets",
                column: "AdresseStartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trajets_DriverUserId",
                table: "Trajets",
                column: "DriverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrajets_PassengerId",
                table: "UserTrajets",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrajets_TrajetId",
                table: "UserTrajets",
                column: "TrajetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTrajets");

            migrationBuilder.DropTable(
                name: "Trajets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}
