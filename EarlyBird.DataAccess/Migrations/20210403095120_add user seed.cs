using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EarlyBird.DataAccess.Migrations
{
    public partial class adduserseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Salt", "Username" },
                values: new object[] { new Guid("07d94746-c113-4de6-a0bf-8c4789b51c67"), "$2a$11$1X81lFa0gW99pmwRf9L4cu9IqLNJmGV3WYNhBpJSTv4AjMa4cXw6q", 1, "$2a$11$SVmxUlTvym3YG4XHXBR2z.", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Salt", "Username" },
                values: new object[] { new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"), "$2a$11$X1Sa22lxvp2DA8c/esNEkOGZCrsliPDEA63RvEn7wLYUUK2smVTku", 2, "$2a$11$QEB7cFUbj4dtQ9dFti55zu", "worker" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Salt", "Username" },
                values: new object[] { new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"), "$2a$11$oQijoJ26CIjQpK1VLWK6yuFSQhK1bfVi86JJ5yY3MKU/tVcQikh.i", 3, "$2a$11$wxVJYTf..rGQO2pvQM8WVe", "publisher" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07d94746-c113-4de6-a0bf-8c4789b51c67"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"));
        }
    }
}
