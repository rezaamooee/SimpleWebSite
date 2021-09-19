using Entity.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.DBEntities
{
    [Index(propertyNames: "Email", IsUnique = true, Name = "IX_EntUser_Email")]
    [Index(propertyNames: "Username", IsUnique = true, Name = "IX_EntUser_Username")]
    public class EntUser
    {
        [Key]
        [Display(Name = "کد")]
        public long ID { set; get; }

        [Display(Name = "نام")]
        [MinLength(length: 3, ErrorMessage = "حداقل طول رشته ورودی بایستی 3 نویسه باشد")]
        [RegularExpression(pattern: ValidationTools.StandardFaName_Regx, ErrorMessage = ValidationTools.StandardFaName_Msg)]
        public string Name { set; get; }

        [Display(Name = "نام خانوادگی")]
        [MinLength(length: 3, ErrorMessage = "حداقل طول رشته ورودی بایستی 3 نویسه باشد")]
        [RegularExpression(pattern: ValidationTools.StandardFaName_Regx, ErrorMessage = ValidationTools.StandardFaName_Msg)]
        public string LastName { set; get; }

        [Display(Name = "نام کاربری")]
        [MinLength(length: 8, ErrorMessage = "حداقل طول رشته ورودی بایستی 8 نویسه باشد")]
        [RegularExpression(pattern: ValidationTools.StandardEngName_Regx, ErrorMessage = ValidationTools.StandardEngName_Msg)]
        public string Username { set; get; }

        [Display(Name = "گذرواژه")]
        [DataType(DataType.Password)]
        [MinLength(length: 8, ErrorMessage = ValidationTools.Pass_Msg)]
        [RegularExpression(pattern: ValidationTools.Pass_Regx, ErrorMessage = ValidationTools.Pass_Msg)]
        public string Password { set; get; }

        [Display(Name = "پست الکترونیک")]
        [DataType(DataType.EmailAddress)]
        [MinLength(length: 8, ErrorMessage = ValidationTools.Mail_Msg)]
        [MaxLength(length: 35, ErrorMessage = ValidationTools.Mail_Msg)]
        [RegularExpression(pattern: ValidationTools.Mail_Regx, ErrorMessage = ValidationTools.Mail_Msg)]
        public string Email { set; get; }

        [Display(Name = "تاریخ تولد")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = ValidationTools.RequiredField_Msg)]
        public DateTime BirthDate { set; get; }

        [Display(Name = "آدرس پستی")]
        public string Address { set; get; }

        [Display(Name = "شماره همراه")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(pattern: ValidationTools.Tell_Regx, ErrorMessage = ValidationTools.Tell_Msg)]
        [Required(ErrorMessage = ValidationTools.RequiredField_Msg)]
        public string Tell { set; get; }

        [Display(Name = "تاریخ عضویت")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = ValidationTools.RequiredField_Msg)]
        public DateTime RegDate { set; get; } = DateTime.Now.Date;

        [Display(Name = "فعال است ؟")]
        public bool IsActive { set; get; } = false;


        [Display(Name = "لیست ورودها")]
        public virtual List<EntLogin> Logins { set; get; }

        [Display(Name = "نوشته ها")]
        public virtual List<EntPost> Posts { set; get; }

        [Display(Name = "سطح دسترسی")]
        [Required(ErrorMessage = ValidationTools.RequiredField_Msg)]
        [ForeignKey("Role")]
        public long RoleID { set; get; }
        public EntRole Role { set; get; }

    }
}
