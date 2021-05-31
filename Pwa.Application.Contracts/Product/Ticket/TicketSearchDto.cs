using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.Ticket
{
    public record TicketSearchDto : IDto
    {
        public string Title { get; init; }
        public string Description { get; init; }
    }
}
