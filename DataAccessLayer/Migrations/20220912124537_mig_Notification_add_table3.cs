using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_Notification_add_table3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationStatus",
                table: "Notifications");

            migrationBuilder.AddColumn<string>(
                name: "NotificationColor",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationColor",
                table: "Notifications");

            migrationBuilder.AddColumn<bool>(
                name: "NotificationStatus",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
