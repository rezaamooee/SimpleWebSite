using Application.Interfaces.Contexts;
using Application.Interfaces.Services.Role;
using Common.Messages;
using Common.ViewModel.Role;
using Entity.Tools;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Role.Query
{
    public class RoleQUERYServices : IRoleQUERYServices
    {
        private readonly ISiteDbContext _context;
        public RoleQUERYServices(ISiteDbContext context)
        {
            _context = context;
        }


        public async Task<bool> IfExist(long ReqID, bool? IsActive, CancellationToken CT)
        {
            var Query = _context.Roles.AsQueryable();
            if (IsActive.HasValue)
                Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
            var DbResult = await Query.Where(a => a.ID == ReqID).ToListAsync(CT);
            if (DbResult != null)
                return true;
            return false;
        }
        public async Task<bool> IfExist(RoleVM ReqVM, bool? IsActive, CancellationToken CT)
        {
            var errors = new List<ValidationResult>();
            bool ValidateResult = Validator.TryValidateObject(ReqVM, new ValidationContext(ReqVM), errors, true);
            if (ValidateResult)
            {
                var Query = _context.Roles.AsQueryable();
                if (IsActive.HasValue)
                    Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
                var DbResult = await Query.Where(a => a.Name.Equals(ReqVM.Name)).FirstOrDefaultAsync(CT);
                if (DbResult != null)
                    if (ReqVM.Permision == DbResult.Permision)
                        return true;
            }
            return false;
        }
        public async Task<RespMsg<RoleVM>> Get(long ReqID, bool? IsActive, CancellationToken CT)
        {
            IResponseMessage Response;

            var Query = _context.Roles.AsQueryable();
            if (IsActive.HasValue)
                Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
            var DbResult = await Query.Where(x => x.ID == ReqID).FirstOrDefaultAsync(CT);
            if (DbResult != null)
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Role_MakeResponse.MakeResponse(DbResult, new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.OK, "نقش مورد نظر پیدا شد.")
                    });
            else
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.RecordNotFound, "نقش مورد نظر پیدا نشد.")
                    });

            return (RespMsg<RoleVM>)Response;
        }
        public async Task<RespMsg<RoleVM>> Get(Permision ReqPermision, bool? IsActive, CancellationToken CT)
        {
            IResponseMessage Response;
            var Query = _context.Roles.AsQueryable();
            if (IsActive.HasValue)
                Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
            var DbResult = await Query.Where(x => x.Permision == ReqPermision).FirstOrDefaultAsync(CT);
            if (DbResult != null)
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Role_MakeResponse.MakeResponse(DbResult, new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.OK, "نقش مورد نظر پیدا شد.")
                });
            else
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.RecordNotFound, "نقش مورد نظر پیدا نشد.")
                });
            return (RespMsg<RoleVM>)Response;
        }
        public async Task<RespMsg<RoleVM>> Get(string ReqRoleName, bool? IsActive, CancellationToken CT)
        {
            IResponseMessage Response;
            var Query = _context.Roles.AsQueryable();
            if (IsActive.HasValue)
                Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();
            var DbResult = await Query.Where(x => x.Name == ReqRoleName).FirstOrDefaultAsync(CT);
            if (DbResult != null)
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Role_MakeResponse.MakeResponse(DbResult, new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.OK, "نقش مورد نظر پیدا شد.")
                });
            else
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.RecordNotFound, "نقش مورد نظر پیدا نشد.")
                });
            return (RespMsg<RoleVM>)Response;
        }
        public async Task<RespMsg_List<RoleVM>> Filter(RoleFilterVM ReqFilter, CancellationToken CT)
        {
            IResponseMessage Response;
            var errors = new List<ValidationResult>();
            bool ValidateResult = Validator.TryValidateObject(ReqFilter, new ValidationContext(ReqFilter), errors, true);
            if (ValidateResult)
            {
                var Query = _context.Roles.AsQueryable();
                Query = ReqFilter.MakeQuery(Query);//Prepair Query
                var Result = await Query.ToListAsync(CT);//Get Query Result

                if (Result != null)
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = Role_MakeResponse.MakeResponse(Result, new List<(ServiceStatus ServiceStatus, string Message)>
                        {
                            (ServiceStatus.OK, "فیلتر انجام شد.")
                        });
                else
                    //Make Statuse Mesasage(Erro / Mssage)
                    Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                        {
                            (ServiceStatus.RecordNotFound, "جست و جو انجام و نتیجه ای در بر نداشت.")
                        });
            }
            else
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.HasModelValidationError, "داده های ارسالی دارای مقدار نامتعارف است.")
                    });
            return (RespMsg_List<RoleVM>)Response;
        }
        public async Task<RespMsg_List<RoleVM>> GetAll(bool? IsActive, CancellationToken CT)
        {
            IResponseMessage Response;
            var Query = _context.Roles.AsQueryable();
            if (IsActive.HasValue)
                Query = Query.Where(x => x.IsActive.Equals(IsActive)).AsQueryable();//Prepair Query
            var Result = await Query.ToListAsync(CT);//Get Query Result

            if (Result != null)
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Role_MakeResponse.MakeResponse(Result, new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.OK, "جست و جو انجام شد.")
                });
            else
                //Make Statuse Mesasage(Erro / Mssage)
                Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.RecordNotFound, "جست و جو انجام و نتیجه ای در بر نداشت.")
                });
            return (RespMsg_List<RoleVM>)Response;
        }
    }

}
