using Application.Interfaces.Contexts;
using Application.Interfaces.Services.User.Command;
using Common.Messages;
using Common.PublicServices;
using Common.ViewModel.User;
using Entity.DBEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


//using MakeResponse = Application.Services.User.User_MakeResponse;

namespace Application.Services.User.Command
{
    class UserCMDServices : IUserCMDServices
    {
        private readonly ISiteDbContext _context;
        public UserCMDServices(ISiteDbContext context)
        {
            _context = context;
        }

        public async Task< RespMsg<EntUser>> Add(UserVM ReqAdd , CancellationToken CT)
        {
            IResponseMessage Response;
            var errors = new List<ValidationResult>();
            var validateResult = Validator.TryValidateObject(ReqAdd, new ValidationContext(ReqAdd), errors, true);
            if (validateResult)
                if (_context.Users.Any(x => x.Username.Contains(ReqAdd.Username)) == false)
                    if (_context.Users.Any(x => x.Email == ReqAdd.Email) == false)
                        try
                        {
                            EntUser NewUser = new()
                            {
                                Address = ReqAdd.Address,
                                BirthDate = ReqAdd.BirthDate,
                                Email = ReqAdd.Email,
                                IsActive = false,
                                LastName = ReqAdd.LastName,
                                Name = ReqAdd.Name,
                                Password = Hasher.Hash(ReqAdd.Password),
                                RegDate = DateTime.Now,
                                RoleID = _context.Roles.Where(x => x.Permision == Entity.Tools.Permision.none).FirstOrDefault().ID,
                                Tell = ReqAdd.Tell,
                                Username = ReqAdd.Username,
                            };
                            var add = await _context.Users.AddAsync(NewUser,CT);
                            var save =await _context.SaveChangesAsync(CT);
                            Response = User_MakeResponse.MakeResponse<EntUser>(NewUser,
                                new List<(ServiceStatus ServiceStatus, string Message)>
                                {
                                    (ServiceStatus.OK, "اطلاعات کاربر جدید افزوده شد.")
                                });
                        }
                        catch
                        {
                            Response = User_MakeResponse.MakeResponse<EntUser>(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "ذخیره اطلاعات کاربر جدید با خطا مواجه شد.")
                            });
                        }
                    else
                        Response = User_MakeResponse.MakeResponse<EntUser>(new List<(ServiceStatus ServiceStatus, string Message)>
                        {
                            (ServiceStatus.DbDuplicatedRow, "از این پست الکترونیکی قبلا استفاده شده.")
                        });
                else
                    Response = User_MakeResponse.MakeResponse<EntUser>(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.DbDuplicatedRow, "از این نام کاربری قبلا استفاده شده.")
                    });
            else
                Response = User_MakeResponse.MakeResponse<EntUser>(new List<(ServiceStatus ServiceStatus, string Message)>
                {
                    (ServiceStatus.BadParameter, "آرگومان T ارسالی اشتباه است.")
                });
            return (RespMsg<EntUser>)Response;
        }
        public async Task<RespMsg<EntUser>> Edit(UserVM ReqEdit, CancellationToken CT)
        {
            IResponseMessage Response;
            var errors = new List<ValidationResult>();
            var ValidateResult = Validator.TryValidateObject(ReqEdit, new ValidationContext(ReqEdit), errors, true);
            if (ValidateResult)
            {

                var EditUser =await _context.Users.FindAsync(ReqEdit.ID);
                EditUser.Address = ReqEdit.Address;
                EditUser.BirthDate = ReqEdit.BirthDate;
                //EditUser.Email = ReqEdit.Email;
                //EditUser.Username = ReqEdit.Username;
                EditUser.IsActive = ReqEdit.IsActive;
                EditUser.LastName = ReqEdit.LastName;
                EditUser.Name = ReqEdit.Name;
                if(ReqEdit.Password !=String.Empty && ReqEdit.Password !=null)
                    EditUser.Password =  Hasher.Hash(ReqEdit.Password);
                EditUser.RegDate = ReqEdit.RegDate;
                EditUser.RoleID = ReqEdit.Role.ID;

                errors = new List<ValidationResult>();
                ValidateResult = Validator.TryValidateObject(ReqEdit, new ValidationContext(ReqEdit), errors, true);
                if (ValidateResult)
                {
                    try
                    {
                        _context.Users.Update(EditUser);
                        await _context.SaveChangesAsync(CT);
                        Response = User_MakeResponse.MakeResponse<EntUser>(EditUser, new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.OK, "ذخیره اطلاعات جدید کاربر جدید انجام شد.")
                            });
                    }
                    catch
                    {
                        Response = User_MakeResponse.MakeResponse<EntUser>(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "ذخیره اطلاعات کاربر جدید با خطا مواجه شد.")
                            });
                    }
                }
                else
                    Response = User_MakeResponse.MakeResponse<EntUser>(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "ذخیره اطلاعات کاربر جدید با خطا مواجه شد.")
                            });
            }
            else
                Response = User_MakeResponse.MakeResponse<EntUser>(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.HasModelValidationError, "اطلاعات ارسالی غیر مجاز است.")
                            });
            return (RespMsg<EntUser>)Response;
        }
        public async Task<RespMsg<EntUser>> Delete(long ReqDelID, CancellationToken CT)
        {
            IResponseMessage Response;
            var DbResult = await _context.Users.FindAsync( ReqDelID);
            if(DbResult !=null)
            {
                try
                {
                    _context.Users.Remove(DbResult);
                    await _context.SaveChangesAsync(CT);
                    Response = User_MakeResponse.MakeResponse<EntUser>(DbResult,new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.OK, "کاربر مورد نظر حذف شد.")
                            });
                }
                catch
                {
                    Response = User_MakeResponse.MakeResponse<EntUser>(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.HasModelValidationError, "حذف اطلاعات کاربر جدید با خطا مواجه شد.")
                            });
                }
            }
            else
            Response = User_MakeResponse.MakeResponse<EntUser>(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.HasModelValidationError, "اطلاعات ارسالی غیر مجاز است.")
                            });
            return (RespMsg<EntUser>)Response;
        }
    }
}
