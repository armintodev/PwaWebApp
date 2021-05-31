using Pwa.Application.Contracts.Product.Comment;
using Pwa.Domain.Product;

namespace Pwa.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _comment;
        public CommentApplication(ICommentRepository comment)
        {
            _comment = comment;
        }
    }
}
