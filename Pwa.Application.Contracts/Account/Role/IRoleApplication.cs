using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Account.Role
{
    public interface IRoleApplication
    {
        Task<List<RoleDto>> List();
        Task<OperationResult> Create(CreateRoleDto dto, CancellationToken cancellationToken);
        Task<OperationResult<EditRoleDto>> Get(int id, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditRoleDto dto, CancellationToken cancellationToken);
        Task<OperationResult<RoleDto>> Detail(int id, CancellationToken cancellationToken);
        Task<OperationResult> Delete(int id, CancellationToken cancellationToken);
    }
}
