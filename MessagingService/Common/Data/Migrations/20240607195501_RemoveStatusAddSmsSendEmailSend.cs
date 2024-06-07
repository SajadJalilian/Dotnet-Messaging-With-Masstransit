using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessagingService.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStatusAddSmsSendEmailSend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessStatus",
                table: "InboxMessages");

            migrationBuilder.AddColumn<bool>(
                name: "EmailSend",
                table: "InboxMessages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SmsSend",
                table: "InboxMessages",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailSend",
                table: "InboxMessages");

            migrationBuilder.DropColumn(
                name: "SmsSend",
                table: "InboxMessages");

            migrationBuilder.AddColumn<int>(
                name: "ProcessStatus",
                table: "InboxMessages",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
