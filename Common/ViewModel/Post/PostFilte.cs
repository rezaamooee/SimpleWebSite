using Common.ViewModel.Topic;
using Common.ViewModel.User;
using Entity.DBEntities;
using Entity.Tools;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Common.ViewModel.Post
{
    public class PostFilter
    {

        [Display(Name = "کد نویسنده")]
        public long? AuthoreID { set; get; } = null;
        
        [Display(Name = "کد موضوع")]
        public long? TopicID { set; get; } = null;

        [Display(Name = "نام لاتین")]
        [RegularExpression(pattern: ValidationTools.StandardEngName_Regx, ErrorMessage = ValidationTools.StandardEngName_Msg)]
        public string EngName { set; get; } = null;

        [Display(Name = "عنوان")]
        [RegularExpression(pattern: ValidationTools.StandardFaName_Regx, ErrorMessage = ValidationTools.StandardFaName_Msg)]
        public string Title { set; get; } = null;

        [Display(Name = "تاریخ نگارش")]
        [DataType(DataType.Date)]
        public DateTime? WriteDate_Start { set; get; } = null;

        [Display(Name = "تاریخ نگارش")]
        [DataType(DataType.Date)]
        public DateTime? WriteDate_End { set; get; } = null;

        [Display(Name = "فعال است ؟")]
        public bool? IsActive { set; get; } = null;
        [Display(Name = "کلید واژه جست و جو")]
        public string SearchWord { set; get; } = null;
        
        public PostFilter()
        {

        }
        public IQueryable<EntPost> MakeQuery(IQueryable<EntPost> Query)
        {
            if (AuthoreID != null)
                Query = Query.Where(x => x.IsActive == IsActive).AsQueryable();

            if (TopicID != null)
                Query = Query.Where(x => x.TopicID == TopicID).AsQueryable();

            if (EngName != null)
                Query = Query.Where(x => x.EngName.Contains(EngName)).AsQueryable();

            if (Title != null)
                Query = Query.Where(x => x.Title.Contains(Title)).AsQueryable();
            if (SearchWord != null)
                Query = Query.Where(x => x.ABS.Contains(Title) || x.Content.Contains(SearchWord) ).AsQueryable();

            if (WriteDate_Start != null)
                if (WriteDate_End != null)
                    Query = Query.Where(x => x.WriteDate >= WriteDate_Start && x.WriteDate <= WriteDate_End).AsQueryable();
                else
                    Query = Query.Where(x => x.WriteDate >= WriteDate_Start).AsQueryable();
            else
                if (WriteDate_End != null)
                Query = Query.Where(x => x.WriteDate <= WriteDate_End).AsQueryable();

           
            return Query;
        }


    }
}
