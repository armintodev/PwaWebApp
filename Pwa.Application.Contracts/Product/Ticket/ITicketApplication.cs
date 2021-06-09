using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Product.Ticket
{
    public interface ITicketApplication
    {
        Task<List<TicketDto>> List();
        Task<OperationResult<EditTicketDto>> Get(int id);
        Task<OperationResult> Create(CreateTicketDto dto);
        Task<OperationResult> Edit(EditTicketDto dto);
        Task<OperationResult<TicketDto>> Detail(int id);
        Task<OperationResult> Delete(int id);
    }
}
