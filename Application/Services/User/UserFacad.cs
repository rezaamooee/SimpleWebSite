using Application.Interfaces.Contexts;
using Application.Interfaces.Services.User;
using Application.Services.User.Command;
using Common.Messages;
using Common.ViewModel.User;
using Entity.DBEntities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.User
{
    public class UserFacad : IUserFacad
    {
        private readonly ISiteDbContext _context;

        public UserFacad(ISiteDbContext context)
        {
            _context = context;
        }
        public Task<RespMsg<EntUser>> Add(UserVM ReqNew , CancellationToken CT) =>  new UserCMDServices(_context).Add(ReqNew,CT);
        public Task<RespMsg<EntUser>> Edit(UserVM ReqEdit, CancellationToken CT) => new UserCMDServices(_context).Edit(ReqEdit, CT);
        public Task<RespMsg<EntUser>> Delete(long ReqDelID, CancellationToken CT) => new UserCMDServices(_context).Delete(ReqDelID, CT);
        public Task<bool> IfExist(long ID, bool? IsActive, CancellationToken CT) => new UserQUERYServices(_context).IfExist(ID, IsActive, CT);
        public Task<bool> IfExist(UserLoginVM ReqVM, bool? IsActive, CancellationToken CT) => new UserQUERYServices(_context).IfExist(ReqVM, IsActive, CT);
        public Task<RespMsg<T>> Get<T>(long ID, bool? IsActive, CancellationToken CT) => new UserQUERYServices(_context).Get<T>(ID, IsActive, CT);
        public Task<RespMsg<T>> Get<T>(UserLoginVM ReqVM, bool? IsActive, CancellationToken CT) => new UserQUERYServices(_context).Get<T>(ReqVM, IsActive, CT);
        public Task<RespMsg_List<T>> Filter<T>(UserFilterVM ReqFilter, CancellationToken CT) => new UserQUERYServices(_context).Filter<T>(ReqFilter, CT);
        public Task<RespMsg_List<T>> GetAll<T>(bool? IsActive, CancellationToken CT) => new UserQUERYServices(_context).GetAll<T>(IsActive, CT);

    }
}
