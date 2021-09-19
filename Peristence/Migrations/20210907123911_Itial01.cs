using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Peristence.Migrations
{
    public partial class Itial01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permision = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PicSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasChilde = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ParrentID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    HashKey1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HashKey2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Logins_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthoreID = table.Column<long>(type: "bigint", nullable: false),
                    TopicID = table.Column<long>(type: "bigint", nullable: false),
                    EngName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PicSRC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ABS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WriteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Posts_Topics_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthoreID",
                        column: x => x.AuthoreID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "IsActive", "Name", "Permision" },
                values: new object[,]
                {
                    { 1L, true, "Admin", 111 },
                    { 2L, true, "Block", 0 },
                    { 3L, true, "Guest", 100 },
                    { 4L, true, "Author", 10 },
                    { 5L, true, "Maintenance", 1 },
                    { 6L, true, "Reporter", 101 },
                    { 7L, true, "Chief Editor", 110 },
                    { 8L, true, "SemiAdmin", 11 }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "ID", "HasChilde", "IsActive", "ParrentID", "PicSrc", "Title" },
                values: new object[,]
                {
                    { 1L, true, true, 0L, "https://www.educationcorner.com/images/featured-importance-education.png", "آموزش" },
                    { 2L, true, true, 0L, "https://cdn.corporatefinanceinstitute.com/assets/products-and-services-1024x1024.jpeg", "خدمات" },
                    { 3L, true, true, 0L, "https://www.phoca.cz/images/projects/phoca-download-r.svg", "دانلود" },
                    { 4L, false, true, 1L, "https://www.avenga.com/wp-content/uploads/2020/11/C-Sharp-1536x864.png", "سی شارپ" },
                    { 5L, true, true, 1L, "https://s3.amazonaws.com/eaglecom.net/news/June2019/xn9Tq8YRbeCzzoYios3kvdMT.png", "شبکه" },
                    { 6L, false, true, 2L, "https://miuc.org/wp-content/uploads/2020/08/6-Reasons-why-you-should-learn-Programming-737x366.png", "برنامه نویسی" },
                    { 7L, false, true, 2L, "https://electronicsguide4u.com/wp-content/uploads/2018/09/client-341420_1920.png", "شبکه" },
                    { 8L, false, true, 3L, "https://tosinso.com/files/get/3bf06a08-04af-49ee-8d58-9b64cce37984", "نرم افزار های برنامه نویسی" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "BirthDate", "Email", "IsActive", "LastName", "Name", "Password", "RegDate", "RoleID", "Tell", "Username" },
                values: new object[] { 1L, "Tehran-Dampezeshki ST - Salimpur Aley- No 23", new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Local), "Sir.rama2000@Gmail.com", true, "Amooee", "Reza", "$MYHASH$V1$10000$uZSXbE9ioQSqHw+C7VWZWBmbEyovUmOHuoN19LoHW4S80YCQ", new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Local), 1L, "09128168046", "RezaAmooee" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "ABS", "AuthoreID", "Content", "EngName", "IsActive", "PicSRC", "Title", "TopicID", "WriteDate" },
                values: new object[,]
                {
                    { 1L, "در این دوره شما زبان برنامه نویسی سی شارپ، که یکی از قدرتمند ترین زبان های برنامه نویسی شیء گرا می باشد را از 0 تا 100 آموزش خواهید دید و پس از یادگیری با کمک این زبان می توانید تکنولوژی مورد ", 1L, "در این دوره شما زبان برنامه نویسی سی شارپ، که یکی از قدرتمند ترین زبان های برنامه نویسی شیء گرا می باشد را از 0 تا 100 آموزش خواهید دید و پس از یادگیری با کمک این زبان می توانید تکنولوژی مورد علاقه خود را (وب، ویندوز و موبایل) انتخاب کرده و هرچه سریع تر در آن حرفه ای شوید\r\nپیش نیاز های این دوره :\r\n\r\nاین دوره پیش نیازی ندارد .", "Learning C #  ", true, "https://toplearn.com/img/course/img-course-%D8%B4%D9%86%D8%A8%D9%87-%DB%B1%DB%B5-%D8%A7%D8%B1%D8%AF%DB%8C%D8%A8%D9%87%D8%B4%D8%AA-%DB%B1%DB%B3%DB%B9%DB%B7-61064385-586.jpeg", "آموزش سی شارپ", 4L, new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2L, "فناوری اطلاعات عرصه نوینی را به منظور پیشرفت افراد و جوامع در دنیای امروز به روی همگان گشوده است. بدون شک از ", 1L, "فناوری اطلاعات عرصه نوینی را به منظور پیشرفت افراد و جوامع در دنیای امروز به روی همگان گشوده است. بدون شک از دانش شبکه می توان به عنوان یکی از مهم ترین این تخصص ها نام برد. کسب مهارت در زمینه +Network و به تبع آن مهارت در پیاده سازی و اجرای شبکه های پایه به رفع مشکلات سازمان ها در این حوزه کمک شایانی می کند. این فرادرس به عنوان پیش نیاز کلیه دوره های تخصصی شبکه به شما کمک خواهد کرد تا به عنوان تکنیسین شبکه، جهت ورود به بازار کار و نیز دوره های تخصصی تر شبکه از جمله دوره های مایکروسافت، سیسکو، لینوکس و امنیت شبکه آماده شوید.", "Net+ training ", true, "https://faradars.org/wp-content/uploads/2016/10/fvnet9410-svg.svg", "آموزش نتورک پلاس", 5L, new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3L, "امروزه دیگر به جای اینکه یک کامپیوتر بزرگ کلیه کارهای محاسباتی را انجام دهد، تعداد زیادی کامپیوتر کوچک ", 1L, "امروزه دیگر به جای اینکه یک کامپیوتر بزرگ کلیه کارهای محاسباتی را انجام دهد، تعداد زیادی کامپیوتر کوچک که به هم متصل هستند، این کار را انجام می دهند. به این سیستم ها شبکه های کامپیوتری گفته می شود. شبکه های کامپیوتری به خاطر کاربرد بسیار زیاد شبکه ها در محیط های کاری از دروس مهم و کاربردی رشته مهندسی برق و کامپیوتر به شمار می رود. هدف این فرادرس فراگیری مباحث تخصصی در حوزه شبکه برای دانشجویان رشته برق و مخابرات است. در ضمن این درس مقدمه ورود به دروش پیشرفته تر در ارشد مخابرات در زمینه شبکه های مخابرات بی سیم محسوب می شود.", "Network training ", true, "https://faradars.org/wp-content/uploads/2016/09/fvsft113-svg.svg", "آموزش شبکه های کامپیوتری", 5L, new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4L, "عالی ترین خدمات نرم افزاری با حداقل هزینه در کمترین زمان ممکن را از مرکز خدمات و تعمیرات تخصصی ناوک مطالبه نمایید.", 1L, "\r\n\r\nبخشی از خدمات نرم افزاری ارائه شده در مرکز خدمات و تعمیرات تخصصی ناوک شامل نصب انواع سیستم عامل ها به صورت تخصصی به همراه کلیه درایورها و به همراه تضمین صحت کارکرد می‌باشد. خدمات نرم افزاری سیستم عامل ویندوز٬ خدمات نرم افزاری سیستم عامل مک٬ خدمات نرم افزاری سیستم عامل لینوکس نیز در این مرکز ارائه می‌شود.\r\n\r\nدر مرکز خدمات و تعمیرات تخصصی ناوک تمامی خدمات نرم افزاری عمومی و تخصصی انجام میپذیرد. عیب یابی های تخصصی نرم افزاری٬ برطرف کردن ایرادات درایور٬ حل مشکلات نرم افزاری٬ نصب نرم افزارهای عموم و تخصصی و هر نوع خدمات نرم افزاری مورد نیاز مشتری.\r\n", "Software Services ", true, "https://navakservices.com/wp-content/uploads/2018/04/khadamatenarmafzari-300x243.jpg", "خدمات نرم افزاری", 4L, new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserID",
                table: "Logins",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthoreID",
                table: "Posts",
                column: "AuthoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicID",
                table: "Posts",
                column: "TopicID");

            migrationBuilder.CreateIndex(
                name: "IX_EntUser_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EntUser_Username",
                table: "Users",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
