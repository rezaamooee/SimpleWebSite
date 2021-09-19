using Application.Interfaces.Contexts;
using Application.Interfaces.Services.Post;
using Common.Messages;
using Common.ViewModel.Post;
using Common.ViewModel.User;
using Entity.DBEntities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Post.Query
{
    public class PostQUERYServices : IPostQUERYServices
    {
        private readonly ISiteDbContext _context;
        public PostQUERYServices(ISiteDbContext context)
        {
            _context = context;
        }
        public async Task<bool> IfExist(long ID, bool? IsActive, CancellationToken CT)
        {
            if (ID > 0)
            {
                var Query = _context.Posts.AsQueryable();
                if (IsActive.HasValue)
                    Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
                var DbResult = await Query.Where(a => a.ID == ID).ToListAsync(CT);
                if (DbResult != null)
                    return true;
            }
            return false;
        }
        public async Task<RespMsg<T>> Get<T>(long ID, bool? IsActive, CancellationToken CT)
        {
            IResponseMessage Response;
            if ( (typeof(T) == typeof(PostAbsVM)) || (typeof(T) == typeof(PostVM)) || (typeof(T) == typeof(EntPost))  )
            {
                var Query = _context.Posts.Include(a => a.Topic).Include(b => b.Authore).ThenInclude(b1=>b1.Role).AsQueryable();
                if (IsActive.HasValue)
                    Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
                var DbResult = await Query.Where(x => x.ID == ID).FirstOrDefaultAsync(CT);
                if (DbResult != null)
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = Post_MakeResponse.MakeResponse<T>(DbResult, new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.OK, "پست مورد نظر پیدا شد.")
                    });
                else
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = Post_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.RecordNotFound, "پست مورد نظر پیدا نشد.")
                    });
            }
            else
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Post_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                         (ServiceStatus.BadParameter, "آرگومان T ارسالی اشتباه است.")
                });
            return (RespMsg<T>)Response;
        }
        public async Task<RespMsg_List<T>> Filter<T>(PostFilter ReqFilter, CancellationToken CT)
        {
            IResponseMessage Response;
            if ((typeof(T) == typeof(UserAbsVM)) || (typeof(T) == typeof(UserInfoVM)) || (typeof(T) == typeof(EntUser)))
            {
                var Query = _context.Posts.Include(a => a.Authore).Include(b => b.Topic).AsQueryable();
                var errors = new List<ValidationResult>();
                bool ValidateResult = Validator.TryValidateObject(ReqFilter, new ValidationContext(ReqFilter), errors, true);

                if (ValidateResult)
                {
                    Query = ReqFilter.MakeQuery(Query);//Prepair Query
                    var Result = await Query.ToListAsync(CT);//Get Query Result

                    if (Result != null)
                        //Make Statuse Mesasage(Erro / Mssage)
                        Response = Post_MakeResponse.MakeResponse<T>(Result, new List<(ServiceStatus ServiceStatus, string Message)>
                        {
                            (ServiceStatus.OK, "فیلتر انجام شد.")
                        });
                    else
                        //Make Statuse Mesasage(Erro / Mssage)
                        Response = Post_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                        {
                            (ServiceStatus.RecordNotFound, "جست و جو انجام و نتیجه ای در بر نداشت.")
                        });
                }
                else
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = Post_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.HasModelValidationError, "داده های ارسالی دارای مقدار نامتعارف است.")
                    });
            }
            else
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Post_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.BadParameter, "آرگومان T ارسالی اشتباه است.")
                });

            return (RespMsg_List<T>)Response;
        }
        public async Task<RespMsg_List<T>> GetAll<T>(bool? IsActive,CancellationToken CT )
        {
            IResponseMessage Response;

            if ((typeof(T) == typeof(PostAbsVM)) || (typeof(T) == typeof(PostVM)) || (typeof(T) == typeof(EntPost)))
            {
                var Query = _context.Posts.Include(a => a.Topic).Include(b => b.Authore).ThenInclude(b1=>b1.Role).AsQueryable();
                if (IsActive.HasValue)
                    Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
                var DbResult = await Query.ToListAsync(CT);
                if (DbResult != null)
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = Post_MakeResponse.MakeResponse<T>(DbResult, new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.OK, "تراکنش انجام شد.")
                    });
                else
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = Post_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.RecordNotFound, "تراکنش انجام و نتیجه ای در بر نداشت.")
                    });
            }
            else//Make Statuse Mesasage(Erro / Mssage)
                Response = Post_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.BadParameter, "آرگومان T ارسالی اشتباه است.")
                });
            return (RespMsg_List<T>)Response;
        }
    }
}
