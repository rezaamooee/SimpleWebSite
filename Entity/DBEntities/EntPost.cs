using Entity.Tools;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.DBEntities
{
    public class EntPost
    {
        [Key]
        [Display(Name = "کد")]
        public long ID { set; get; }

        [Display(Name = "نویسنده")]
        [ForeignKey("Authore")]
        public long AuthoreID { set; get; }
        public EntUser Authore { set; get; }

        [Display(Name = "موضوع")]
        [ForeignKey(name: "Topic")]
        public long TopicID { set; get; }
        public EntTopic Topic { set; get; }

        [Display(Name = "نام لاتین")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        [RegularExpression(pattern: ValidationTools.StandardEngName_Regx, ErrorMessage = ValidationTools.StandardEngName_Msg)]
        public string EngName { set; get; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        [RegularExpression(pattern: ValidationTools.StandardFaName_Regx, ErrorMessage = ValidationTools.StandardFaName_Msg)]
        public string Title { set; get; }

        [Display(Name = "مسیر تصویر")]
        [DataType(DataType.ImageUrl)]
        [RegularExpression(pattern: ValidationTools.Url_Regx, ErrorMessage = ValidationTools.Url_Msg)]
        public string PicSRC { set; get; }

        [Display(Name = "خلاصه")]
        [DataType(DataType.Html)]
        [MinLength(length: 10, ErrorMessage = "خلاصه بایستی حداقل 10 نویسه باشد.")]
        [MaxLength(length: 255, ErrorMessage = "خلاصه بایستی حداکثر 255 نویسه باشد.")]
        public string ABS { set; get; }

        [Display(Name = "مقاله")]
        [DataType(DataType.Html)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public string Content { set; get; }

        [Display(Name = "تاریخ نگارش")]
        [DataType(DataType.Date)]
        public DateTime WriteDate { set; get; } = DateTime.Now.Date;

        [Display(Name = "فعال است ؟")]
        public bool IsActive { set; get; } = false;


    }
}
