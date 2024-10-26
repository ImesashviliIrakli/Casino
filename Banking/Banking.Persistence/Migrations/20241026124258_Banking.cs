using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banking.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Banking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    MinimumLimit = table.Column<decimal>(type: "numeric", nullable: false),
                    MaximumLimit = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentDirection = table.Column<int>(type: "integer", nullable: false),
                    IsTest = table.Column<bool>(type: "boolean", nullable: false),
                    IsDisabled = table.Column<bool>(type: "boolean", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentSystemId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerUserId = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    PaymentDirection = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRequests_PaymentSystems_PaymentSystemId",
                        column: x => x.PaymentSystemId,
                        principalTable: "PaymentSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequests_PaymentSystemId",
                table: "PaymentRequests",
                column: "PaymentSystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentRequests");

            migrationBuilder.DropTable(
                name: "PaymentSystems");
        }
    }
}
