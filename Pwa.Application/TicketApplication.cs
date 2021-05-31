using Pwa.Application.Contracts.Product.Ticket;
using Pwa.Domain.Product;

namespace Pwa.Application
{
    public class TicketApplication : ITicketApplication
    {
        private readonly ITicketRepository _ticket;
        public TicketApplication(ITicketRepository ticket)
        {
            _ticket = ticket;
        }
    }
}
