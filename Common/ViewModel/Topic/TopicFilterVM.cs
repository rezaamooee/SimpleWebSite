using Entity.DBEntities;
using Entity.Tools;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Common.ViewModel.Topic
{
    public class TopicFilterVM
    {
        [Display(Name = "کد")]
        public long? ID { set; get; } = null;

        [Display(Name = "عنوان")]
        public string Title { set; get; } = null;

        [Display(Name = "مسیر تصویر")]
        public string PicSrc { set; get; } = null;

        [Display(Name = "دارای زیرمجموعه")]
        public bool? HasChilde { set; get; } = null;

        [Display(Name = "کد مجموعه والد")]
        public long? ParrentID { set; get; } = null;

        [Display(Name = "فعال است؟")]
        public bool? IsAvtive { set; get; } = null;

        public TopicFilterVM()
        {

        }
        public TopicFilterVM(EntTopic obj)
        {
            ID = obj.ID;
            ParrentID = obj.ParrentID;
            PicSrc = obj.PicSrc;
            Title = obj.Title;
            IsAvtive = obj.IsActive;
        }
        public IQueryable<EntTopic> MakeQuery(IQueryable<EntTopic> Query)
        {
            if (ID.HasValue)
                Query = Query.Where(a => a.ID == ID).AsQueryable();
            if (Title != null)
                Query = Query.Where(a => a.Title == Title).AsQueryable();
            if (PicSrc !=null)
                Query = Query.Where(a => a.PicSrc == PicSrc).AsQueryable();
            if (ParrentID.HasValue)
                Query = Query.Where(a => a.ParrentID == ParrentID).AsQueryable();
            if (IsAvtive.HasValue)
                Query = Query.Where(a => a.IsActive == IsAvtive).AsQueryable();
            return Query;
        }
    }
}
