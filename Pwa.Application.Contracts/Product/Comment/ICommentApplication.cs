using System.Threading;
using System.Threading.Tasks;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Product.Comment
{
    public interface ICommentApplication
    {
        Task<OperationResult> Add(CreateCommentDto dto, CancellationToken cancellationToken);
    }
}
