using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMembershipTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData("MembershipTypes", "Id", 1, "Name", "Pay as You Go");
            migrationBuilder.UpdateData("MembershipTypes", "Id", 2, "Name", "Monthly");
            migrationBuilder.UpdateData("MembershipTypes", "Id", 3, "Name", "Quarterly");
            migrationBuilder.UpdateData("MembershipTypes", "Id", 4, "Name", "Annual");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
