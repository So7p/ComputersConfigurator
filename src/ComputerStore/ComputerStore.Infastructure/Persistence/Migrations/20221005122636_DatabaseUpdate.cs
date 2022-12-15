using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerStore.Infastructure.persistence.migrations
{
    /// <inheritdoc />
    public partial class DatabaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropIndex(
                name: "IX_Models_ConfigurationId",
                table: "Models");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "GPUs",
                newName: "GPUManufacturerId");

            migrationBuilder.RenameColumn(
                name: "DriveType",
                table: "Drives",
                newName: "DriveTypeId");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "CPUs",
                newName: "Cores");

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "RAMs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "RAMs",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<int>(
                name: "CPUManufacturerId",
                table: "CPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer_id",
                table: "CPUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ComputerBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPUManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriveTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GPUManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ComputerTypeId = table.Column<int>(type: "int", nullable: false),
                    ComputerBrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computers_ComputerBrands_ComputerBrandId",
                        column: x => x.ComputerBrandId,
                        principalTable: "ComputerBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_ComputerTypes_ComputerTypeId",
                        column: x => x.ComputerTypeId,
                        principalTable: "ComputerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_ConfigurationId",
                table: "Models",
                column: "ConfigurationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_GPUManufacturerId",
                table: "GPUs",
                column: "GPUManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_DriveTypeId",
                table: "Drives",
                column: "DriveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_CPUManufacturerId",
                table: "CPUs",
                column: "CPUManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ComputerBrandId",
                table: "Computers",
                column: "ComputerBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ComputerTypeId",
                table: "Computers",
                column: "ComputerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ModelId",
                table: "Computers",
                column: "ModelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_CPUManufacturers_CPUManufacturerId",
                table: "CPUs",
                column: "CPUManufacturerId",
                principalTable: "CPUManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_DriveTypes_DriveTypeId",
                table: "Drives",
                column: "DriveTypeId",
                principalTable: "DriveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_GPUManufacturers_GPUManufacturerId",
                table: "GPUs",
                column: "GPUManufacturerId",
                principalTable: "GPUManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_CPUManufacturers_CPUManufacturerId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_Drives_DriveTypes_DriveTypeId",
                table: "Drives");

            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_GPUManufacturers_GPUManufacturerId",
                table: "GPUs");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "CPUManufacturers");

            migrationBuilder.DropTable(
                name: "DriveTypes");

            migrationBuilder.DropTable(
                name: "GPUManufacturers");

            migrationBuilder.DropTable(
                name: "ComputerBrands");

            migrationBuilder.DropTable(
                name: "ComputerTypes");

            migrationBuilder.DropIndex(
                name: "IX_Models_ConfigurationId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_GPUs_GPUManufacturerId",
                table: "GPUs");

            migrationBuilder.DropIndex(
                name: "IX_Drives_DriveTypeId",
                table: "Drives");

            migrationBuilder.DropIndex(
                name: "IX_CPUs_CPUManufacturerId",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "RAMs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "RAMs");

            migrationBuilder.DropColumn(
                name: "Manufacturer_id",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Drives");

            migrationBuilder.DropColumn(
                name: "CPUManufacturerId",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "Manufacturer_id",
                table: "CPUs");

            migrationBuilder.RenameColumn(
                name: "GPUManufacturerId",
                table: "GPUs",
                newName: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "DriveTypeId",
                table: "Drives",
                newName: "DriveType");

            migrationBuilder.RenameColumn(
                name: "Cores",
                table: "CPUs",
                newName: "Manufacturer");

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laptops_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_ConfigurationId",
                table: "Models",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_ModelId",
                table: "Laptops",
                column: "ModelId");
        }
    }
}
