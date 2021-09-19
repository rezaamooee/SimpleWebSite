using Entity.DBEntities;
using Entity.Tools;
using System.ComponentModel.DataAnnotations;

namespace Common.ViewModel.User
{
    public class UserLoginVM
    {
        [Display(Name = "نام کاربری")]
        [MinLength(length: 8, ErrorMessage = "حداقل طول رشته ورودی بایستی 8 نویسه باشد")]
        [RegularExpression(pattern: ValidationTools.StandardEngName_Regx, ErrorMessage = ValidationTools.StandardEngName_Msg)]
        public string Username { set; get; }

        [Display(Name = "گذرواژه")]
        [DataType(DataType.Password)]
        [MinLength(length: 8, ErrorMessage = ValidationTools.Pass_Msg)]
        [RegularExpression(pattern: ValidationTools.Pass_Regx, ErrorMessage = ValidationTools.Pass_Msg)]
        public string Password { set; get; }
        public UserLoginVM()
        {

        }
        public UserLoginVM (EntUser obj)
        {
            Password = obj.Password;
            Username = obj.Username;
        }
        public static UserLoginVM CastIn (EntUser obj)
        {
            return new UserLoginVM()
            {
                Password = obj.Password,
                Username = obj.Username,
            };
        }

    }
}
