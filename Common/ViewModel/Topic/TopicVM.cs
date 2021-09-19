using Entity.DBEntities;
using Entity.Tools;
using System.ComponentModel.DataAnnotations;

namespace Common.ViewModel.Topic
{
    public class TopicVM
    {
        [Display(Name = "کد")]
        public long ID { set; get; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public string Title { set; get; }

        [Display(Name = "مسیر تصویر")]
        [DataType(DataType.ImageUrl)]
        public string PicSrc { set; get; }

        [Display(Name = "دارای زیرمجموعه")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public bool HasChilde { set; get; } = false;
        [Display(Name = "فعال است؟")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public bool IsActive { set; get; }

        [Display(Name = "کد مجموعه والد")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public long ParrentID { set; get; } = 0;
        [Display(Name = "موضوع والد")]
        public TopicVM Parrent { set; get; } = null;
        public TopicVM()
        {

        }
        public TopicVM(EntTopic obj)
        {
            ID = obj.ID;
            ParrentID = obj.ParrentID;
            PicSrc = obj.PicSrc;
            Title = obj.Title;
            IsActive = obj.IsActive;
            HasChilde = obj.HasChilde;
        }

    }
}