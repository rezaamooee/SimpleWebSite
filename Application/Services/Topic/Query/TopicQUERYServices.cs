using Application.Interfaces.Contexts;
using Application.Interfaces.Services.Topic;
using Application.Services.Role;
using Common.Messages;
using Common.ViewModel.Role;
using Common.ViewModel.Topic;
using Entity.Tools;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Topic.Query
{
    public class TopicQUERYServices : ITopicQUERYServices
    {
        private readonly ISiteDbContext _context;
        public TopicQUERYServices(ISiteDbContext context)
        {
            _context = context;
        }


        public async Task<bool> IfExist(long ReqID, bool? IsActive, CancellationToken CT)
        {
            var Query = _context.Topics.AsQueryable();
            if (IsActive.HasValue)
                Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
            var DbResult = await Query.Where(a => a.ID == ReqID).ToListAsync(CT);
            if (DbResult != null)
                return true;
            return false;
        }
        public async Task<bool> IfExist(TopicVM ReqVM, bool? IsActive, CancellationToken CT)
        {
            var errors = new List<ValidationResult>();
            bool ValidateResult = Validator.TryValidateObject(ReqVM, new ValidationContext(ReqVM), errors, true);
            if (ValidateResult)
            {
                var Query = _context.Roles.AsQueryable();
                if (IsActive.HasValue)
                    Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
                var DbResult = await Query.Where(a => a.Name.Equals(ReqVM.Title)).FirstOrDefaultAsync(CT);
                if (DbResult != null)
                        return true;
            }
            return false;
        }
        public async Task<RespMsg<TopicVM>> Get(long ReqID, bool? IsActive, CancellationToken CT)
        {
            IResponseMessage Response;

            var Query = _context.Topics.AsQueryable();
            if (IsActive.HasValue)
                Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
            var DbResult = await Query.Where(x => x.ID == ReqID).FirstOrDefaultAsync(CT);
            if (DbResult != null)
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Topic_MakeResponse.MakeResponse(DbResult, new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.OK, "موضوع مورد نظر پیدا شد.")
                    });
            else
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Topic_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.RecordNotFound, "موضوع مورد نظر پیدا نشد.")
                    });

            return (RespMsg<TopicVM>)Response;
        }
        public async Task<RespMsg<TopicVM>> Get(string ReqTopicTitle, bool? IsActive, CancellationToken CT)
        {
            IResponseMessage Response;
            var Query = _context.Topics.AsQueryable();
            if (IsActive.HasValue)
                Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
            var DbResult = await Query.Where(x => x.Title == ReqTopicTitle).FirstOrDefaultAsync(CT);
            if (DbResult != null)
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Topic_MakeResponse.MakeResponse(DbResult, new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.OK, "موضوع مورد نظر پیدا شد.")
                });
            else
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.RecordNotFound, "موضوع مورد نظر پیدا نشد.")
                });
            return (RespMsg<TopicVM>)Response;
        }
        public async Task<RespMsg_List<TopicVM>> Filter(TopicFilterVM ReqFilter, CancellationToken CT)
        {
            IResponseMessage Response;
            var errors = new List<ValidationResult>();
            bool ValidateResult = Validator.TryValidateObject(ReqFilter, new ValidationContext(ReqFilter), errors, true);
            if (ValidateResult)
            {
                var Query = _context.Topics.AsQueryable();
                Query = ReqFilter.MakeQuery(Query);//Prepair Query
                var Result = await Query.ToListAsync(CT);//Get Query Result

                if (Result != null)
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = Topic_MakeResponse.MakeResponse(Result, new List<(ServiceStatus ServiceStatus, string Message)>
                        {
                            (ServiceStatus.OK, "فیلتر انجام شد.")
                        });
                else
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = Topic_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                        {
                            (ServiceStatus.RecordNotFound, "جست و جو انجام و نتیجه ای در بر نداشت.")
                        });
            }
            else
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.HasModelValidationError, "داده های ارسالی دارای مقدار غیرمجاز است.")
                    });
            return (RespMsg_List<TopicVM>)Response;
        }
        public async Task<RespMsg_List<TopicVM>> GetAll(bool? IsActive, CancellationToken CT)
        {
            IResponseMessage Response;
            var Query = _context.Topics.AsQueryable();
            if (IsActive.HasValue)
                Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();//Prepair Query
            var Result = await Query.ToListAsync(CT);//Get Query Result

            if (Result != null)
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Topic_MakeResponse.MakeResponse(Result, new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.OK, "جست و جو انجام شد.")
                });
            else
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Topic_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.RecordNotFound, "جست و جو انجام و نتیجه ای در بر نداشت.")
                });
            return (RespMsg_List<TopicVM>)Response;
        }
        public async Task<RespMsg_List<TopicVM>> Getchild(long ReqID, bool? IsActive, CancellationToken CT)
        {
            IResponseMessage Response;
            var Query = _context.Topics.AsQueryable();
            if (IsActive.HasValue)
                Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
            var DbResult = await Query.Where(a => a.ParrentID == ReqID).ToListAsync(CT);
            if (DbResult != null)
                Response = Topic_MakeResponse.MakeResponse(DbResult, new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.OK, "زیرگروه های موضوع مورد نظر یافت شد.")
                });
            else
                Response = Topic_MakeResponse.MakeResponse( new List<(ServiceStatus ServiceStatus, string Message)>
                        {
                            (ServiceStatus.OK, "زیرگروه های موضوع مورد نظر یافت نشد.")
                        });

            return (RespMsg_List<TopicVM>)Response;
        }
        public async Task<TopicVM> Get(long ReqID, CancellationToken CT)
        {
            TopicVM Result = null;
            var Query = _context.Topics.AsQueryable();
            var DbResult = await Query.Where(x => x.ID == ReqID).FirstOrDefaultAsync(CT);
            if (DbResult != null)
                Result = new TopicVM(DbResult);
            
                return Result;
        }
    }

}
