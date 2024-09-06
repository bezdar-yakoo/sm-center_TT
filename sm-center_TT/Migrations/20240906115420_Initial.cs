using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sm_center_TT.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabinets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabinetId = table.Column<int>(type: "int", nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    PolyclinicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adderss = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
                    PolyclinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Polyclinics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false, comment: "The URL of the blog")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polyclinics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cabinets",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, 101 },
                    { 2, 102 },
                    { 3, 103 },
                    { 4, 104 },
                    { 5, 105 },
                    { 6, 108 },
                    { 7, 109 },
                    { 8, 110 },
                    { 9, 107 },
                    { 10, 100 }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "CabinetId", "FullName", "PolyclinicId", "SpecializationId" },
                values: new object[,]
                {
                    { 1, 5, "Соколов Роман Кириллович", null, 3 },
                    { 2, 6, "Ермолаева Алиса Кирилловна", 1, 2 },
                    { 3, 7, "Лосева Марьям Артемьевна", 2, 1 },
                    { 4, 8, "Константинова Виктория Ильинична", 3, 10 },
                    { 5, 9, "Антипов Даниил Савельевич", 4, 9 },
                    { 6, 10, "Ермаков Владислав Ильич", 5, 8 },
                    { 7, 1, "Колесникова Полина Егоровна", 6, 7 },
                    { 8, 2, "Владимирова Аделина Львовна", 7, 6 },
                    { 9, 3, "Гордеев Артемий Семёнович", 8, 5 },
                    { 10, 4, "Кириллова Виктория Владимировна", 9, 4 },
                    { 11, 5, "Гришина София Матвеевна", 10, 3 },
                    { 12, 6, "Ушаков Василий Александрович", null, 2 },
                    { 13, 7, "Соловьев Иван Маркович", 1, 1 },
                    { 14, 8, "Пахомова Вероника Данииловна", 2, 10 },
                    { 15, 9, "Зайцев Михаил Михайлович", 3, 9 },
                    { 16, 10, "Сафонова Варвара Дмитриевна", 4, 8 },
                    { 17, 1, "Титова Ариана Фёдоровна", 5, 7 },
                    { 18, 2, "Маркова Ева Владимировна", 6, 6 },
                    { 19, 3, "Абрамова Дарья Петровна", 7, 5 },
                    { 20, 4, "Степанова Алиса Григорьевна", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Adderss", "BirthDay", "FirstName", "IsMale", "MiddleName", "PolyclinicId", "SecondName" },
                values: new object[,]
                {
                    { 1, "Россия, г. Калининград, Космонавтов ул., д. 25 кв.18", new DateTime(2000, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Павлов ", true, "Ильич", 1, "Максим " },
                    { 2, "Россия, г. Петрозаводск, Ленинская ул., д. 21 кв.19", new DateTime(2000, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Воронина ", false, "Даниловна", 2, "Ева " },
                    { 3, "Россия, г. Подольск, Октябрьская ул., д. 21 кв.158", new DateTime(2000, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Измайлова ", false, "Олеговна", 3, "Варвара " },
                    { 4, "Россия, г. Черкесск, Лесной пер., д. 23 кв.58", new DateTime(2000, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Поляков ", true, "Даниилович", 4, "Демьян " },
                    { 5, "Россия, г. Ангарск, Ленина В.И.ул., д. 9 кв.84", new DateTime(2000, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Соколова ", false, "Владимировна", 6, "Анна " },
                    { 6, "Россия, г. Евпатория, Колхозный пер., д. 20 кв.59", new DateTime(2000, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Горюнов ", true, "Иванович", 7, "Тимур " },
                    { 7, "Россия, г. Кострома, ЯнкиКупалы ул., д. 2 кв.213", new DateTime(2000, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лебедев ", true, "Тимофеевич", 8, "Константин " },
                    { 8, "Россия, г. Рубцовск, Мирная ул., д. 13 кв.24", new DateTime(2000, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Воронин ", true, "Макарович", 9, "Кирилл " }
                });

            migrationBuilder.InsertData(
                table: "Polyclinics",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Polyclinics",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Врач-кардиолог" },
                    { 2, "Врач-отоларинголог" },
                    { 3, "Врач-терапевт" },
                    { 4, "Врач-уролог" },
                    { 5, "Врач-акушер-гинеколог" },
                    { 6, "Врач-ревматолог" },
                    { 7, "Врач-офтальмолог" },
                    { 8, "Врач-дерматовенеролог" },
                    { 9, "Врач-психиатр" },
                    { 10, "Врач мануальной терапии" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cabinets");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Polyclinics");

            migrationBuilder.DropTable(
                name: "Specializations");
        }
    }
}
