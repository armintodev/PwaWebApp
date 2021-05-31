using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.Ticket
{
    public record TicketDto : IDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public int DeveloperId { get; init; }
        public string DeveloperFullName { get; init; }
        public string DeveloperEmail { get; init; }
    }
}
