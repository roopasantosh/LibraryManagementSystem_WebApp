using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementProject.DataAccess.migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedBy", "IsAvailable", "Title", "UpdatedBy" },
                values: new object[,]
                {
                    { 2, "", "Roopa", true, "C#", "Roopa" },
                    { 3, "", "Suresh", true, "Art of living", "Suresh" },
                    { 4, "", "Swara", true, "Dora The Explorer", "Swara" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "Email", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 2, "Roopa", "alexander.com", "Alex", "Roopa" },
                    { 3, "Roopa", "roopasampagavi@gmail.com", "Roopa", "Roopa" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "BookId", "CreatedBy", "TransactionType", "UpdatedBy", "UserId" },
                values: new object[,]
                {
                    { 2, 2, "Roopa", "Returned", "Roopa", 2 },
                    { 3, 3, "Roopa", "", "Roopa", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
