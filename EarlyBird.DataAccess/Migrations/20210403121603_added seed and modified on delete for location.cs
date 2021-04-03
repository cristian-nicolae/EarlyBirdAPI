using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EarlyBird.DataAccess.Migrations
{
    public partial class addedseedandmodifiedondeleteforlocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Locations_LocationId",
                table: "Offers");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccepterId",
                table: "Offers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Pet Sitting" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "House Sitting" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Food Delivery" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Car Renting" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Babysitting" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Housecleaning" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Tutoring" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CityName", "StreetName", "StreetNumber" },
                values: new object[] { 3, "Lubei", "Grover", "755" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CityName", "StreetName", "StreetNumber" },
                values: new object[] { 4, "Presidente Epit�cio", "Fulton", "3" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CityName", "StreetName", "StreetNumber" },
                values: new object[] { 1, "Rawa Mazowiecka", "Sutherland", "5694" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CityName", "StreetName", "StreetNumber" },
                values: new object[] { 2, "Mojo", "Vernon", "1029" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Description", "Rating", "ReceiverId", "SenderId", "Title" },
                values: new object[] { 1, "dui maecenas tristique est et tempus semper est quam pharetra magna ac consequat metus sapien ut nunc vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae mauris viverra diam vitae quam suspendisse potenti nullam", 5, new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), "Review title79" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Description", "Rating", "ReceiverId", "SenderId", "Title" },
                values: new object[] { 2, "luctus cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus vivamus vestibulum sagittis sapien cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus etiam vel augue vestibulum rutrum rutrum neque aenean", 1, new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), "Review title90" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Description", "Rating", "ReceiverId", "SenderId", "Title" },
                values: new object[] { 3, "sit amet lobortis sapien sapien non mi integer ac neque duis bibendum morbi non quam nec dui luctus rutrum nulla tellus in sagittis dui vel nisl duis ac nibh", 2, new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), "Review title41" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Description", "Rating", "ReceiverId", "SenderId", "Title" },
                values: new object[] { 4, "felis fusce posuere felis sed lacus morbi sem mauris laoreet ut rhoncus aliquet pulvinar sed nisl nunc rhoncus dui vel sem sed sagittis nam congue risus semper porta volutpat quam pede lobortis ligula sit amet eleifend pede libero", 2, new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), "Review title18" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Description", "Rating", "ReceiverId", "SenderId", "Title" },
                values: new object[] { 5, "ultrices vel augue vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae donec pharetra magna vestibulum aliquet ultrices erat tortor sollicitudin mi sit amet lobortis sapien sapien non mi integer", 2, new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), "Review title29" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07d94746-c113-4de6-a0bf-8c4789b51c67"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$nHdgHi75J25LWKUhaK7KWultXLnlksahDiRyPxkopRku0G351qnue", "$2a$11$c7MgKEyUtumAxrYpGefCXe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$M/DrLrXmrW/q0o530Ikwvextr72m9S0u0zxoX/OmwrHot5NiZfchy", "$2a$11$ejHA9pZGG57BnRRi7bbcWO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$o4i3FK41vjn4RuuoIGQdDOR4SHRP.nG61k.pjgP7XOIooa.6A/iG6", "$2a$11$ro0wsAYm0gkGG32mpOnyje" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$KhxQs/Oui3MVt9L1zFzWaeCa5qbXmPIOpoZdhd/j9Oyd1peNFLeOK", "$2a$11$bPW/bk2.Q72OqesrTEIEeu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$cz3M4v8AqG8.Br0u6aP/0.O31ckBfgWla0JxqbSVnDXK3GuXnEcF6", "$2a$11$NtkUL9IULmpjq8QsLSmo4O" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 1, null, 13.6, "turpis a pede posuere nonummy integer non velit donec diam neque vestibulum eget vulputate ut ultrices vel augue vestibulum ante ipsum", 1, null, "extranet", new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), 1, " Job Title96" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 5, new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), 35.899999999999999, "magna bibendum imperdiet nullam orci pede venenatis non sodales sed tincidunt eu felis fusce posuere felis sed lacus morbi sem", 4, "in libero ut massa volutpat convallis morbi odio odio elementum eu interdum eu tincidunt", "Progressive", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title29" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 18, null, 95.900000000000006, "leo maecenas pulvinar lobortis est phasellus sit amet erat nulla tempus vivamus in felis eu sapien cursus vestibulum proin eu mi nulla", 3, null, "even-keeled", new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), 1, " Job Title72" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 17, null, 2.3999999999999999, "molestie lorem quisque ut erat curabitur gravida nisi at nibh in hac habitasse platea dictumst aliquam augue quam sollicitudin vitae consectetuer", 3, null, "Triple-buffered", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 1, " Job Title33" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 16, new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), 44.399999999999999, "magna bibendum imperdiet nullam orci pede venenatis non sodales sed tincidunt eu felis fusce posuere felis sed", 3, "sit amet sapien dignissim vestibulum vestibulum ante", "project", new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), 2, " Job Title44" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 15, new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), 62.200000000000003, "ut blandit non interdum in ante vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae duis faucibus accumsan", 3, "enim sit amet nunc viverra dapibus nulla suscipit ligula in lacus curabitur at ipsum ac", "knowledge user", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title79" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 14, null, 45.399999999999999, "adipiscing elit proin risus praesent lectus vestibulum quam sapien varius ut blandit non interdum in ante vestibulum ante ipsum primis in faucibus orci luctus", 3, null, "extranet", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 1, " Job Title44" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 13, new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), 94.099999999999994, "eros vestibulum ac est lacinia nisi venenatis tristique fusce congue diam id ornare imperdiet sapien urna pretium nisl ut volutpat sapien arcu sed augue aliquam erat volutpat in", 3, "ridiculus mus vivamus vestibulum sagittis sapien cum sociis", "Synergized", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title32" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 10, null, 75.400000000000006, "lacus at turpis donec posuere metus vitae ipsum aliquam non mauris morbi non lectus aliquam sit amet diam in magna bibendum imperdiet nullam orci pede venenatis non", 3, null, "asymmetric", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 1, " Job Title92" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 6, new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), 41.299999999999997, "in faucibus orci luctus et ultrices posuere cubilia curae duis faucibus accumsan odio curabitur convallis duis consequat dui nec nisi volutpat eleifend donec ut dolor morbi vel", 3, "tempus semper est quam pharetra magna ac consequat", "synergy", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title30" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 2, null, 86.200000000000003, "cubilia curae mauris viverra diam vitae quam suspendisse potenti nullam porttitor lacus at turpis donec posuere metus vitae ipsum aliquam non", 3, null, "initiative", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 1, " Job Title5" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 20, new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), 34.100000000000001, "vestibulum vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae nulla dapibus dolor vel est donec odio justo sollicitudin ut suscipit a feugiat", 2, "laoreet ut rhoncus aliquet pulvinar sed", "24 hour", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title82" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 12, null, 49.399999999999999, "quam nec dui luctus rutrum nulla tellus in sagittis dui vel nisl duis ac nibh fusce lacus purus aliquet at feugiat non", 2, null, "superstructure", new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), 1, " Job Title38" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 9, new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), 84.099999999999994, "augue vel accumsan tellus nisi eu orci mauris lacinia sapien quis libero nullam sit amet turpis elementum", 2, "aliquet at feugiat non pretium quis", "intranet", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title28" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 4, null, 64.900000000000006, "duis mattis egestas metus aenean fermentum donec ut mauris eget massa tempor convallis nulla neque libero convallis eget eleifend luctus ultricies eu nibh quisque id justo sit", 2, null, "upward-trending", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 1, " Job Title80" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 3, new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), 30.699999999999999, "lacinia eget tincidunt eget tempus vel pede morbi porttitor lorem id ligula suspendisse ornare consequat", 2, "dapibus at diam nam tristique tortor eu pede", "User-friendly", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title77" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 19, new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), 46.700000000000003, "libero nullam sit amet turpis elementum ligula vehicula consequat morbi a ipsum integer a nibh in quis justo", 1, "nibh fusce lacus purus aliquet at feugiat non pretium quis lectus suspendisse potenti", "transitional", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title65" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 8, new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), 6.2000000000000002, "condimentum neque sapien placerat ante nulla justo aliquam quis turpis eget elit sodales scelerisque mauris sit amet eros suspendisse accumsan tortor quis turpis sed ante vivamus tortor duis mattis", 1, "nam nulla integer pede justo lacinia eget tincidunt eget tempus vel pede morbi porttitor lorem id ligula suspendisse ornare consequat", "optimal", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 2, " Job Title39" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 7, null, 26.600000000000001, "sapien in sapien iaculis congue vivamus metus arcu adipiscing molestie hendrerit at vulputate vitae nisl aenean lectus pellentesque eget nunc", 4, null, "Automated", new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), 1, " Job Title35" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AccepterId", "Cost", "Description", "LocationId", "Notes", "Prerequisites", "PublisherId", "Status", "Title" },
                values: new object[] { 11, new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), 76.799999999999997, "adipiscing elit proin risus praesent lectus vestibulum quam sapien varius ut blandit non interdum in", 4, "vestibulum sed magna at nunc commodo placerat praesent blandit nam", "upward-trending", new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), 2, " Job Title61" });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 12, 7, 1 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 16, 3, 18 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 15, 6, 16 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 13, 3, 16 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 20, 7, 15 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 4, 7, 15 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 14, 1, 10 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 9, 3, 10 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 6, 3, 6 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 2, 4, 20 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 18, 6, 12 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 8, 2, 12 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 10, 6, 9 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 19, 6, 4 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 1, 3, 4 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 3, 7, 19 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 17, 3, 8 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 5, 4, 8 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 11, 2, 5 });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 7, 6, 11 });

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Locations_LocationId",
                table: "Offers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Locations_LocationId",
                table: "Offers");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OfferCategories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccepterId",
                table: "Offers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07d94746-c113-4de6-a0bf-8c4789b51c67"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$pTXEH48yf4Iu9rLQt70vEu6MroDFtNmjT6a4Aqg.Hcnv/pQsd0SsC", "$2a$11$3GCGeQTue5rPacRsDRV4Xe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$WVgYtVXgpmS/Z.VHpkMSAOvZcphR.s.Xdo6iTM0tpLDWTn7YJNkam", "$2a$11$96XqWRthYs0Pf7uExHyk/u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$QUsCewLkmHJKsWmjwQOWPO.8FHzqrZbrNDDpFOgZIUDDOUqyp7gyO", "$2a$11$PuYVkZh0wTE2s1QUZjIPG." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$6rFdzBozFUJL7BA6QiGfkuuHs5GTQG.FCB1AS0Jmlqp3vKAjhUBrG", "$2a$11$l2CqGjDZJbj85KQWJVVs7O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$F9P7rfhb4Sy.qaMVusNWPOntKoOjKATI06MD7DgvSGgHJx3Xk7SK2", "$2a$11$m5rMnQ0zpx.7c3N1LZD9a." });

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Locations_LocationId",
                table: "Offers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
