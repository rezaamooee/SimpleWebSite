using Entity.Tools;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.DBEntities
{
    public class EntTopic
    {
        [Key]
        [Display(Name = "کد")]
        public long ID { set; get; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public string Title { set; get; }

        [Display(Name = "مسیر تصویر")]
        public string PicSrc { set; get; }

        [Display(Name = "دارای زیرمجموعه")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public bool HasChilde { set; get; } = false;
        [Display(Name = "فعال است؟")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public bool IsActive { set; get; } 
        
        [Display(Name = "کد مجموعه والد")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public long ParrentID { set; get; }

        [Display(Name = "لیست پست ها")]
        public virtual List<EntPost> Posts { set; get; }

    }
}
