using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EarlyBird.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StreetName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    StreetNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Firstname = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Lastname = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Salt = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Cost = table.Column<double>(type: "double precision", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    Prerequisites = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AccepterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Users_AccepterId",
                        column: x => x.AccepterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Users_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfferCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OfferId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferCategories_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pet Sitting" },
                    { 2, "House Sitting" },
                    { 3, "Food Delivery" },
                    { 4, "Car Renting" },
                    { 5, "Babysitting" },
                    { 6, "Housecleaning" },
                    { 7, "Tutoring" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CityName", "StreetName", "StreetNumber" },
                values: new object[,]
                {
                    { 1, "Rawa Mazowiecka", "Sutherland", "5694" },
                    { 2, "Mojo", "Vernon", "1029" },
                    { 3, "Lubei", "Grover", "755" },
                    { 4, "Presidente Epit�cio", "Fulton", "3" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Firstname", "Lastname", "PasswordHash", "Role", "Salt", "Username" },
                values: new object[,]
                {
                    { new Guid("07d94746-c113-4de6-a0bf-8c4789b51c67"), "Admin", "EarlyBird", "$2a$11$IH/atk7HCBzojmHULx65fOi6TUv5HVSefif3LzpuncR9nM2jaOdeS", 1, "$2a$11$atHhn.97Hx2lu9ZVIleJxO", "admin" },
                    { new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), "Andrei", "Varga", "$2a$11$KK4FjAFr9Shqn9Bg9vKsceJFeJpl4fj25exIibpbxCJ8xM5CbX0PC", 2, "$2a$11$u5sh2.rtSn.O0kRFXDoiyO", "worker" },
                    { new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), "Andrei-Vlad", "Popica", "$2a$11$eB.IWCtTjllLHwqc44W7O.JohBzQxR/UvaNPSbWqv5.5/E/Hd/LgG", 3, "$2a$11$L3Fd.SmEU8bZfZCRHs2XXO", "publisher" },
                    { new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), "Marius-Cristian", "Socaci", "$2a$11$P/q53CiRYdHnyFD1hhoYU.W1tmw7f9krHiEiTULMw7q0prZ113D8O", 3, "$2a$11$QgoJeOT/epKHqOggLDE8Se", "publisher2" },
                    { new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), "Flaviu", "Raita", "$2a$11$fiSHj1uLBu33LrBOEj/ZZunaxzjUMC.r5UaP2DJ5GtyxZIFetUPCe", 2, "$2a$11$XK0iZ.mFMNNAUW08/pDyhO", "worker2" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[,]
                {
                    { 2, null, 86.200000000000003, "cubilia curae mauris viverra diam vitae quam suspendisse potenti nullam porttitor lacus at turpis donec posuere metus vitae ipsum aliquam non", 3, null, "initiative", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 1, " Job Title5" },
                    { 20, new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), 34.100000000000001, "vestibulum vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae nulla dapibus dolor vel est donec odio justo sollicitudin ut suscipit a feugiat", 2, "laoreet ut rhoncus aliquet pulvinar sed", "24 hour", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title82" },
                    { 19, new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), 46.700000000000003, "libero nullam sit amet turpis elementum ligula vehicula consequat morbi a ipsum integer a nibh in quis justo", 1, "nibh fusce lacus purus aliquet at feugiat non pretium quis lectus suspendisse potenti", "transitional", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title65" },
                    { 13, new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), 94.099999999999994, "eros vestibulum ac est lacinia nisi venenatis tristique fusce congue diam id ornare imperdiet sapien urna pretium nisl ut volutpat sapien arcu sed augue aliquam erat volutpat in", 3, "ridiculus mus vivamus vestibulum sagittis sapien cum sociis", "Synergized", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title32" },
                    { 9, new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), 84.099999999999994, "augue vel accumsan tellus nisi eu orci mauris lacinia sapien quis libero nullam sit amet turpis elementum", 2, "aliquet at feugiat non pretium quis", "intranet", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title28" },
                    { 8, new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), 6.2000000000000002, "condimentum neque sapien placerat ante nulla justo aliquam quis turpis eget elit sodales scelerisque mauris sit amet eros suspendisse accumsan tortor quis turpis sed ante vivamus tortor duis mattis", 1, "nam nulla integer pede justo lacinia eget tincidunt eget tempus vel pede morbi porttitor lorem id ligula suspendisse ornare consequat", "optimal", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title39" },
                    { 6, new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), 41.299999999999997, "in faucibus orci luctus et ultrices posuere cubilia curae duis faucibus accumsan odio curabitur convallis duis consequat dui nec nisi volutpat eleifend donec ut dolor morbi vel", 3, "tempus semper est quam pharetra magna ac consequat", "synergy", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title30" },
                    { 18, null, 95.900000000000006, "leo maecenas pulvinar lobortis est phasellus sit amet erat nulla tempus vivamus in felis eu sapien cursus vestibulum proin eu mi nulla", 3, null, "even-keeled", new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), 1, " Job Title72" },
                    { 16, new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), 44.399999999999999, "magna bibendum imperdiet nullam orci pede venenatis non sodales sed tincidunt eu felis fusce posuere felis sed", 3, "sit amet sapien dignissim vestibulum vestibulum ante", "project", new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), 2, " Job Title44" },
                    { 11, new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), 76.799999999999997, "adipiscing elit proin risus praesent lectus vestibulum quam sapien varius ut blandit non interdum in", 4, "vestibulum sed magna at nunc commodo placerat praesent blandit nam", "upward-trending", new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), 2, " Job Title61" },
                    { 12, null, 49.399999999999999, "quam nec dui luctus rutrum nulla tellus in sagittis dui vel nisl duis ac nibh fusce lacus purus aliquet at feugiat non", 2, null, "superstructure", new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), 1, " Job Title38" },
                    { 17, null, 2.3999999999999999, "molestie lorem quisque ut erat curabitur gravida nisi at nibh in hac habitasse platea dictumst aliquam augue quam sollicitudin vitae consectetuer", 3, null, "Triple-buffered", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 1, " Job Title33" },
                    { 15, new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), 62.200000000000003, "ut blandit non interdum in ante vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae duis faucibus accumsan", 3, "enim sit amet nunc viverra dapibus nulla suscipit ligula in lacus curabitur at ipsum ac", "knowledge user", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title79" },
                    { 14, null, 45.399999999999999, "adipiscing elit proin risus praesent lectus vestibulum quam sapien varius ut blandit non interdum in ante vestibulum ante ipsum primis in faucibus orci luctus", 3, null, "extranet", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 1, " Job Title44" },
                    { 10, null, 75.400000000000006, "lacus at turpis donec posuere metus vitae ipsum aliquam non mauris morbi non lectus aliquam sit amet diam in magna bibendum imperdiet nullam orci pede venenatis non", 3, null, "asymmetric", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 1, " Job Title92" },
                    { 7, null, 26.600000000000001, "sapien in sapien iaculis congue vivamus metus arcu adipiscing molestie hendrerit at vulputate vitae nisl aenean lectus pellentesque eget nunc", 4, null, "Automated", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 1, " Job Title35" },
                    { 5, new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), 35.899999999999999, "magna bibendum imperdiet nullam orci pede venenatis non sodales sed tincidunt eu felis fusce posuere felis sed lacus morbi sem", 4, "in libero ut massa volutpat convallis morbi odio odio elementum eu interdum eu tincidunt", "Progressive", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title29" },
                    { 4, null, 64.900000000000006, "duis mattis egestas metus aenean fermentum donec ut mauris eget massa tempor convallis nulla neque libero convallis eget eleifend luctus ultricies eu nibh quisque id justo sit", 2, null, "upward-trending", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 1, " Job Title80" },
                    { 3, new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), 30.699999999999999, "lacinia eget tincidunt eget tempus vel pede morbi porttitor lorem id ligula suspendisse ornare consequat", 2, "dapibus at diam nam tristique tortor eu pede", "User-friendly", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title77" },
                    { 1, null, 13.6, "turpis a pede posuere nonummy integer non velit donec diam neque vestibulum eget vulputate ut ultrices vel augue vestibulum ante ipsum", 1, null, "extranet", new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), 1, " Job Title96" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Description", "Rating", "ReceiverId", "SenderId", "Title" },
                values: new object[,]
                {
                    { 1, "dui maecenas tristique est et tempus semper est quam pharetra magna ac consequat metus sapien ut nunc vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae mauris viverra diam vitae quam suspendisse potenti nullam", 5, new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), "Review title79" },
                    { 4, "felis fusce posuere felis sed lacus morbi sem mauris laoreet ut rhoncus aliquet pulvinar sed nisl nunc rhoncus dui vel sem sed sagittis nam congue risus semper porta volutpat quam pede lobortis ligula sit amet eleifend pede libero", 2, new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), "Review title18" },
                    { 2, "luctus cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus vivamus vestibulum sagittis sapien cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus etiam vel augue vestibulum rutrum rutrum neque aenean", 1, new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), "Review title90" },
                    { 3, "sit amet lobortis sapien sapien non mi integer ac neque duis bibendum morbi non quam nec dui luctus rutrum nulla tellus in sagittis dui vel nisl duis ac nibh", 2, new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), "Review title41" },
                    { 5, "ultrices vel augue vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae donec pharetra magna vestibulum aliquet ultrices erat tortor sollicitudin mi sit amet lobortis sapien sapien non mi integer", 2, new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), "Review title29" }
                });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[,]
                {
                    { 1, 3, 4 },
                    { 10, 6, 9 },
                    { 17, 3, 8 },
                    { 5, 4, 8 },
                    { 6, 3, 6 },
                    { 16, 3, 18 },
                    { 15, 6, 16 },
                    { 13, 3, 16 },
                    { 18, 6, 12 },
                    { 8, 2, 12 },
                    { 7, 6, 11 },
                    { 12, 7, 1 },
                    { 20, 7, 15 },
                    { 4, 7, 15 },
                    { 14, 1, 10 },
                    { 9, 3, 10 },
                    { 11, 2, 5 },
                    { 19, 6, 4 },
                    { 3, 7, 19 },
                    { 2, 4, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferCategories_CategoryId",
                table: "OfferCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferCategories_OfferId",
                table: "OfferCategories",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_AccepterId",
                table: "Offers",
                column: "AccepterId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_LocationId",
                table: "Offers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_PublisherId",
                table: "Offers",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReceiverId",
                table: "Reviews",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_SenderId",
                table: "Reviews",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferCategories");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
