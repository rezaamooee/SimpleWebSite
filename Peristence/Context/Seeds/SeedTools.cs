using Common.PublicServices;
using Entity.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Peristence.Context.Seeds
{
    public static class SeedTools
    {
        public static void RolesSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntRole>().HasData(
                new EntRole { ID = 1, IsActive = true, Name = "Admin", Permision = Entity.Tools.Permision.rwx },
                new EntRole { ID = 2, IsActive = true, Name = "Block", Permision = Entity.Tools.Permision.none },
                new EntRole { ID = 3, IsActive = true, Name = "Guest", Permision = Entity.Tools.Permision.r },
                new EntRole { ID = 4, IsActive = true, Name = "Author", Permision = Entity.Tools.Permision.w },
                new EntRole { ID = 5, IsActive = true, Name = "Maintenance", Permision = Entity.Tools.Permision.x },
                new EntRole { ID = 6, IsActive = true, Name = "Reporter", Permision = Entity.Tools.Permision.rx },
                new EntRole { ID = 7, IsActive = true, Name = "Chief Editor", Permision = Entity.Tools.Permision.rw },
                new EntRole { ID = 8, IsActive = true, Name = "SemiAdmin", Permision = Entity.Tools.Permision.wx }

                );
        }
        public static void UsersSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntUser>().HasData(
                new EntUser
                {
                    ID = 1,
                    RoleID = 1,
                    Name = "Reza",
                    LastName = "Amooee",
                    Username = "RezaAmooee",
                    Password = Hasher.Hash("0010522875"),
                    Email = "Sir.rama2000@Gmail.com",
                    IsActive = true,
                    Tell = "09128168046",
                    BirthDate = DateTime.Now.Date,
                    Address = "Tehran-Dampezeshki ST - Salimpur Aley- No 23",
                    RegDate = DateTime.Now.Date
                });
        }
        public static void TopicsSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntTopic>().HasData(
                new EntTopic { ID = 1, HasChilde = true, IsActive = true, ParrentID = 0, Title = "آموزش", PicSrc = @"https://www.educationcorner.com/images/featured-importance-education.png" },//1
                new EntTopic { ID = 2, HasChilde = true, IsActive = true, ParrentID = 0, Title = "خدمات", PicSrc = @"https://cdn.corporatefinanceinstitute.com/assets/products-and-services-1024x1024.jpeg" },//2
                new EntTopic { ID = 3, HasChilde = true, IsActive = true, ParrentID = 0, Title = "دانلود", PicSrc = @"https://www.phoca.cz/images/projects/phoca-download-r.svg" },//3
                new EntTopic { ID = 4, HasChilde = false, IsActive = true, ParrentID = 1, Title = "سی شارپ", PicSrc = @"https://www.avenga.com/wp-content/uploads/2020/11/C-Sharp-1536x864.png" },//4
                new EntTopic { ID = 5, HasChilde = true, IsActive = true, ParrentID = 1, Title = "شبکه", PicSrc = @"https://s3.amazonaws.com/eaglecom.net/news/June2019/xn9Tq8YRbeCzzoYios3kvdMT.png" },//5
                new EntTopic { ID = 6, HasChilde = false, IsActive = true, ParrentID = 2, Title = "برنامه نویسی", PicSrc = @"https://miuc.org/wp-content/uploads/2020/08/6-Reasons-why-you-should-learn-Programming-737x366.png" },//6
                new EntTopic { ID = 7, HasChilde = false, IsActive = true, ParrentID = 2, Title = "شبکه", PicSrc = @"https://electronicsguide4u.com/wp-content/uploads/2018/09/client-341420_1920.png" },//7
                new EntTopic { ID = 8, HasChilde = false, IsActive = true, ParrentID = 3, Title = "نرم افزار های برنامه نویسی", PicSrc = @"https://tosinso.com/files/get/3bf06a08-04af-49ee-8d58-9b64cce37984" } //8
                );
        }
        public static void Posts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntPost>().HasData(
                new EntPost
                {
                    ID = 1,
                    AuthoreID = 1,
                    TopicID = 4,
                    EngName = @"Learning C #  ",
                    Title = @"آموزش سی شارپ",
                    ABS = @"در این دوره شما زبان برنامه نویسی سی شارپ، که یکی از قدرتمند ترین زبان های برنامه نویسی شیء گرا می باشد را از 0 تا 100 آموزش خواهید دید و پس از یادگیری با کمک این زبان می توانید تکنولوژی مورد ",
                    Content = @"در این دوره شما زبان برنامه نویسی سی شارپ، که یکی از قدرتمند ترین زبان های برنامه نویسی شیء گرا می باشد را از 0 تا 100 آموزش خواهید دید و پس از یادگیری با کمک این زبان می توانید تکنولوژی مورد علاقه خود را (وب، ویندوز و موبایل) انتخاب کرده و هرچه سریع تر در آن حرفه ای شوید
پیش نیاز های این دوره :

این دوره پیش نیازی ندارد .",
                    PicSRC = @"https://toplearn.com/img/course/img-course-%D8%B4%D9%86%D8%A8%D9%87-%DB%B1%DB%B5-%D8%A7%D8%B1%D8%AF%DB%8C%D8%A8%D9%87%D8%B4%D8%AA-%DB%B1%DB%B3%DB%B9%DB%B7-61064385-586.jpeg",
                    IsActive = true,
                    WriteDate = DateTime.Now.Date
                },
                 new EntPost
                 {
                     ID = 2,
                     AuthoreID = 1,
                     TopicID = 5,
                     EngName = @"Net+ training ",
                     Title = @"آموزش نتورک پلاس",
                     ABS = @"فناوری اطلاعات عرصه نوینی را به منظور پیشرفت افراد و جوامع در دنیای امروز به روی همگان گشوده است. بدون شک از ",
                     Content = @"فناوری اطلاعات عرصه نوینی را به منظور پیشرفت افراد و جوامع در دنیای امروز به روی همگان گشوده است. بدون شک از دانش شبکه می توان به عنوان یکی از مهم ترین این تخصص ها نام برد. کسب مهارت در زمینه +Network و به تبع آن مهارت در پیاده سازی و اجرای شبکه های پایه به رفع مشکلات سازمان ها در این حوزه کمک شایانی می کند. این فرادرس به عنوان پیش نیاز کلیه دوره های تخصصی شبکه به شما کمک خواهد کرد تا به عنوان تکنیسین شبکه، جهت ورود به بازار کار و نیز دوره های تخصصی تر شبکه از جمله دوره های مایکروسافت، سیسکو، لینوکس و امنیت شبکه آماده شوید.",
                     PicSRC = @"https://faradars.org/wp-content/uploads/2016/10/fvnet9410-svg.svg",
                     IsActive = true,
                     WriteDate = DateTime.Now.Date
                 },
                new EntPost
                {
                    ID = 3,
                    AuthoreID = 1,
                    TopicID = 5,
                    EngName = @"Network training ",
                    Title = @"آموزش شبکه های کامپیوتری",
                    ABS = @"امروزه دیگر به جای اینکه یک کامپیوتر بزرگ کلیه کارهای محاسباتی را انجام دهد، تعداد زیادی کامپیوتر کوچک ",
                    Content = @"امروزه دیگر به جای اینکه یک کامپیوتر بزرگ کلیه کارهای محاسباتی را انجام دهد، تعداد زیادی کامپیوتر کوچک که به هم متصل هستند، این کار را انجام می دهند. به این سیستم ها شبکه های کامپیوتری گفته می شود. شبکه های کامپیوتری به خاطر کاربرد بسیار زیاد شبکه ها در محیط های کاری از دروس مهم و کاربردی رشته مهندسی برق و کامپیوتر به شمار می رود. هدف این فرادرس فراگیری مباحث تخصصی در حوزه شبکه برای دانشجویان رشته برق و مخابرات است. در ضمن این درس مقدمه ورود به دروش پیشرفته تر در ارشد مخابرات در زمینه شبکه های مخابرات بی سیم محسوب می شود.",
                    PicSRC = @"https://faradars.org/wp-content/uploads/2016/09/fvsft113-svg.svg",
                    IsActive = true,
                    WriteDate = DateTime.Now.Date
                },
                new EntPost
                {
                    ID = 4,
                    AuthoreID = 1,
                    TopicID = 4,
                    EngName = @"Software Services ",
                    Title = @"خدمات نرم افزاری",
                    ABS = @"عالی ترین خدمات نرم افزاری با حداقل هزینه در کمترین زمان ممکن را از مرکز خدمات و تعمیرات تخصصی ناوک مطالبه نمایید.",
                    Content = @"

بخشی از خدمات نرم افزاری ارائه شده در مرکز خدمات و تعمیرات تخصصی ناوک شامل نصب انواع سیستم عامل ها به صورت تخصصی به همراه کلیه درایورها و به همراه تضمین صحت کارکرد می‌باشد. خدمات نرم افزاری سیستم عامل ویندوز٬ خدمات نرم افزاری سیستم عامل مک٬ خدمات نرم افزاری سیستم عامل لینوکس نیز در این مرکز ارائه می‌شود.

در مرکز خدمات و تعمیرات تخصصی ناوک تمامی خدمات نرم افزاری عمومی و تخصصی انجام میپذیرد. عیب یابی های تخصصی نرم افزاری٬ برطرف کردن ایرادات درایور٬ حل مشکلات نرم افزاری٬ نصب نرم افزارهای عموم و تخصصی و هر نوع خدمات نرم افزاری مورد نیاز مشتری.
",
                    PicSRC = @"https://navakservices.com/wp-content/uploads/2018/04/khadamatenarmafzari-300x243.jpg",
                    IsActive = true,
                    WriteDate = DateTime.Now.Date
                }
                );

        }
    }
}
