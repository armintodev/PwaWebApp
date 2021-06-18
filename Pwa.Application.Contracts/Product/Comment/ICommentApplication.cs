using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Product.Comment
{
    public interface ICommentApplication
    {
        Task<OperationResult> Add(CreateCommentDto dto, CancellationToken cancellationToken);
        Task<OperationResult<EditCommentDto>> Get(int id, CancellationToken cancellationToken);
        Task<List<CommentDto>> List(int id, CancellationToken cancellationToken);
        Task<OperationResult<int>> Delete(int id, CancellationToken cancellationToken);
        Task<OperationResult<CommentDto>> Detail(int id, CancellationToken cancellationToken);
        Task Accepted(int id, CancellationToken cancellationToken);
        Task Rejected(int id, CancellationToken cancellationToken);
    }
}
