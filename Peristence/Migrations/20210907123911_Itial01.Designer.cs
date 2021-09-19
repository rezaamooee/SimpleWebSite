﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Peristence.Context;

namespace Peristence.Migrations
{
    [DbContext(typeof(SiteDbContext))]
    [Migration("20210907123911_Itial01")]
    partial class Itial01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Persian_100_CI_AI")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.DBEntities.EntLogin", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HashKey1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashKey2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Entity.DBEntities.EntPost", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ABS")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("AuthoreID")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PicSRC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TopicID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("WriteDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AuthoreID");

                    b.HasIndex("TopicID");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            ABS = "در این دوره شما زبان برنامه نویسی سی شارپ، که یکی از قدرتمند ترین زبان های برنامه نویسی شیء گرا می باشد را از 0 تا 100 آموزش خواهید دید و پس از یادگیری با کمک این زبان می توانید تکنولوژی مورد ",
                            AuthoreID = 1L,
                            Content = "در این دوره شما زبان برنامه نویسی سی شارپ، که یکی از قدرتمند ترین زبان های برنامه نویسی شیء گرا می باشد را از 0 تا 100 آموزش خواهید دید و پس از یادگیری با کمک این زبان می توانید تکنولوژی مورد علاقه خود را (وب، ویندوز و موبایل) انتخاب کرده و هرچه سریع تر در آن حرفه ای شوید\r\nپیش نیاز های این دوره :\r\n\r\nاین دوره پیش نیازی ندارد .",
                            EngName = "Learning C #  ",
                            IsActive = true,
                            PicSRC = "https://toplearn.com/img/course/img-course-%D8%B4%D9%86%D8%A8%D9%87-%DB%B1%DB%B5-%D8%A7%D8%B1%D8%AF%DB%8C%D8%A8%D9%87%D8%B4%D8%AA-%DB%B1%DB%B3%DB%B9%DB%B7-61064385-586.jpeg",
                            Title = "آموزش سی شارپ",
                            TopicID = 4L,
                            WriteDate = new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            ID = 2L,
                            ABS = "فناوری اطلاعات عرصه نوینی را به منظور پیشرفت افراد و جوامع در دنیای امروز به روی همگان گشوده است. بدون شک از ",
                            AuthoreID = 1L,
                            Content = "فناوری اطلاعات عرصه نوینی را به منظور پیشرفت افراد و جوامع در دنیای امروز به روی همگان گشوده است. بدون شک از دانش شبکه می توان به عنوان یکی از مهم ترین این تخصص ها نام برد. کسب مهارت در زمینه +Network و به تبع آن مهارت در پیاده سازی و اجرای شبکه های پایه به رفع مشکلات سازمان ها در این حوزه کمک شایانی می کند. این فرادرس به عنوان پیش نیاز کلیه دوره های تخصصی شبکه به شما کمک خواهد کرد تا به عنوان تکنیسین شبکه، جهت ورود به بازار کار و نیز دوره های تخصصی تر شبکه از جمله دوره های مایکروسافت، سیسکو، لینوکس و امنیت شبکه آماده شوید.",
                            EngName = "Net+ training ",
                            IsActive = true,
                            PicSRC = "https://faradars.org/wp-content/uploads/2016/10/fvnet9410-svg.svg",
                            Title = "آموزش نتورک پلاس",
                            TopicID = 5L,
                            WriteDate = new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            ID = 3L,
                            ABS = "امروزه دیگر به جای اینکه یک کامپیوتر بزرگ کلیه کارهای محاسباتی را انجام دهد، تعداد زیادی کامپیوتر کوچک ",
                            AuthoreID = 1L,
                            Content = "امروزه دیگر به جای اینکه یک کامپیوتر بزرگ کلیه کارهای محاسباتی را انجام دهد، تعداد زیادی کامپیوتر کوچک که به هم متصل هستند، این کار را انجام می دهند. به این سیستم ها شبکه های کامپیوتری گفته می شود. شبکه های کامپیوتری به خاطر کاربرد بسیار زیاد شبکه ها در محیط های کاری از دروس مهم و کاربردی رشته مهندسی برق و کامپیوتر به شمار می رود. هدف این فرادرس فراگیری مباحث تخصصی در حوزه شبکه برای دانشجویان رشته برق و مخابرات است. در ضمن این درس مقدمه ورود به دروش پیشرفته تر در ارشد مخابرات در زمینه شبکه های مخابرات بی سیم محسوب می شود.",
                            EngName = "Network training ",
                            IsActive = true,
                            PicSRC = "https://faradars.org/wp-content/uploads/2016/09/fvsft113-svg.svg",
                            Title = "آموزش شبکه های کامپیوتری",
                            TopicID = 5L,
                            WriteDate = new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            ID = 4L,
                            ABS = "عالی ترین خدمات نرم افزاری با حداقل هزینه در کمترین زمان ممکن را از مرکز خدمات و تعمیرات تخصصی ناوک مطالبه نمایید.",
                            AuthoreID = 1L,
                            Content = "\r\n\r\nبخشی از خدمات نرم افزاری ارائه شده در مرکز خدمات و تعمیرات تخصصی ناوک شامل نصب انواع سیستم عامل ها به صورت تخصصی به همراه کلیه درایورها و به همراه تضمین صحت کارکرد می‌باشد. خدمات نرم افزاری سیستم عامل ویندوز٬ خدمات نرم افزاری سیستم عامل مک٬ خدمات نرم افزاری سیستم عامل لینوکس نیز در این مرکز ارائه می‌شود.\r\n\r\nدر مرکز خدمات و تعمیرات تخصصی ناوک تمامی خدمات نرم افزاری عمومی و تخصصی انجام میپذیرد. عیب یابی های تخصصی نرم افزاری٬ برطرف کردن ایرادات درایور٬ حل مشکلات نرم افزاری٬ نصب نرم افزارهای عموم و تخصصی و هر نوع خدمات نرم افزاری مورد نیاز مشتری.\r\n",
                            EngName = "Software Services ",
                            IsActive = true,
                            PicSRC = "https://navakservices.com/wp-content/uploads/2018/04/khadamatenarmafzari-300x243.jpg",
                            Title = "خدمات نرم افزاری",
                            TopicID = 4L,
                            WriteDate = new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("Entity.DBEntities.EntRole", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Permision")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            IsActive = true,
                            Name = "Admin",
                            Permision = 111
                        },
                        new
                        {
                            ID = 2L,
                            IsActive = true,
                            Name = "Block",
                            Permision = 0
                        },
                        new
                        {
                            ID = 3L,
                            IsActive = true,
                            Name = "Guest",
                            Permision = 100
                        },
                        new
                        {
                            ID = 4L,
                            IsActive = true,
                            Name = "Author",
                            Permision = 10
                        },
                        new
                        {
                            ID = 5L,
                            IsActive = true,
                            Name = "Maintenance",
                            Permision = 1
                        },
                        new
                        {
                            ID = 6L,
                            IsActive = true,
                            Name = "Reporter",
                            Permision = 101
                        },
                        new
                        {
                            ID = 7L,
                            IsActive = true,
                            Name = "Chief Editor",
                            Permision = 110
                        },
                        new
                        {
                            ID = 8L,
                            IsActive = true,
                            Name = "SemiAdmin",
                            Permision = 11
                        });
                });

            modelBuilder.Entity("Entity.DBEntities.EntTopic", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HasChilde")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long>("ParrentID")
                        .HasColumnType("bigint");

                    b.Property<string>("PicSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            HasChilde = true,
                            IsActive = true,
                            ParrentID = 0L,
                            PicSrc = "https://www.educationcorner.com/images/featured-importance-education.png",
                            Title = "آموزش"
                        },
                        new
                        {
                            ID = 2L,
                            HasChilde = true,
                            IsActive = true,
                            ParrentID = 0L,
                            PicSrc = "https://cdn.corporatefinanceinstitute.com/assets/products-and-services-1024x1024.jpeg",
                            Title = "خدمات"
                        },
                        new
                        {
                            ID = 3L,
                            HasChilde = true,
                            IsActive = true,
                            ParrentID = 0L,
                            PicSrc = "https://www.phoca.cz/images/projects/phoca-download-r.svg",
                            Title = "دانلود"
                        },
                        new
                        {
                            ID = 4L,
                            HasChilde = false,
                            IsActive = true,
                            ParrentID = 1L,
                            PicSrc = "https://www.avenga.com/wp-content/uploads/2020/11/C-Sharp-1536x864.png",
                            Title = "سی شارپ"
                        },
                        new
                        {
                            ID = 5L,
                            HasChilde = true,
                            IsActive = true,
                            ParrentID = 1L,
                            PicSrc = "https://s3.amazonaws.com/eaglecom.net/news/June2019/xn9Tq8YRbeCzzoYios3kvdMT.png",
                            Title = "شبکه"
                        },
                        new
                        {
                            ID = 6L,
                            HasChilde = false,
                            IsActive = true,
                            ParrentID = 2L,
                            PicSrc = "https://miuc.org/wp-content/uploads/2020/08/6-Reasons-why-you-should-learn-Programming-737x366.png",
                            Title = "برنامه نویسی"
                        },
                        new
                        {
                            ID = 7L,
                            HasChilde = false,
                            IsActive = true,
                            ParrentID = 2L,
                            PicSrc = "https://electronicsguide4u.com/wp-content/uploads/2018/09/client-341420_1920.png",
                            Title = "شبکه"
                        },
                        new
                        {
                            ID = 8L,
                            HasChilde = false,
                            IsActive = true,
                            ParrentID = 3L,
                            PicSrc = "https://tosinso.com/files/get/3bf06a08-04af-49ee-8d58-9b64cce37984",
                            Title = "نرم افزار های برنامه نویسی"
                        });
                });

            modelBuilder.Entity("Entity.DBEntities.EntUser", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("RoleID")
                        .HasColumnType("bigint");

                    b.Property<string>("Tell")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.HasIndex(new[] { "Email" }, "IX_EntUser_Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex(new[] { "Username" }, "IX_EntUser_Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Address = "Tehran-Dampezeshki ST - Salimpur Aley- No 23",
                            BirthDate = new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "Sir.rama2000@Gmail.com",
                            IsActive = true,
                            LastName = "Amooee",
                            Name = "Reza",
                            Password = "$MYHASH$V1$10000$uZSXbE9ioQSqHw+C7VWZWBmbEyovUmOHuoN19LoHW4S80YCQ",
                            RegDate = new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            RoleID = 1L,
                            Tell = "09128168046",
                            Username = "RezaAmooee"
                        });
                });

            modelBuilder.Entity("Entity.DBEntities.EntLogin", b =>
                {
                    b.HasOne("Entity.DBEntities.EntUser", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entity.DBEntities.EntPost", b =>
                {
                    b.HasOne("Entity.DBEntities.EntUser", "Authore")
                        .WithMany("Posts")
                        .HasForeignKey("AuthoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.DBEntities.EntTopic", "Topic")
                        .WithMany("Posts")
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authore");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Entity.DBEntities.EntUser", b =>
                {
                    b.HasOne("Entity.DBEntities.EntRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Entity.DBEntities.EntRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Entity.DBEntities.EntTopic", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Entity.DBEntities.EntUser", b =>
                {
                    b.Navigation("Logins");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
