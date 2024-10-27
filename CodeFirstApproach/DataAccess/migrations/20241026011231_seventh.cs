using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS_Demo.DataAccess.migrations
{
    /// <inheritdoc />
    public partial class seventh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "Email", "Name", "Password", "Status", "UpdatedBy" },
                values: new object[,]
                {
                    { 4, "Roopa", "suresh.Raju@gmail.com", "Suresh", "AIxwOS46v70PpHu8LtlqqZvUnhWXJ/y6Dy5qvrOp1gE=", "Active", "Roopa" },
                    { 5, "Roopa", "santosh.patil@gmail.com", "Santosh", "FRB+igSXTzfMkh5707StMA8rs2kFsgE9Mj9K/atOq5M=", "Active", "Roopa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
