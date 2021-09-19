using Application.Interfaces.Contexts;
using Application.Interfaces.Services.Topic.Command;
using Application.Services.Role;
using Common.Messages;
using Common.ViewModel.Topic;
using Entity.DBEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Topic.Command
{
    public class TopicCMDServices : ITopicCMDServices
    {
        private readonly ISiteDbContext _context;
        public TopicCMDServices(ISiteDbContext context)
        {
            _context = context;
        }

        public async Task<RespMsg<TopicVM>> Add(TopicVM ReqAdd, CancellationToken CT)
        {
            IResponseMessage Response;
            var errors = new List<ValidationResult>();
            var validateResult = Validator.TryValidateObject(ReqAdd, new ValidationContext(ReqAdd), errors, true);
            if (validateResult)
                    if (_context.Topics.Any(x => x.Title == ReqAdd.Title) == false)
                        try
                        {
                        EntTopic NewTopic = new()
                        {
                            IsActive = ReqAdd.IsActive,
                            Title = ReqAdd.Title,
                            ParrentID = ReqAdd.ParrentID,
                            PicSrc = ReqAdd.PicSrc,
                            HasChilde = ReqAdd.HasChilde,
                        };
                            var add = await _context.Topics.AddAsync(NewTopic, CT);
                            var save = await _context.SaveChangesAsync(CT);
                            Response = Topic_MakeResponse.MakeResponse(NewTopic,
                                new List<(ServiceStatus ServiceStatus, string Message)>
                                {
                                    (ServiceStatus.OK, "اطلاعات موضوع جدید افزوده شد.")
                                });
                        }
                        catch
                        {
                            Response = Topic_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "ذخیره اطلاعات موضوع جدید با خطا مواجه شد.")
                            });
                        }
                    else
                        Response = Topic_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                        {
                            (ServiceStatus.DbDuplicatedRow, " این موضوع قبلا تعریف شده.")
                        });
            else
                Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.HasModelValidationError, "اطلاعات ارسالی غیر مجاز است.")
                });
            return (RespMsg<TopicVM>)Response;
        }
        public async Task<RespMsg<TopicVM>> Edit(TopicVM ReqEdit, CancellationToken CT)
        {
            IResponseMessage Response;
            var errors = new List<ValidationResult>();
            var ValidateResult = Validator.TryValidateObject(ReqEdit, new ValidationContext(ReqEdit), errors, true);
            if (ValidateResult)
            {
                var DbTopic = await _context.Topics.FindAsync(ReqEdit.ID);
                if (DbTopic.HasChilde != ReqEdit.HasChilde)
                {
                    if (_context.Topics.Any(a => a.ParrentID == DbTopic.ID))
                        return(RespMsg<TopicVM>) Topic_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "این موضوع دارای زیر گروه است ، نمیتوان حالت والد آن را تغییر داد.")
                            });
                    else
                    {
                        DbTopic.IsActive = ReqEdit.IsActive;
                        DbTopic.Title = ReqEdit.Title;
                        DbTopic.ParrentID = ReqEdit.ParrentID;
                        DbTopic.PicSrc = ReqEdit.PicSrc;
                        DbTopic.HasChilde = ReqEdit.HasChilde;
                    }
                }
                else
                {
                    DbTopic.IsActive = ReqEdit.IsActive;
                    DbTopic.Title = ReqEdit.Title;
                    DbTopic.ParrentID = ReqEdit.ParrentID;
                    DbTopic.PicSrc = ReqEdit.PicSrc;
                    DbTopic.HasChilde = ReqEdit.HasChilde;
                }
                errors = new List<ValidationResult>();
                ValidateResult = Validator.TryValidateObject(DbTopic, new ValidationContext(DbTopic), errors, true);
                if (ValidateResult)
                {
                    try
                    {
                        _context.Topics.Update(DbTopic);
                        await _context.SaveChangesAsync(CT);
                        Response = Topic_MakeResponse.MakeResponse(DbTopic, new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.OK, "ذخیره اطلاعات جدید موضوع انجام شد.")
                            });
                    }
                    catch
                    {
                        Response = Topic_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "ذخیره اطلاعات موضوع با خطا مواجه شد.")
                            });
                    }
                }
                else
                    Response = Topic_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "اطلاعات ارسالی غیر مجاز است.")
                            });
            }
            else
                Response = Topic_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "اطلاعات ارسالی غیر مجاز است.")
                            });

            return (RespMsg<TopicVM>) Response;
        }
        public async Task<RespMsg<TopicVM>> Delete(long ReqDelID, CancellationToken CT)
        {
            IResponseMessage Response;
            var DbResult = await _context.Topics.FindAsync(ReqDelID);
            if (DbResult != null)
            {
                try
                {
                    _context.Topics.Remove(DbResult);
                    await _context.SaveChangesAsync(CT);
                    Response = Topic_MakeResponse.MakeResponse(DbResult, new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.OK, "موضوع مورد نظر حذف شد.")
                    });
                }
                catch
                {
                    Response = Topic_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.HasModelValidationError, "حذف اطلاعات موضوع با خطا مواجه شد.")
                    });
                }
            }
            else
                Response = Topic_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.HasModelValidationError, "اطلاعات ارسالی غیر مجاز است.")
                });
            return (RespMsg<TopicVM>)Response;
        }

    }
}
