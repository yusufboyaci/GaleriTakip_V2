using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cargalleries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MasterId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(name: "Created Date", type: "timestamp with time zone", nullable: true),
                    CreatedComputerName = table.Column<string>(name: "Created Computer Name", type: "text", nullable: true),
                    CreatedIP = table.Column<string>(name: "Created IP", type: "text", nullable: true),
                    CreatedADUsername = table.Column<string>(name: "Created AD Username", type: "text", nullable: true),
                    CreatedBy = table.Column<string>(name: "Created By", type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(name: "Modified Date", type: "timestamp with time zone", nullable: true),
                    ModifiedComputerName = table.Column<string>(name: "Modified Computer Name", type: "text", nullable: true),
                    ModifiedIP = table.Column<string>(name: "Modified IP", type: "text", nullable: true),
                    ModifiedADUsername = table.Column<string>(name: "Modified AD Username", type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(name: "Modified By", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargalleries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: true),
                    MasterId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(name: "Created Date", type: "timestamp with time zone", nullable: true),
                    CreatedComputerName = table.Column<string>(name: "Created Computer Name", type: "text", nullable: true),
                    CreatedIP = table.Column<string>(name: "Created IP", type: "text", nullable: true),
                    CreatedADUsername = table.Column<string>(name: "Created AD Username", type: "text", nullable: true),
                    CreatedBy = table.Column<string>(name: "Created By", type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(name: "Modified Date", type: "timestamp with time zone", nullable: true),
                    ModifiedComputerName = table.Column<string>(name: "Modified Computer Name", type: "text", nullable: true),
                    ModifiedIP = table.Column<string>(name: "Modified IP", type: "text", nullable: true),
                    ModifiedADUsername = table.Column<string>(name: "Modified AD Username", type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(name: "Modified By", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    Stock = table.Column<int>(type: "integer", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    Descripton = table.Column<string>(type: "text", nullable: true),
                    CarGalleryId = table.Column<Guid>(type: "uuid", nullable: false),
                    MasterId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(name: "Created Date", type: "timestamp with time zone", nullable: true),
                    CreatedComputerName = table.Column<string>(name: "Created Computer Name", type: "text", nullable: true),
                    CreatedIP = table.Column<string>(name: "Created IP", type: "text", nullable: true),
                    CreatedADUsername = table.Column<string>(name: "Created AD Username", type: "text", nullable: true),
                    CreatedBy = table.Column<string>(name: "Created By", type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(name: "Modified Date", type: "timestamp with time zone", nullable: true),
                    ModifiedComputerName = table.Column<string>(name: "Modified Computer Name", type: "text", nullable: true),
                    ModifiedIP = table.Column<string>(name: "Modified IP", type: "text", nullable: true),
                    ModifiedADUsername = table.Column<string>(name: "Modified AD Username", type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(name: "Modified By", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cars_cargalleries_CarGalleryId",
                        column: x => x.CarGalleryId,
                        principalTable: "cargalleries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    MasterId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(name: "Created Date", type: "timestamp with time zone", nullable: true),
                    CreatedComputerName = table.Column<string>(name: "Created Computer Name", type: "text", nullable: true),
                    CreatedIP = table.Column<string>(name: "Created IP", type: "text", nullable: true),
                    CreatedADUsername = table.Column<string>(name: "Created AD Username", type: "text", nullable: true),
                    CreatedBy = table.Column<string>(name: "Created By", type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(name: "Modified Date", type: "timestamp with time zone", nullable: true),
                    ModifiedComputerName = table.Column<string>(name: "Modified Computer Name", type: "text", nullable: true),
                    ModifiedIP = table.Column<string>(name: "Modified IP", type: "text", nullable: true),
                    ModifiedADUsername = table.Column<string>(name: "Modified AD Username", type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(name: "Modified By", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customers_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    MasterId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(name: "Created Date", type: "timestamp with time zone", nullable: true),
                    CreatedComputerName = table.Column<string>(name: "Created Computer Name", type: "text", nullable: true),
                    CreatedIP = table.Column<string>(name: "Created IP", type: "text", nullable: true),
                    CreatedADUsername = table.Column<string>(name: "Created AD Username", type: "text", nullable: true),
                    CreatedBy = table.Column<string>(name: "Created By", type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(name: "Modified Date", type: "timestamp with time zone", nullable: true),
                    ModifiedComputerName = table.Column<string>(name: "Modified Computer Name", type: "text", nullable: true),
                    ModifiedIP = table.Column<string>(name: "Modified IP", type: "text", nullable: true),
                    ModifiedADUsername = table.Column<string>(name: "Modified AD Username", type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(name: "Modified By", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "orderdetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    CarId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    MasterId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(name: "Created Date", type: "timestamp with time zone", nullable: true),
                    CreatedComputerName = table.Column<string>(name: "Created Computer Name", type: "text", nullable: true),
                    CreatedIP = table.Column<string>(name: "Created IP", type: "text", nullable: true),
                    CreatedADUsername = table.Column<string>(name: "Created AD Username", type: "text", nullable: true),
                    CreatedBy = table.Column<string>(name: "Created By", type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(name: "Modified Date", type: "timestamp with time zone", nullable: true),
                    ModifiedComputerName = table.Column<string>(name: "Modified Computer Name", type: "text", nullable: true),
                    ModifiedIP = table.Column<string>(name: "Modified IP", type: "text", nullable: true),
                    ModifiedADUsername = table.Column<string>(name: "Modified AD Username", type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(name: "Modified By", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderdetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderdetails_cars_CarId",
                        column: x => x.CarId,
                        principalTable: "cars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_orderdetails_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_CarGalleryId",
                table: "cars",
                column: "CarGalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_customers_UserId",
                table: "customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_CarId",
                table: "orderdetails",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_OrderId",
                table: "orderdetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderdetails");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "cargalleries");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
