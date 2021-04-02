using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EarlyBird.DataAccess.Migrations
{
    public partial class FixedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserEntityId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserEntityId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "Sender_id",
                table: "Reviews",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "Receiver_id",
                table: "Reviews",
                newName: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReceiverId",
                table: "Reviews",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_SenderId",
                table: "Reviews",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_ReceiverId",
                table: "Reviews",
                column: "ReceiverId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_ReceiverId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_SenderId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ReceiverId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_SenderId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Reviews",
                newName: "Sender_id");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "Reviews",
                newName: "Receiver_id");

            migrationBuilder.AddColumn<Guid>(
                name: "UserEntityId",
                table: "Reviews",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserEntityId",
                table: "Reviews",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserEntityId",
                table: "Reviews",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
