using Entity.Tools;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.DBEntities
{
    public class EntLogin
    {
        [Key]
        [Display(Name = "کد")]
        public long ID { set; get; }

        [Display(Name = "کاربر")]
        [ForeignKey(name: "User")]
        [Required(ErrorMessage = ValidationTools.RequiredField_Msg)]
        public long UserID { set; get; }
        public EntUser User { set; get; }

        [Display(Name = "کد امنیتی اول")]
        public string HashKey1 { set; get; }

        [Display(Name = "کد امنیتی دوم")]
        public string HashKey2 { set; get; }
    }
}
