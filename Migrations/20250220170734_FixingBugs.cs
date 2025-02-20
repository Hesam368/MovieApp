using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Migrations
{
    /// <inheritdoc />
    public partial class FixingBugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMovie_Customers_CustomerId",
                table: "CustomerMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMovie_Movies_MovieId",
                table: "CustomerMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerMovie",
                table: "CustomerMovie");

            migrationBuilder.RenameTable(
                name: "CustomerMovie",
                newName: "CustomerMovies");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerMovie_MovieId",
                table: "CustomerMovies",
                newName: "IX_CustomerMovies_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerMovie_CustomerId",
                table: "CustomerMovies",
                newName: "IX_CustomerMovies_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerMovies",
                table: "CustomerMovies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMovies_Customers_CustomerId",
                table: "CustomerMovies",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMovies_Movies_MovieId",
                table: "CustomerMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMovies_Customers_CustomerId",
                table: "CustomerMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMovies_Movies_MovieId",
                table: "CustomerMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerMovies",
                table: "CustomerMovies");

            migrationBuilder.RenameTable(
                name: "CustomerMovies",
                newName: "CustomerMovie");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerMovies_MovieId",
                table: "CustomerMovie",
                newName: "IX_CustomerMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerMovies_CustomerId",
                table: "CustomerMovie",
                newName: "IX_CustomerMovie_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerMovie",
                table: "CustomerMovie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMovie_Customers_CustomerId",
                table: "CustomerMovie",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMovie_Movies_MovieId",
                table: "CustomerMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
