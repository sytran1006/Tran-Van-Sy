using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JamesTranproject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anouncements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeUse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourceUse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anouncements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HowDoIs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IconQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HowDoIs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageGallerys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageGallerys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeUse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuickLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoGallerys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGallerys", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Anouncements",
                columns: new[] { "Id", "DateTimeUse", "Img", "Introduction", "ResourceUse", "Title" },
                values: new object[,]
                {
                    { 1, "05/Jan/2021", "Image.image_gallery", "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.", "Human Resource", "New Learing System Is Live" },
                    { 2, "05/Jan/2021", "Image.image_gallery_1", "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.", "Human Resource", "New Learing System Is Live" },
                    { 3, "05/Jan/2021", "Image.image_gallery_2", "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.", "Human Resource", "New Learing System Is Live" },
                    { 4, "05/Jan/2021", "Image.image_gallery_3", "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.", "Human Resource", "New Learing System Is Live" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Day", "Img", "Number", "Time", "Title" },
                values: new object[,]
                {
                    { 1, "Jan", "Image.clock", "01", "09:00 AM - 09:30 AM", "Register Portal" },
                    { 2, "Jan", "Image.clock", "02", "09:00 AM - 09:30 AM", "Register Portal" },
                    { 3, "Jan", "Image.clock", "03", "09:00 AM - 09:30 AM", "Register Portal" },
                    { 4, "Jan", "Image.clock", "04", "09:00 AM - 09:30 AM", "Register Portal" }
                });

            migrationBuilder.InsertData(
                table: "HowDoIs",
                columns: new[] { "Id", "Answer", "IconAnswer", "IconQuestion", "Question" },
                values: new object[,]
                {
                    { 1, "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisiut aliquip ex ea commodo consequat. Duis uis.", "Image.expand", "Image.collapse", "What do you do?" },
                    { 2, "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisiut aliquip ex ea commodo consequat. Duis uis.", "Image.expand", "Image.collapse", "What do you do?" },
                    { 3, "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisiut aliquip ex ea commodo consequat. Duis uis.", "Image.expand", "Image.collapse", "What do you do?" }
                });

            migrationBuilder.InsertData(
                table: "ImageGallerys",
                columns: new[] { "Id", "Img" },
                values: new object[,]
                {
                    { 1, "Image.image_gallery_1" },
                    { 2, "Image.image_gallery_2" },
                    { 3, "Image.image_gallery_3" },
                    { 4, "Image.image_gallery_4" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "DateTimeUse", "Img", "Introduction", "Title" },
                values: new object[,]
                {
                    { 1, "05/Jan/2021", "Image.markgroup2", "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.", "Tomorrow Healthy Check" },
                    { 2, "05/Jan/2021", "Image.markgroup_1", "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.", "Tomorrow Healthy Check" },
                    { 3, "05/Jan/2021", "Image.markgroup_2", "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.", "Tomorrow Healthy Check" },
                    { 4, "05/Jan/2021", "Image.markgroup_3", "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.", "Tomorrow Healthy Check" }
                });

            migrationBuilder.InsertData(
                table: "QuickLinks",
                columns: new[] { "Id", "Img", "Title" },
                values: new object[,]
                {
                    { 1, "Image.icon", "Training" },
                    { 2, "Image.icon_1", "Organization" },
                    { 3, "Image.icon_2", "Task" }
                });

            migrationBuilder.InsertData(
                table: "VideoGallerys",
                columns: new[] { "Id", "Video" },
                values: new object[,]
                {
                    { 1, "Image.video" },
                    { 2, "Image.video_1" },
                    { 3, "Image.video_2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anouncements");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "HowDoIs");

            migrationBuilder.DropTable(
                name: "ImageGallerys");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "QuickLinks");

            migrationBuilder.DropTable(
                name: "VideoGallerys");
        }
    }
}
