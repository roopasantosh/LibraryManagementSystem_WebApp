using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_Demo.DataAccess.migrations
{
    /// <inheritdoc />
    public partial class eight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "AvailableCopies", "CreatedBy", "IsAvailable", "Title", "UpdatedBy" },
                values: new object[] { 5, "", 0, "Santosh", true, "Avarana", "Santosh" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
