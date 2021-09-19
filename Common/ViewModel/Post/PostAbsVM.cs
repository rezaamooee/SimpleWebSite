using Common.ViewModel.Topic;
using Common.ViewModel.User;
using Entity.DBEntities;
using Entity.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel.Post
{
    public class PostAbsVM
    {
        [Display(Name = "کد")]
        public long ID { set; get; }

        [Display(Name = "کد نویسنده")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public long AuthoreID { set; get; }

        [Display(Name = "نویسنده")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public UserInfoVM Author { set; get; }

        [Display(Name = "کد موضوع")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public long TopicID { set; get; }

        [Display(Name = "موضوع")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationTools.RequiredField_Msg)]
        public TopicVM Topic { set; get; }

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

        [Display(Name = "فعال است ؟")]
        public bool IsActive { set; get; } = false;

        public PostAbsVM()
        {

        }
        public PostAbsVM(EntPost Obj)
        {
            ABS = Obj.ABS;
            AuthoreID = Obj.AuthoreID;
            Author = new UserInfoVM(Obj.Authore);
            ID = Obj.ID;
            IsActive = Obj.IsActive;
            PicSRC = Obj.PicSRC;
            Title = Obj.Title;
            TopicID = Obj.TopicID;
            Topic = new TopicVM(Obj.Topic);
        }
        public PostAbsVM(PostVM Obj)
        {
            ABS = Obj.ABS;
            AuthoreID = Obj.AuthoreID;
            Author = Obj.Author;
            ID = Obj.ID;
            IsActive = Obj.IsActive;
            PicSRC = Obj.PicSRC;
            Title = Obj.Title;
            TopicID = Obj.TopicID;
            Topic = Obj.Topic;
        }
    }
}
