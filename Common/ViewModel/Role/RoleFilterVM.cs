using Entity.DBEntities;
using Entity.Tools;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Common.ViewModel.Role
{
    public class RoleFilterVM
    {
        [Display(Name = "کد")]
        public long? ID { set; get; } = null;

        [Display(Name = "نام")]
        [RegularExpression(pattern: ValidationTools.StandardEngName_Regx, ErrorMessage = ValidationTools.StandardEngName_Msg)]
        public string Name { set; get; } = null;

        [Display(Name = "سطح دسترسی")]
        public Permision? Permision { set; get; } = null;

        [Display(Name = "فعال است؟")]
        public bool? IsActive { set; get; } = null;
        public RoleFilterVM()
        {
        }
        public RoleFilterVM(EntRole obj)
        {
            ID = obj.ID;
            IsActive = obj.IsActive;
            Name = obj.Name;
            Permision = obj.Permision;
        }
        public IQueryable<EntRole> MakeQuery(IQueryable<EntRole> Query)
        {
            if (ID.HasValue)
                Query = Query.Where(a => a.ID == ID).AsQueryable();
            if (Name!=null)
                Query = Query.Where(a => a.Name == Name).AsQueryable();
            if (Permision.HasValue)
                Query = Query.Where(a => a.Permision == Permision).AsQueryable();
            if (IsActive.HasValue)
                Query = Query.Where(a => a.IsActive == IsActive).AsQueryable();
            return Query;
        }
    }
}
