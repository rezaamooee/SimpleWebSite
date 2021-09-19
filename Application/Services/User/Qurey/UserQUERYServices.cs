using Application.Interfaces.Contexts;
using Application.Interfaces.Services.User;
using Common.Messages;
using Common.PublicServices;
using Common.ViewModel.User;
using Entity.DBEntities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.User
{
    public class UserQUERYServices : IUserQUERYServices
    {
        private readonly ISiteDbContext _context;
        public UserQUERYServices(ISiteDbContext context)
        {
            _context = context;
        }
        public async Task<bool> IfExist(long ID, bool? IsActive, CancellationToken CT)
        {
            if (ID > 0)
            {
                var Query = _context.Users.AsQueryable();
                if (IsActive.HasValue)
                    Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
                var DbResult = await Query.Where(a => a.ID == ID).ToListAsync(CT);
                if (DbResult != null)
                    return true;
            }
            return false;
        }
        public async Task<bool> IfExist(UserLoginVM ReqVM, bool? IsActive, CancellationToken CT)
        {
            var errors = new List<ValidationResult>();
            bool ValidateResult = Validator.TryValidateObject(ReqVM, new ValidationContext(ReqVM), errors, true);
            if (ValidateResult)
            {
                var Query = _context.Users.AsQueryable();
                if (IsActive.HasValue)
                    Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
                var DbResult = await Query.Where(a => a.Username.Equals(ReqVM.Username)).FirstOrDefaultAsync(CT);
                if (DbResult != null)
                    if (Hasher.Verify(ReqVM.Password, DbResult.Password))
                        return true;
            }
            return false;
        }
        public async Task<RespMsg<T>> Get<T>(long ID, bool? IsActive, CancellationToken CT)
        {
            IResponseMessage Response;
            if ( (typeof(T) == typeof(UserAbsVM)) || (typeof(T) == typeof(UserInfoVM)) || (typeof(T) == typeof(UserLoginVM)) || (typeof(T) == typeof(UserVM)) || (typeof(T) == typeof(EntUser)) )
            {
                var Query = _context.Users.Include(a => a.Posts).Include(b => b.Logins).Include(c => c.Role).AsQueryable();
                if (IsActive.HasValue)
                    Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
                var DbResult = await Query.Where(x => x.ID == ID).FirstOrDefaultAsync(CT);
                if (DbResult != null)
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = User_MakeResponse.MakeResponse<T>(DbResult, new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.OK, "کاربر مورد نظر پیدا شد.")
                    });
                else
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = User_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.RecordNotFound, "کاربر مورد نظر پیدا نشد.")
                    });
            }
            else
                //Make Statuse Mesasage(Erro / Mssage)
                Response = User_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                         (ServiceStatus.BadParameter, "آرگومان T ارسالی اشتباه است.")
                });
            return (RespMsg<T>)Response;
        }
        public async Task<RespMsg<T>> Get<T>(UserLoginVM ReqVM, bool? IsActiveUser, CancellationToken CT)
        {
            IResponseMessage Response;
            if ((typeof(T) == typeof(UserAbsVM)) || (typeof(T) == typeof(UserInfoVM)) || (typeof(T) == typeof(EntUser)))
            {
                var errors = new List<ValidationResult>();
                bool ValidateResult = Validator.TryValidateObject(ReqVM, new ValidationContext(ReqVM), errors, true);
                if (ValidateResult)
                {
                    var Query = _context.Users.Include(a => a.Posts).Include(b => b.Logins).Include(c => c.Role).AsQueryable();
                    if (IsActiveUser.HasValue)
                        Query = Query.Where(x => x.IsActive.Equals(IsActiveUser)).AsQueryable();
                    var DbResult = await Query.Where(x => x.Username.Equals(ReqVM.Username)).FirstOrDefaultAsync(CT);
                    if (DbResult != null)
                        if (Hasher.Verify(ReqVM.Password, DbResult.Password))
                            //Make Statuse Mesasage(Erro / Mssage)
                            Response = User_MakeResponse.MakeResponse<T>(DbResult, new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.OK, "کاربر مورد نظر پیدا شد."),
                            });
                        else
                            //Make Statuse Mesasage(Erro / Mssage)
                            Response = User_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.RecordNotFound, "کاربر مورد نظر پیدا نشد."),
                            });
                    else
                        //Make Statuse Mesasage(Erro / Mssage)
                        Response = User_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                        {
                            (ServiceStatus.RecordNotFound, "کاربر مورد نظر پیدا نشد."),
                        });
                }
                else
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = User_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.HasModelValidationError, "داده های ارسالی دارای مقدار نامتعارف است."),
                    });
            }
            else
                //Make Statuse Mesasage(Erro / Mssage)
                Response = User_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.BadParameter, "آرگومان T ارسالی اشتباه است."),
                });
            return (RespMsg<T>)Response;
        }
        public async Task<RespMsg_List<T>> Filter<T>(UserFilterVM ReqFilter, CancellationToken CT)
        {
            IResponseMessage Response;
            if ((typeof(T) == typeof(UserAbsVM)) || (typeof(T) == typeof(UserInfoVM)) || (typeof(T) == typeof(EntUser)))
            {
                var Query = _context.Users.Include(a => a.Posts).Include(b => b.Logins).Include(c => c.Role).AsQueryable();
                var errors = new List<ValidationResult>();
                bool ValidateResult = Validator.TryValidateObject(ReqFilter, new ValidationContext(ReqFilter), errors, true);

                if (ValidateResult)
                {
                    Query = ReqFilter.MakeQuery(Query);//Prepair Query
                    var Result = await Query.ToListAsync(CT);//Get Query Result

                    if (Result != null)
                        //Make Statuse Mesasage(Erro / Mssage)
                        Response = User_MakeResponse.MakeResponse<T>(Result, new List<(ServiceStatus ServiceStatus, string Message)>
                        {
                            (ServiceStatus.OK, "فیلتر انجام شد.")
                        });
                    else
                        //Make Statuse Mesasage(Erro / Mssage)
                        Response = User_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                        {
                            (ServiceStatus.RecordNotFound, "جست و جو انجام و نتیجه ای در بر نداشت.")
                        });
                }
                else
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = User_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.HasModelValidationError, "داده های ارسالی دارای مقدار نامتعارف است.")
                    });
            }
            else
                //Make Statuse Mesasage(Erro / Mssage)
                Response = User_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.BadParameter, "آرگومان T ارسالی اشتباه است.")
                });

            return (RespMsg_List<T>)Response;
        }
        public async Task<RespMsg_List<T>> GetAll<T>(bool? IsActive,CancellationToken CT )
        {
            IResponseMessage Response;

            if ((typeof(T) == typeof(UserAbsVM)) || (typeof(T) == typeof(UserInfoVM)) || (typeof(T) == typeof(EntUser)))
            {
                var Query = _context.Users.Include(a => a.Posts).Include(b => b.Logins).Include(c => c.Role).AsQueryable();
                if (IsActive.HasValue)
                    Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
                var DbResult = await Query.ToListAsync(CT);
                if (DbResult != null)
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = User_MakeResponse.MakeResponse<T>(DbResult, new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.OK, "تراکنش انجام شد.")
                    });
                else
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = User_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.RecordNotFound, "تراکنش انجام و نتیجه ای در بر نداشت.")
                    });
            }
            else//Make Statuse Mesasage(Erro / Mssage)
                Response = User_MakeResponse.MakeResponse<T>(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.BadParameter, "آرگومان T ارسالی اشتباه است.")
                });
            return (RespMsg_List<T>)Response;
        }
    }
}
