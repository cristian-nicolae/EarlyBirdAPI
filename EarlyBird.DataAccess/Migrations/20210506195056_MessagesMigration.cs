using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EarlyBird.DataAccess.Migrations
{
    public partial class MessagesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NewMessage = table.Column<bool>(type: "boolean", nullable: false),
                    FirstId = table.Column<Guid>(type: "uuid", nullable: false),
                    SecondId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversations_Users_FirstId",
                        column: x => x.FirstId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conversations_Users_SecondId",
                        column: x => x.SecondId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConversationId = table.Column<int>(type: "integer", nullable: false),
                    ConversationEntityId = table.Column<int>(type: "integer", nullable: true),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_ConversationEntityId",
                        column: x => x.ConversationEntityId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07d94746-c113-4de6-a0bf-8c4789b51c67"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$EWUQpZZJhtWWAYq1QrT.9eMdZy2IOKW1CB6pD6QjoMbgPzGphFniy", "$2a$11$9uXP2kT3wsQb0gwKSFpjHu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$bL0SsK9impYFa2HlRqYVK.54oT8ErBCgh6mfSa0rPkAMLKsOrtE7q", "$2a$11$8.yHknAvDwfbSN0NOkVBEe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$lS1t...Bb5ATy7pK1NzqXeXKwPmmNhHGzZBr21qVHlIc/llWFDWHu", "$2a$11$qXa/wLktmruseCQx8bpIWu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$r.w7XmjPZo00SC6SE0tDKO0VN9n5epCxZX2hcsUzJkABueKkhXnWa", "$2a$11$RDycrh.3IgEozpA0MsGsBe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$1QMloKfLvlvo2tcwWJllFuXMf9R440LuIs.yRT3PcG3ICzam1Ssa.", "$2a$11$rZcciXNErBkUFZUkryzpYe" });

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_FirstId",
                table: "Conversations",
                column: "FirstId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_SecondId",
                table: "Conversations",
                column: "SecondId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationEntityId",
                table: "Messages",
                column: "ConversationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07d94746-c113-4de6-a0bf-8c4789b51c67"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$IH/atk7HCBzojmHULx65fOi6TUv5HVSefif3LzpuncR9nM2jaOdeS", "$2a$11$atHhn.97Hx2lu9ZVIleJxO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1545516d-abe8-4597-96a4-7998e8c51c79"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$P/q53CiRYdHnyFD1hhoYU.W1tmw7f9krHiEiTULMw7q0prZ113D8O", "$2a$11$QgoJeOT/epKHqOggLDE8Se" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a779cd5-acf9-44be-b1c9-342f5edc88cb"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$eB.IWCtTjllLHwqc44W7O.JohBzQxR/UvaNPSbWqv5.5/E/Hd/LgG", "$2a$11$L3Fd.SmEU8bZfZCRHs2XXO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$KK4FjAFr9Shqn9Bg9vKsceJFeJpl4fj25exIibpbxCJ8xM5CbX0PC", "$2a$11$u5sh2.rtSn.O0kRFXDoiyO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d935c8e9-ab96-4ae9-a7b3-6c6e6ec384c5"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "$2a$11$fiSHj1uLBu33LrBOEj/ZZunaxzjUMC.r5UaP2DJ5GtyxZIFetUPCe", "$2a$11$XK0iZ.mFMNNAUW08/pDyhO" });
        }
    }
}
