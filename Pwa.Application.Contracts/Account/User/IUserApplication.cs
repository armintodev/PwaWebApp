using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Account.User
{
    public interface IUserApplication
    {
        Task<OperationResult> Register(AuthDto dto, CancellationToken cancellationToken);
        Task<List<UserDto>> List();
        Task<OperationResult<EditUserDto>> Get(int id, CancellationToken cancellationToken);
        Task<UserDto> GetAdmin();
        Task<OperationResult> Edit(EditUserDto dto, CancellationToken cancellationToken);
        Task<OperationResult<UserDto>> Detail(int id, CancellationToken cancellationToken);
        Task<OperationResult> Delete(int id, CancellationToken cancellationToken);
        Task Activate(int id, CancellationToken cancellationToken);
        Task DeActivate(int id, CancellationToken cancellationToken);
        Task<OperationResult> Login(AuthDto dto, CancellationToken cancellationToken);
        Task<OperationResult> VerifyAccountBySms(SmsVerifyDto dto, CancellationToken cancellationToken);
        Task<OperationResult> SendCode(string phoneNumber, CancellationToken cancellationToken);
        Task Logout();
    }
}
