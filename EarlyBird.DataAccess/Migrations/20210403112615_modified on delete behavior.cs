using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EarlyBird.DataAccess.Migrations
{
    public partial class modifiedondeletebehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_AccepterId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_PublisherId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_SenderId",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07d94746-c113-4de6-a0bf-8c4789b51c67"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$pTXEH48yf4Iu9rLQt70vEu6MroDFtNmjT6a4Aqg.Hcnv/pQsd0SsC", "$2a$11$3GCGeQTue5rPacRsDRV4Xe" });

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Salt", "Username" },
                values: new object[] { new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"), "$2a$11$WVgYtVXgpmS/Z.VHpkMSAOvZcphR.s.Xdo6iTM0tpLDWTn7YJNkam", 3, "$2a$11$96XqWRthYs0Pf7uExHyk/u", "publisher2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Salt", "Username" },
                values: new object[] { new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"), "$2a$11$F9P7rfhb4Sy.qaMVusNWPOntKoOjKATI06MD7DgvSGgHJx3Xk7SK2", 2, "$2a$11$m5rMnQ0zpx.7c3N1LZD9a.", "worker2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_AccepterId",
                table: "Offers",
                column: "AccepterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_PublisherId",
                table: "Offers",
                column: "PublisherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_SenderId",
                table: "Reviews",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_AccepterId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_PublisherId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_SenderId",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_AccepterId",
                table: "Offers",
                column: "AccepterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_PublisherId",
                table: "Offers",
                column: "PublisherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_SenderId",
                table: "Reviews",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
