using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Migrations
{
    /// <inheritdoc />
    public partial class PopulateMembershipTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("MembershipTypes", ["Id", "SignUpFee", "DurationInMonths", "DiscountRate"], [1, 0, 0, 0]);
            migrationBuilder.InsertData("MembershipTypes", ["Id", "SignUpFee", "DurationInMonths", "DiscountRate"], [2, 30, 1, 10]);
            migrationBuilder.InsertData("MembershipTypes", ["Id", "SignUpFee", "DurationInMonths", "DiscountRate"], [3, 90, 3, 15]);
            migrationBuilder.InsertData("MembershipTypes", ["Id", "SignUpFee", "DurationInMonths", "DiscountRate"], [4, 300, 12, 20]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
