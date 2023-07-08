using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEKEnable.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SignUpDetails",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SourceOfInformation = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Other = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Reason = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUpDetails", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignUpDetails");
        }
    }
}
