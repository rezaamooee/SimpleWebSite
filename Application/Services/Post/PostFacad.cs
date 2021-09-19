using Application.Interfaces.Contexts;
using Application.Interfaces.Services.Post;
using Application.Interfaces.Services.User;
using Application.Services.Post.Query;
using Application.Services.User.Command;
using Application.Services.User.Post;
using Common.Messages;
using Common.ViewModel.Post;
using Common.ViewModel.User;
using Entity.DBEntities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Post
{
    public class PostFacad : IPostFacad
    {
        private readonly ISiteDbContext _context;

        public PostFacad(ISiteDbContext context)
        {
            _context = context;
        }
        public Task<RespMsg<EntPost>> Add(PostAddVM ReqNew , CancellationToken CT) =>  new PostCMDServices(_context).Add(ReqNew,CT);
        public Task<RespMsg<EntPost>> Edit(PostVM ReqEdit, CancellationToken CT) => new PostCMDServices(_context).Edit(ReqEdit, CT);
        public Task<RespMsg<EntPost>> Delete(long ReqDelID, CancellationToken CT) => new PostCMDServices(_context).Delete(ReqDelID, CT);
        public Task<bool> IfExist(long ID, bool? IsActive, CancellationToken CT) => new PostQUERYServices(_context).IfExist(ID, IsActive, CT);
        public Task<RespMsg<T>> Get<T>(long ID, bool? IsActive, CancellationToken CT) => new PostQUERYServices(_context).Get<T>(ID, IsActive, CT);
        public Task<RespMsg_List<T>> GetAll<T>(bool? IsActive, CancellationToken CT) => new PostQUERYServices(_context).GetAll<T>(IsActive, CT);

    }
}
