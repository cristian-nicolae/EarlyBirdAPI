using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EarlyBird.DataAccess.Migrations
{
    public partial class ModifiedOfferTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Locations_LocationId",
                table: "Offers");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07d94746-c113-4de6-a0bf-8c4789b51c67"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$Y3TwyxjOff8KkDELZkcvUuIK9N3dwGy8nLbOpIaqQoKOUDV8XtX1K", "$2a$11$6OO1vXDH3o6DeTB9rNXdCO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$RmxnGhPDmM/9NmdqEpBP8ejqZHBO90aB7bH2L5bkAItOM8ks6y1ca", "$2a$11$.5kX8/.ftx1tpWlR.4tGie" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$pVdyF7M15cHS0lyQD4iaiO8AoQRu2FmXXxvg2B6RKUGADY3wC4uCu", "$2a$11$UuhXESppHMNu9/JLcMEIau" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$/LwHZDV1qRyDlCwAnzlvZOtVQPx1zRqojmJYijyAEGXORKHRcu2TO", "$2a$11$4vWTdssde2QPr2bqmQ6Uve" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$aim51HfVubD8MdXaemPNcObaP3oD.blDsmcC35og9qSy2/wnvMq8a", "$2a$11$re.LNiiVHMhIqsTPhXXZGu" });

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Locations_LocationId",
                table: "Offers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Locations_LocationId",
                table: "Offers");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07d94746-c113-4de6-a0bf-8c4789b51c67"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$eWNbDFL9/WIESGCmjLzwyOIlv9Z/B5/BwOkTGnS4xXk9RHvpGyogS", "$2a$11$MY34t0S43tK31R19ScAXce" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$TP0b3YCW0utPr6lMsNUUwubvGcRueRPNDgM7Ve8VZazrSNbjr.twy", "$2a$11$nUlMz08qlDiLG3BxM3Cfke" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$jDv1k4vrVJQxE8SgT2.NHenkVhxwVLg8w/iYW87Vj2u9c6ggYh1EO", "$2a$11$6.VRtEKtwXWa87R.IMUe0u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$tknKLk3iIg6kSt1E4UnSm.WoclHO8yaePY5Dnp46IBjPtxhvdY76G", "$2a$11$3w.wDJKdirNBH80vFrMum." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$7Pd4xdz2kDNYEoSEKbl/N.o8ivrvsDXMbhJLbJHUxroJUFoEto89y", "$2a$11$606pSgupi3.PwoNspnETy." });

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Locations_LocationId",
                table: "Offers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
