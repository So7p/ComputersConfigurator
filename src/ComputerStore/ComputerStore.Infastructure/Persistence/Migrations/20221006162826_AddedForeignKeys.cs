using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerStore.Infastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_ComputerBrands_ComputerBrandId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Models_ConfigurationId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Computers_ComputerBrandId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "Manufacturer_id",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Drives");

            migrationBuilder.DropColumn(
                name: "Manufacturer_id",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "ComputerBrandId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Computers");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Drives",
                newName: "MemoryValue");

            migrationBuilder.AddColumn<int>(
                name: "ComputerBrandId",
                table: "Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Models_ComputerBrandId",
                table: "Models",
                column: "ComputerBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ConfigurationId",
                table: "Models",
                column: "ConfigurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_ComputerBrands_ComputerBrandId",
                table: "Models",
                column: "ComputerBrandId",
                principalTable: "ComputerBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_ComputerBrands_ComputerBrandId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_ComputerBrandId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_ConfigurationId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "ComputerBrandId",
                table: "Models");

            migrationBuilder.RenameColumn(
                name: "MemoryValue",
                table: "Drives",
                newName: "Value");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer_id",
                table: "GPUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Drives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer_id",
                table: "CPUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Computers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ComputerBrandId",
                table: "Computers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Computers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ConfigurationId",
                table: "Models",
                column: "ConfigurationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ComputerBrandId",
                table: "Computers",
                column: "ComputerBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_ComputerBrands_ComputerBrandId",
                table: "Computers",
                column: "ComputerBrandId",
                principalTable: "ComputerBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
