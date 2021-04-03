using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EarlyBird.DataAccess.Migrations
{
    public partial class modifiedseeduserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07d94746-c113-4de6-a0bf-8c4789b51c67"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$aRqA86QveMT7osJ6t.ueXOANkQV5o4Tu7hF043KbOZth2Cletnyiu", "$2a$11$1EJCI5Eoo1WJ5auIEyFVme" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$Yvoj.WkoUt1LVoFlQW611.TPmSNYuxkefcDwwYZRczjswlHZr.gN.", "$2a$11$HgjIn/cS6mnAdEYPbYtX/e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$Istk5lUZVStvz9nhuwAbT.nJuogWps7t5ud8nZrwQhYTewaIDDd/G", "$2a$11$t95k89hfCz4wBe0jr7lyh." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07d94746-c113-4de6-a0bf-8c4789b51c67"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$1X81lFa0gW99pmwRf9L4cu9IqLNJmGV3WYNhBpJSTv4AjMa4cXw6q", "$2a$11$SVmxUlTvym3YG4XHXBR2z." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$oQijoJ26CIjQpK1VLWK6yuFSQhK1bfVi86JJ5yY3MKU/tVcQikh.i", "$2a$11$wxVJYTf..rGQO2pvQM8WVe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$X1Sa22lxvp2DA8c/esNEkOGZCrsliPDEA63RvEn7wLYUUK2smVTku", "$2a$11$QEB7cFUbj4dtQ9dFti55zu" });
        }
    }
}
