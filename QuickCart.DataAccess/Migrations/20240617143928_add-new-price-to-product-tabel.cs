using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCart.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addnewpricetoproducttabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "NewPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewPrice",
                table: "Products");
        }
    }
}
