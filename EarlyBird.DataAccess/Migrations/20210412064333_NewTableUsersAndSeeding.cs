using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EarlyBird.DataAccess.Migrations
{
    public partial class NewTableUsersAndSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07d94746-c113-4de6-a0bf-8c4789b51c67"),
                columns: new[] { "Firstname", "Lastname", "PasswordHash", "Salt" },
                values: new object[] { "Cristian", "Nicolae", "$2a$11$1DDhMkGdHKzRpZD58VrBkeyAVzyOwy/6U.477iRPKa0nqrshG5Uai", "$2a$11$sXaoXQUj6BI42tEqXOn1Le" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"),
                columns: new[] { "Firstname", "Lastname", "PasswordHash", "Salt" },
                values: new object[] { "Marius-Cristian", "Socaci", "$2a$11$SKp590yIMqR2UZlHGw71EeleTKpqctbTirYX8UgL6DxkLn.xQB4YC", "$2a$11$2uYukkue1wmvWBfNqHLfYO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"),
                columns: new[] { "Firstname", "Lastname", "PasswordHash", "Salt" },
                values: new object[] { "Andrei-Vlad", "Popica", "$2a$11$.0eYZPNhxxrxf61btEY0KOAcjxQVv.Il/qT0uaZAp..iz2RF8kjzW", "$2a$11$H4r.INnHWvEHJCL9Hce7.." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"),
                columns: new[] { "Firstname", "Lastname", "PasswordHash", "Salt" },
                values: new object[] { "Andrei", "Varga", "$2a$11$YURVMRGs3QDhVZgpFWQpXOHUUOp49/LymzWGXFTLy8kVJrOER4ycy", "$2a$11$E.61pvDXr2CQL27VO3ImB." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"),
                columns: new[] { "Firstname", "Lastname", "PasswordHash", "Salt" },
                values: new object[] { "Flaviu", "Raita", "$2a$11$zO7pPer/sSlNFKOT7autYOQWVwe.lhiBXqUv8spAlzonZXKNABPSi", "$2a$11$2O5ChQH25x5s2wEMeGN/G." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07d94746-c113-4de6-a0bf-8c4789b51c67"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$TcVYkTTnuHcJARsrLpOmROblJoV5FCdFGn.ylZ19EPj4zZPrzPw3W", "$2a$11$F6X3YwHtczP4LRgecwtDY." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$4new5c0mPekNuBwfdyKH3.r0UCsOVKDgRhxGUAS.9e5gkQ.4w7Y.G", "$2a$11$suO8P3XbnOdyaVonoURQL." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$JFsZ63/TwdV3pjBXo0aV9ufp9atbYuLY8cIBpG0WLzmks1fFaQ6d.", "$2a$11$H80ce1TIj2dEnj9swZUCKe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$qWK8rykZg27nfkOSVAvLZOwsiOntydd.NCazCfrCwwvq7iFAv/N2K", "$2a$11$ocYI2JYp5hjRbZLntIOCIu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$qAk7J.q4tftV271qZR4wf.8FIFx/mej1DMAY/A3c1XtCRVXwEcFpe", "$2a$11$J85Sl.Ggda0eKvefnFZX8." });
        }
    }
}
