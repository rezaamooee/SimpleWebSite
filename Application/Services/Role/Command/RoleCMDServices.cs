using Application.Interfaces.Contexts;
using Application.Interfaces.Services.Role.Command;
using Common.Messages;
using Common.ViewModel.Role;
using Entity.DBEntities;
using Entity.Tools;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Role.Command
{
    public class RoleCMDServices : IRoleCMDServices
    {
        private readonly ISiteDbContext _context;
        public RoleCMDServices(ISiteDbContext context)
        {
            _context = context;
        }

        public async Task<RespMsg<RoleVM>> Add(RoleVM ReqAdd, CancellationToken CT)
        {
            IResponseMessage Response;
            var errors = new List<ValidationResult>();
            var validateResult = Validator.TryValidateObject(ReqAdd, new ValidationContext(ReqAdd), errors, true);
            if (validateResult)
                if (_context.Roles.Any(x => x.Name.Equals(ReqAdd.Name)) == false)
                    if (_context.Roles.Any(x => x.Permision == ReqAdd.Permision) == false)
                        try
                        {
                            EntRole NewRole = new()
                            {
                                IsActive = (bool)ReqAdd.IsActive,
                                Name = ReqAdd.Name,
                                Permision =(Permision) ReqAdd.Permision,
                            };
                            var add = await _context.Roles.AddAsync(NewRole, CT);
                            var save = await _context.SaveChangesAsync(CT);
                            Response = Role_MakeResponse.MakeResponse(NewRole,
                                new List<(ServiceStatus ServiceStatus, string Message)>
                                {
                                    (ServiceStatus.OK, "اطلاعات نقش جدید افزوده شد.")
                                });
                        }
                        catch
                        {
                            Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "ذخیره اطلاعات نقش جدید با خطا مواجه شد.")
                            });
                        }
                    else
                        Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                        {
                            (ServiceStatus.DbDuplicatedRow, " این سطح دسترسی قبلا تعریف شده.")
                        });
                else
                    Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.DbDuplicatedRow, "از این نام نقش قبلا استفاده شده.")
                    });
            else
                Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.BadParameter, "آرگومان T ارسالی اشتباه است.")
                });
            return (RespMsg<RoleVM>)Response;
        }
        public async Task<RespMsg<RoleVM>> Edit(RoleVM ReqEdit, CancellationToken CT)
        {
            IResponseMessage Response;
            var errors = new List<ValidationResult>();
            var ValidateResult = Validator.TryValidateObject(ReqEdit, new ValidationContext(ReqEdit), errors, true);
            if (ValidateResult)
            {

                var EditRole = await _context.Roles.FindAsync(ReqEdit.ID);
                EditRole.IsActive = (bool)ReqEdit.IsActive;
                EditRole.Name = ReqEdit.Name;
                EditRole.Permision = (Permision)ReqEdit.Permision;

                errors = new List<ValidationResult>();
                ValidateResult = Validator.TryValidateObject(EditRole, new ValidationContext(EditRole), errors, true);
                if (ValidateResult)
                {
                    try
                    {
                        _context.Roles.Update(EditRole);
                        await _context.SaveChangesAsync(CT);
                        Response = Role_MakeResponse.MakeResponse(EditRole, new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.OK, "ذخیره اطلاعات جدید نقش انجام شد.")
                            });
                    }
                    catch
                    {
                        Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "ذخیره اطلاعات نقش با خطا مواجه شد.")
                            });
                    }
                }
                else
                    Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "اطلاعات ارسالی غیر مجاز است.")
                            });
            }
            else
                Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "اطلاعات ارسالی غیر مجاز است.")
                            });

            return (RespMsg<RoleVM>) Response;
        }
        public async Task<RespMsg<RoleVM>> Delete(long ReqDelID, CancellationToken CT)
        {
            IResponseMessage Response;
            var DbResult = await _context.Roles.FindAsync(ReqDelID);
            if (DbResult != null)
            {
                try
                {
                    _context.Roles.Remove(DbResult);
                    await _context.SaveChangesAsync(CT);
                    Response = Role_MakeResponse.MakeResponse(DbResult, new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.OK, "نقش مورد نظر حذف شد.")
                    });
                }
                catch
                {
                    Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.HasModelValidationError, "حذف اطلاعات نقش با خطا مواجه شد.")
                    });
                }
            }
            else
                Response = Role_MakeResponse.MakeResponse(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.HasModelValidationError, "اطلاعات ارسالی غیر مجاز است.")
                });
            return (RespMsg<RoleVM>)Response;
        }

    }
}
