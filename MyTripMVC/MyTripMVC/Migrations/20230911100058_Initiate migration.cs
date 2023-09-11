using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyTripMVC.Migrations
{
    /// <inheritdoc />
    public partial class Initiatemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltTag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltTag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    Bookingdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookingTime = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserActivities_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRestaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    Bookingdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookingTime = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRestaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRestaurants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRestaurants_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Stockholm" },
                    { 2, "Göteborg" },
                    { 3, "Uppsala" },
                    { 4, "Malmö" },
                    { 5, "Kiruna" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "AltTag", "CityId", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "A buildning with a ship on top", 1, "Vasamuseet houses a historic vessel, the Vasa warship, offering an immersive experience into maritime history and Swedish naval heritage.", "/Image/Vasamuseet.jpg", "Vasamuseet" },
                    { 2, "Entrance of Skansen", 1, "A cultural oasis, Skansen introduces visitors to the charm of Sweden's past with its open-air museum and zoo, allowing guests to explore history and wildlife.", "/Image/Skansen.jpg", "Skansen" },
                    { 3, "The building of Bonniers konsthall", 1, "An artistic haven, Bonniers konsthall showcases contemporary art exhibitions, providing a space for art enthusiasts to immerse themselves in diverse creative expressions.", "/Image/Bonnier.jpeg", "Bonniers konsthall" },
                    { 4, "Animated image of the amusement park during the evening", 2, " Liseberg is a thrilling amusement park offering a blend of exhilarating rides, captivating performances, and family-friendly entertainment for all ages.", "/Image/Liseberg.jpg", "Liseberg" },
                    { 5, "Park with a fountain", 2, "Nature enthusiasts find solace at Slottsskogen, a vast urban park where tranquility meets wildlife, offering serene walks and an opportunity to connect with nature.", "/Image/Slottsskogen.jpg", "Slottsskogen" },
                    { 6, "War ship", 2, "Maritiman beckons maritime enthusiasts with its collection of ships and boats, offering an interactive journey through seafaring history and maritime traditions.", "/Image/Maritiman.jpg", "Maritiman" },
                    { 7, "Two ladies walking in a the garden.", 3, "Linnéträdgården is a botanical oasis celebrating the legacy of Carl Linnaeus, featuring a variety of plants and settings that transport visitors to a bygone era.", "/Image/Linnetradgarden.jpg", "Linnéträdgården" },
                    { 8, "Overlooking the garden infront of a building", 3, "Botaniska Trädgården is a botanical paradise, offering an immersive experience through diverse plant species, greenhouses, and serene landscapes.", "/Image/Botaniska_Tradgarden.jpg", "Botaniska Trädgården" },
                    { 9, "Old church in middle of Uppsala", 3, "Uppsala Domkyrka, the Uppsala Cathedral, stands as a majestic religious site, inviting visitors to explore its stunning architecture and historical significance.\r\n", "/Image/Uppsala_domkyrka.jpg", "Uppsala Domkyrka" },
                    { 10, "Image of a pond with a willow tree next to it.", 4, "Kungsparken offers a tranquil urban escape, combining scenic beauty with historic sculptures and a serene lake, making it a perfect spot for relaxation.", "/Image/Kungsparken-Malmo.jpg", "Kungsparken" },
                    { 11, "People riding bikes on the street.", 4, "A cycling adventure through Malmö, the Private Bike Tour offers an exploration of the city's landmarks and hidden gems, guided by local expertise.", "/Image/MalmoBikeTour.jpg", "Malmö Private Bike Tour" },
                    { 12, "Overhead view of a castle in Malmö", 4, "Malmöhus slott, Malmö Castle, encapsulates history within its walls, inviting visitors to delve into centuries of culture and heritage through exhibitions and architecture.", "/Image/MalmoHusSlott.jpg", "Malmöhus slott" },
                    { 13, "Aurora borialis on the night sky", 5, " Located in Kiruna, Aurora Sky Station offers a chance to witness the mesmerizing Northern Lights, providing a celestial experience amidst the Arctic wilderness.", "/Image/AuroraSkyStation-Kiruna.jpg", "Aurora Sky Station" },
                    { 14, "Waterfall", 5, "Silverfallet is a captivating waterfall in Kiruna, offering a picturesque natural setting where guests can revel in the serene beauty of cascading waters.", "/Image/Silverfallet-Kiruna.jpg", "Silverfallet" },
                    { 15, "The inside of a mine with blue lights along the walls.", 5, "LKAB's Visitor Centre provides insights into Kiruna's mining heritage, offering a glimpse into the region's mining history and its impact on the community.", "/Image/LKABVisitorCenter-Kiruna.jpg", "LKAB:s Visitor Centre" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "AltTag", "CityId", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1000, "Laid tables at Mahalo", 1, "A serene dining spot offering a diverse culinary experience, Mahalo entices with its elegant ambiance and delectable menu, inviting patrons to savor a mix of flavors.", "/Image/Mahalo.jpeg", "Mahalo" },
                    { 1100, "Laid tables at Vollmers", 4, "A culinary masterpiece, Vollmers offers an exceptional dining experience, crafting dishes that epitomize artistry and innovation, inviting guests to embark on a culinary exploration.", "/Image/Vollmers.jpg", "Vollmers" },
                    { 1200, "Laid tables at Aster", 4, "With an atmosphere of elegance, Aster redefines modern dining with its creative menu that marries traditional elements with avant-garde culinary techniques.", "/Image/aster.jpeg", "Aster" },
                    { 1300, "Overlooking the bar at Lyran Matbar", 4, "A hidden gem, Lyran Matbar captures the essence of its surroundings, serving dishes that reflect the region's bounty and cultural heritage in every bite.", "/Image/Lyran.jpg", "Lyran Matbar" },
                    { 1400, "Cheeseburger without bacon", 5, "Known for its flavorsome offerings, Annis Grill beckons with its rich and succulent dishes, providing a culinary journey that celebrates the art of grilling.", "/Image/Annis.jpg", "Annis Grill" },
                    { 1500, "Entrance of Enoks", 5, "Set against a stunning backdrop, Enoks i Láddjujávri combines breathtaking views with delectable fare, giving guests an opportunity to relish nature's beauty alongside their meal.", "/Image/Enok.jpg", "Enoks i Láddjujávri" },
                    { 1600, "Dining hall", 5, "Embracing its rustic charm, Nikkaluokta Sarri immerses diners in traditional flavors, offering a taste of authentic cuisine that pays homage to local heritage.", "/Image/Nik.jpg", "Nikkaluokta Sarri" },
                    { 2000, "Laid tables at Linglong", 1, "An enchanting eatery, Linglong promises a gastronomic journey through its array of dishes, serving up a fusion of traditional and contemporary tastes that captivate the senses.", "/Image/linglong.jpg", "Linglong" },
                    { 3000, "Laid tables at Tranan", 1, "Nestled in the heart of the city, Tranan beckons diners with its cozy atmosphere and an array of dishes that reflect the essence of the local culinary scene.", "/Image/Tranan.jpg", "Tranan" },
                    { 4000, "Tabel with different cusines", 2, "A culinary haven, Daawat tempts with its aromatic creations inspired by authentic flavors, offering a taste of the rich culinary heritage of the region.", "/Image/daawat.jpg", "Daawat" },
                    { 5000, "Laid tables at Panos Panos Tavern", 2, " With a warm and welcoming ambiance, Panos Panos Tavern celebrates the art of Mediterranean cuisine, inviting guests to indulge in dishes that evoke the sun-soaked shores.", "/Image/panos.jpg", "Panos Panos Tavern" },
                    { 6000, "Laid tables at Bord 27", 2, "A culinary destination, Bord 27 invites patrons to relish an array of delightful dishes curated with passion, representing a symphony of tastes and textures.", "/Image/bord27.jpg", "Bord 27" },
                    { 7000, "Laid tables at Aaltos Italian Grill", 3, " A charming spot, Aaltos Italian Grill & Garden delights with its blend of traditional and innovative Italian fare, providing an inviting setting for a memorable dining experience.", "/Image/Aaltos.jpg", "Aaltos Italian Grill" },
                    { 8000, "Laid tables at Hambergs Fisk", 3, "Nestled by the waterfront, Hambergs Fisk celebrates the bounties of the sea, offering a seafood-centric menu that showcases the freshness and flavors of the ocean.", "/Image/Hamberg.jpg", "Hambergs Fisk" },
                    { 9000, "Laid tables at Miss Voon", 3, "A modern and sophisticated eatery, Miss Voon presents a fusion of Asian flavors with a contemporary twist, promising a culinary journey that excites the palate.", "/Image/Miss.jpg", "Miss Voon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CityId",
                table: "Activities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CityId",
                table: "Restaurants",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivities_ActivityId",
                table: "UserActivities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivities_UserId",
                table: "UserActivities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRestaurants_RestaurantId",
                table: "UserRestaurants",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRestaurants_UserId",
                table: "UserRestaurants",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "UserActivities");

            migrationBuilder.DropTable(
                name: "UserRestaurants");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
