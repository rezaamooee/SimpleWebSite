using Entity.DBEntities;
using Entity.Tools;
using System.ComponentModel.DataAnnotations;

namespace Common.ViewModel.Role
{
    public class RoleVM
    {
        [Display(Name = "کد")]
        public long ID { set; get; }

        [Display(Name = "نام")]
        [RegularExpression(pattern: ValidationTools.StandardEngName_Regx, ErrorMessage = ValidationTools.StandardEngName_Msg)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public string Name { set; get; }

        [Display(Name = "سطح دسترسی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public Permision Permision { set; get; } 

        [Display(Name = "فعال است؟")]
        public bool IsActive { set; get; } 
        public RoleVM()
        {
        }
        public RoleVM(EntRole obj)
        {
            ID = obj.ID;
            IsActive = obj.IsActive;
            Name = obj.Name;
            Permision = obj.Permision;
        }
    }
}
