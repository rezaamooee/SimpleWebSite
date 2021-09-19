using Application.Interfaces.Contexts;
using Application.Interfaces.Services.Post.Command;
using Application.Services.Post;
using Common.Messages;
using Common.ViewModel.Post;
using Entity.DBEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;


//using MakeResponse = Application.Services.User.User_MakeResponse;

namespace Application.Services.User.Post
{
    class PostCMDServices : IPostCMDServices
    {
        private readonly ISiteDbContext _context;
        public PostCMDServices(ISiteDbContext context)
        {
            _context = context;
        }

        public async Task<RespMsg<EntPost>> Add(PostAddVM ReqAdd, CancellationToken CT)
        {
            IResponseMessage Response;
            var errors = new List<ValidationResult>();
            var validateResult = Validator.TryValidateObject(ReqAdd, new ValidationContext(ReqAdd), errors, true);
            if (validateResult)
                try
                {
                    EntPost NewPost = new()
                    {

                        ABS = ReqAdd.ABS,
                        AuthoreID = ReqAdd.Author.ID,
                        Content = ReqAdd.Content,
                        EngName = ReqAdd.EngName,
                        IsActive = ReqAdd.IsActive,
                        PicSRC = ReqAdd.PicSRC,
                        Title = ReqAdd.Title,
                        TopicID = ReqAdd.Topic.ID,
                        WriteDate = DateTime.Now.Date
                    };

                    var add = await _context.Posts.AddAsync(NewPost, CT);
                    var save = await _context.SaveChangesAsync(CT);
                    Response = Post_MakeResponse.MakeResponse<EntPost>(NewPost,
                        new List<(ServiceStatus ServiceStatus, string Message)>
                        {
                                    (ServiceStatus.OK, "اطلاعات پست جدید افزوده شد.")
                        });
                }
                catch
                {
                    Response = User_MakeResponse.MakeResponse<EntUser>(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "ذخیره اطلاعات پست جدید با خطا مواجه شد.")
                            });
                }

            else
                Response = User_MakeResponse.MakeResponse<EntUser>(new List<(ServiceStatus ServiceStatus, string Message)>
                    {
                        (ServiceStatus.HasModelValidationError, "اطلاعات ارسالی حاوی داده های غیر مجاز است.")
                    });

            return (RespMsg<EntPost>)Response;
        }
        public async Task<RespMsg<EntPost>> Edit(PostVM ReqEdit, CancellationToken CT)
        {
            IResponseMessage Response;
            var errors = new List<ValidationResult>();
            var ValidateResult = Validator.TryValidateObject(ReqEdit, new ValidationContext(ReqEdit), errors, true);
            if (ValidateResult)
            {

                var EditPost =await _context.Posts.FindAsync(ReqEdit.ID);
                EditPost.ABS = ReqEdit.ABS;
                EditPost.AuthoreID = ReqEdit.Author.ID;
                EditPost.Content = ReqEdit.Content;
                EditPost.EngName = ReqEdit.EngName;
                EditPost.IsActive = ReqEdit.IsActive;
                EditPost.PicSRC = ReqEdit.PicSRC;
                EditPost.Title = ReqEdit.Title;
                EditPost.TopicID = ReqEdit.Topic.ID;
                EditPost.WriteDate = ReqEdit.WriteDate;
                

                errors = new List<ValidationResult>();
                ValidateResult = Validator.TryValidateObject(ReqEdit, new ValidationContext(ReqEdit), errors, true);
                if (ValidateResult)
                {
                    try
                    {
                        _context.Posts.Update(EditPost);
                        await _context.SaveChangesAsync(CT);
                        Response = Post_MakeResponse.MakeResponse<EntPost>(EditPost, new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.OK, "ذخیره اطلاعات جدید پست انجام شد.")
                            });
                    }
                    catch
                    {
                        Response = Post_MakeResponse.MakeResponse<EntPost>(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "ذخیره اطلاعات پست با خطا مواجه شد.")
                            });
                    }
                }
                else
                    Response = Post_MakeResponse.MakeResponse<EntPost>(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.DbAddWithError, "ذخیره اطلاعات پست با خطا مواجه شد.")
                            });
            }
            else
                Response = Post_MakeResponse.MakeResponse<EntPost>(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.HasModelValidationError, "اطلاعات ارسالی غیر مجاز است.")
                            });
            return (RespMsg<EntPost>)Response;
        }
        public async Task<RespMsg<EntPost>> Delete(long ReqDelID, CancellationToken CT)
        {
            IResponseMessage Response;
            var DbResult = await _context.Posts.FindAsync( ReqDelID);
            if(DbResult !=null)
            {
                try
                {
                    _context.Posts.Remove(DbResult);
                    await _context.SaveChangesAsync(CT);
                    Response = Post_MakeResponse.MakeResponse<EntUser>(DbResult,new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.OK, "پست مورد نظر حذف شد.")
                            });
                }
                catch
                {
                    Response = Post_MakeResponse.MakeResponse<EntUser>(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.HasModelValidationError, "حذف اطلاعات پست با خطا مواجه شد.")
                            });
                }
            }
            else
            Response = Post_MakeResponse.MakeResponse<EntUser>(new List<(ServiceStatus ServiceStatus, string Message)>
                            {
                                (ServiceStatus.HasModelValidationError, "اطلاعات ارسالی غیر مجاز است.")
                            });
            return (RespMsg<EntPost>)Response;
        }
    }
}
