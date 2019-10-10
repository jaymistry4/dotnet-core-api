using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCore.API.Migrations
{
    public partial class Warehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "StockItems",
                schema: "dbo",
                columns: table => new
                {
                    StockItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StockItemName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    ColorID = table.Column<int>(type: "int", nullable: true),
                    UnitPackageID = table.Column<int>(type: "int", nullable: false),
                    OuterPackageID = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    LeadTimeDays = table.Column<int>(type: "int", nullable: false),
                    QuantityPerOuter = table.Column<int>(type: "int", nullable: false),
                    IsChillerStock = table.Column<bool>(type: "bit", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    RecommendedRetailPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    TypicalWeightPerUnit = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    MarketingComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomFields = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "json_query([CustomFields],N'$.Tags')"),
                    SearchDetails = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "concat([StockItemName],N' ',[MarketingComments])"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => x.StockItemID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockItems",
                schema: "dbo");
        }
    }
}
