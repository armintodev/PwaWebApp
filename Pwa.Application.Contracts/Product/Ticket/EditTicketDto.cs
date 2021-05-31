using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.Ticket
{
    public record EditTicketDto : IDto
    {
        public int Id { get; init; }
    }
}
