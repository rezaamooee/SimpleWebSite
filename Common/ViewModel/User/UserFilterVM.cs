using Entity.DBEntities;
using Entity.Tools;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Common.ViewModel.User
{
    public class UserFilterVM
    {
        [Display(Name = "نام")]
        [MinLength(length: 3, ErrorMessage = "حداقل طول رشته ورودی بایستی 3 نویسه باشد")]
        [RegularExpression(pattern: ValidationTools.StandardFaName_Regx, ErrorMessage = ValidationTools.StandardFaName_Msg)]
        public string Name { set; get; } = null;

        [Display(Name = "نام خانوادگی")]
        [MinLength(length: 3, ErrorMessage = "حداقل طول رشته ورودی بایستی 3 نویسه باشد")]
        [RegularExpression(pattern: ValidationTools.StandardFaName_Regx, ErrorMessage = ValidationTools.StandardFaName_Msg)]
        public string LastName { set; get; } = null;

        [Display(Name = "نام کاربری")]
        [MinLength(length: 8, ErrorMessage = "حداقل طول رشته ورودی بایستی 8 نویسه باشد")]
        [RegularExpression(pattern: ValidationTools.StandardEngName_Regx, ErrorMessage = ValidationTools.StandardEngName_Msg)]
        public string Username { set; get; } = null;

        [Display(Name = "پست الکترونیک")]
        [DataType(DataType.EmailAddress)]
        [MinLength(length: 8, ErrorMessage = ValidationTools.Mail_Msg)]
        [MaxLength(length: 35, ErrorMessage = ValidationTools.Mail_Msg)]
        [RegularExpression(pattern: ValidationTools.Mail_Regx, ErrorMessage = ValidationTools.Mail_Msg)]
        public string Email { set; get; } = null;

        [Display(Name = "تاریخ تولد")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate_Start { set; get; } = null;

        [Display(Name = "تاریخ تولد")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate_End { set; get; } = null;

        [Display(Name = "آدرس پستی")]
        public string Address { set; get; } = null;

        [Display(Name = "شماره همراه")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(length: 11, ErrorMessage = ValidationTools.Tell_Msg)]
        [MaxLength(length: 15, ErrorMessage = ValidationTools.Tell_Msg)]
        [RegularExpression(pattern: ValidationTools.Tell_Regx, ErrorMessage = ValidationTools.Tell_Msg)]
        public string Tell { set; get; } = null;

        [Display(Name = "تاریخ عضویت")]
        [DataType(DataType.Date)]
        public DateTime? RegDate_Satar { set; get; } = null;

        [Display(Name = "تاریخ عضویت")]
        [DataType(DataType.Date)]
        public DateTime? RegDate_End { set; get; } = null;



        [Display(Name = "فعال است ؟")]
        public bool? IsActive { set; get; } = null;
        [Display(Name = "سطح دسترسی")]
        public long? RoleID { set; get; } = null;
        public EntRole UserRole { set; get; } = null;
        public IQueryable<EntUser> MakeQuery(IQueryable<EntUser> Query)
        {
            if (IsActive != null)
                Query = Query.Where(x => x.IsActive == IsActive).AsQueryable();

            if (Email != null)
                Query = Query.Where(x => x.Email.Equals(Email)).AsQueryable();

            if (Address != null)
                Query = Query.Where(x => x.Address.Contains(Address)).AsQueryable();

            if (LastName != null)
                Query = Query.Where(x => x.LastName.Equals(LastName)).AsQueryable();

            if (Name != null)
                Query = Query.Where(x => x.Name.Contains(Name)).AsQueryable();

            if (Tell != null)
                Query = Query.Where(x => x.Tell.Contains(Tell)).AsQueryable();

            if (Username != null)
                Query = Query.Where(x => x.Username.Equals(Username)).AsQueryable();

            if (BirthDate_Start != null)
                if (BirthDate_End != null)
                    Query = Query.Where(x => x.BirthDate >= BirthDate_Start && x.BirthDate <= BirthDate_End).AsQueryable();
                else
                    Query = Query.Where(x => x.BirthDate >= BirthDate_Start).AsQueryable();
            else
                if (BirthDate_End != null)
                Query = Query.Where(x => x.BirthDate <= BirthDate_End).AsQueryable();

            if (RegDate_Satar != null)
                if (RegDate_End != null)
                    Query = Query.Where(x => x.RegDate >= RegDate_Satar && x.RegDate <= RegDate_End).AsQueryable();
                else
                    Query = Query.Where(x => x.RegDate >= RegDate_Satar).AsQueryable();
            else
                if (RegDate_End != null)
                Query = Query.Where(x => x.RegDate <= RegDate_End).AsQueryable();
            return Query;
        }
    }
}
