using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyAsp.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Artificial Intelligence", "AI" },
                    { 2, "Machine Learning", "ML" },
                    { 3, "Analysis of large data sets", "Data Science" },
                    { 4, "Building and maintaining websites", "Web Development" },
                    { 5, "Developing mobile applications", "Mobile Development" },
                    { 6, "Development and operations practices", "DevOps" },
                    { 7, "Protecting systems and data", "Cybersecurity" },
                    { 8, "Using cloud-based infrastructure", "Cloud Computing" },
                    { 9, "Internet of Things devices and systems", "IoT" },
                    { 10, "Decentralized ledger technology", "Blockchain" },
                    { 11, "Creating video games", "Game Development" },
                    { 12, "Designing user interfaces and experiences", "UI/UX Design" },
                    { 13, "Programming hardware devices", "Embedded Systems" },
                    { 14, "Augmented and Virtual Reality technologies", "AR/VR" },
                    { 15, "Handling massive amounts of data", "Big Data" },
                    { 16, "Design and operation of robots", "Robotics" },
                    { 17, "Ensuring software quality", "Software Testing" },
                    { 18, "Connecting computers and devices", "Networking" },
                    { 19, "Promoting products online", "Digital Marketing" },
                    { 20, "Online buying and selling", "E-Commerce" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
