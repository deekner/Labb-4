using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb_4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HobbyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    HobbyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Links_Hobbys_HobbyID",
                        column: x => x.HobbyID,
                        principalTable: "Hobbys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hobbys",
                columns: new[] { "ID", "Description", "HobbyName" },
                values: new object[,]
                {
                    { 1, "Loves to go to car meets as well as car shows", "Cars" },
                    { 2, "Nothing beats fishing with a nice summerbreeze", "Fishing" },
                    { 3, "There's something satisfying with building computers", "Computers" },
                    { 4, "What a way to relax when reading a book and earn knowledge", "Books" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "ID", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Dennis", "0743884618" },
                    { 2, "John", "0742143245" },
                    { 3, "King", "0743453447" },
                    { 4, "Thomas", "0756756467" },
                    { 5, "Igor", "0767456446" },
                    { 6, "Affe", "0744564472" },
                    { 7, "Vivien", "0713454565" },
                    { 8, "Cecilia", "0746867285" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "ID", "HobbyID", "LinkName", "PersonID", "URL" },
                values: new object[,]
                {
                    { 1, 1, "SchmiedMann", 1, "https://www.schmiedmann.se/" },
                    { 2, 2, "Fiske", 2, "https://www.fiske.se/" },
                    { 3, 3, "Komplett", 3, "https://www.komplett.se/" },
                    { 4, 4, "AkademiBokHandeln", 4, "https://www.akademibokhandeln.se/" },
                    { 5, 1, "SchmiedMann", 5, "https://www.schmiedmann.se/" },
                    { 6, 2, "Fiske", 6, "https://www.fiske.se/" },
                    { 7, 3, "Komplett", 7, "https://www.komplett.se/" },
                    { 8, 4, "AkademiBokHandeln", 8, "https://www.akademibokhandeln.se/" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_HobbyID",
                table: "Links",
                column: "HobbyID");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonID",
                table: "Links",
                column: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Hobbys");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
