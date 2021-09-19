using Common.PublicServices;
using Common.ViewModel.Role;
using Entity.DBEntities;
using Entity.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.ViewModel.User
{
    public class UserInfoVM
    {
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

        [Display(Name = "پست الکترونیک")]
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
        [RegularExpression(pattern: ValidationTools.Tell_Regx, ErrorMessage = ValidationTools.Tell_Msg)]
        [Required(ErrorMessage = ValidationTools.RequiredField_Msg)]
        public string Tell { set; get; }

        [Display(Name = "تاریخ عضویت")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = ValidationTools.RequiredField_Msg)]
        public DateTime RegDate { set; get; } = DateTime.Now.Date;

        [Display(Name = "فعال است ؟")]
        public bool IsActive { set; get; } = false;

        [Display(Name = "سطح دسترسی")]
        [Required(ErrorMessage = ValidationTools.RequiredField_Msg)]
        public RoleVM Role { set; get; }



        public UserInfoVM()
        {
        }
        public UserInfoVM(EntUser obj)
        {
            Address = obj.Address;
            BirthDate = obj.BirthDate;
            Email = obj.Email;
            ID = obj.ID;
            IsActive = obj.IsActive;
            LastName = obj.LastName;
            Name = obj.Name;
            RegDate = obj.RegDate;
            Role = new RoleVM(obj.Role);
            Tell = obj.Tell;
            Username = obj.Username;
        }
        public static UserInfoVM Pars(EntUser obj)
        {
            return new UserInfoVM()
            {
                Address = obj.Address,
                BirthDate = obj.BirthDate,
                Email = obj.Email,
                ID = obj.ID,
                IsActive = obj.IsActive,
                LastName = obj.LastName,
                Name = obj.Name,
                RegDate = obj.RegDate,
                Role =new RoleVM( obj.Role),
                Tell = obj.Tell,
                Username = obj.Username
            };
        }
        public static UserInfoVM Pars(UserVM obj)
        {
            return new UserInfoVM()
            {
                Address = obj.Address,
                BirthDate = obj.BirthDate,
                Email = obj.Email,
                ID = obj.ID,
                IsActive = obj.IsActive,
                LastName = obj.LastName,
                Name = obj.Name,
                RegDate = obj.RegDate,
                Role = obj.Role,
                Tell = obj.Tell,
                Username = obj.Username
            };
        }
    }
}
