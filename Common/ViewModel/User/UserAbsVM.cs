using Common.ViewModel.Role;
using Entity.DBEntities;
using Entity.Tools;
using System.ComponentModel.DataAnnotations;

namespace Common.ViewModel.User
{
    public class UserAbsVM
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
        [DataType(DataType.EmailAddress)]
        [MinLength(length: 8, ErrorMessage = ValidationTools.Mail_Msg)]
        [MaxLength(length: 35, ErrorMessage = ValidationTools.Mail_Msg)]
        [RegularExpression(pattern: ValidationTools.Mail_Regx, ErrorMessage = ValidationTools.Mail_Msg)]
        public string Email { set; get; }

        [Display(Name = "فعال است ؟")]
        public bool IsActive { set; get; } = false;

        [Display(Name = "سطح دسترسی")]
        [Required(ErrorMessage = ValidationTools.RequiredField_Msg)]
        public RoleVM Role { set; get; }


        public UserAbsVM()
        {
        }
        public UserAbsVM(EntUser obj)
        {
            Email = obj.Email;
            ID = obj.ID;
            IsActive = obj.IsActive;
            LastName = obj.LastName;
            Name = obj.Name;
            Username = obj.Username;
            Role = new RoleVM(obj.Role);
        }
        public static UserAbsVM Pars(EntUser obj)
        {
            return new UserAbsVM()
            {
                Email = obj.Email,
                ID = obj.ID,
                IsActive = obj.IsActive,
                LastName = obj.LastName,
                Name = obj.Name,
                Username = obj.Username,
                Role = new RoleVM(obj.Role),

            };
        }
        public static UserAbsVM Pars(UserVM obj)
        {
            return new UserAbsVM()
            {
                Email = obj.Email,
                ID = obj.ID,
                IsActive = obj.IsActive,
                LastName = obj.LastName,
                Name = obj.Name,
                Username = obj.Username,
                Role = obj.Role

        };
        }
        public static UserAbsVM Pars(UserInfoVM obj)
        {
            return new UserAbsVM()
            {
                Email = obj.Email,
                ID = obj.ID,
                IsActive = obj.IsActive,
                LastName = obj.LastName,
                Name = obj.Name,
                Username = obj.Username,
                Role = obj.Role

            };
        }
       
    }
}
