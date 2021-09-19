using Entity.Tools;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.DBEntities
{
    public class EntRole
    {
        [Display(Name = "کد")]
        public long ID { set; get; }

        [Display(Name = "نام")]
        [RegularExpression(pattern: ValidationTools.StandardEngName_Regx, ErrorMessage = ValidationTools.StandardEngName_Msg)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public string Name { set; get; }

        [Display(Name = "سطح دسترسی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public Permision Permision { set; get; } = Permision.none;

        [Display(Name = "فعال است؟")]
        public bool IsActive { set; get; } = false;

        [Display(Name = "لیست کاربران")]
        public virtual List<EntUser> Users { set; get; }
    }

}
