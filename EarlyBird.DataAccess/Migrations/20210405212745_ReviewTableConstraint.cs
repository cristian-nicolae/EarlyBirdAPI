using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EarlyBird.DataAccess.Migrations
{
    public partial class ReviewTableConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "tinyint");

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
        }
    }
}
