using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Pwa.Application.Contracts.Product.Ticket;
using Pwa.Domain.Account;
using Pwa.Domain.Product;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application
{
    public class TicketApplication : ITicketApplication
    {
        private readonly ITicketRepository _ticket;
        private readonly IDeveloperRepository _developer;
        private readonly IHttpContextAccessor _accessor;
        public TicketApplication(ITicketRepository ticket,
            IDeveloperRepository developer,
            IHttpContextAccessor accessor)
        {
            _ticket = ticket;
            _developer = developer;
            _accessor = accessor;
        }

        public async Task<OperationResult> Create(CreateTicketDto dto)
        {
            var developerId = _accessor.HttpContext.User.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier).Value;

            //send email notify to developer

            Ticket ticket = new(dto.Title, dto.Description, 2);
            await _ticket.AddAsync(ticket, CancellationToken.None);
            await _ticket.SaveChangesAsync();
            return new OperationResult();
        }

        public async Task<List<TicketDto>> List()
        {
            var ticket = _ticket.TableNoTracking.Include(_ => _.Developer).ThenInclude(_ => _.User).Select(_ => new TicketDto
            {
                Id = _.Id,
                Title = _.Title,
                DeveloperFullName = _.Developer.User.FullName
            });
            return await ticket.ToListAsync();
        }

        public async Task<OperationResult> Delete(int id)
        {
            var ticket = await _ticket.GetByIdAsync(CancellationToken.None, id);

            await _ticket.DeleteAsync(ticket, CancellationToken.None);
            return new OperationResult(message: "دسته بندی با موفقیت حذف شد");
        }

        public async Task<OperationResult<TicketDto>> Detail(int id)
        {
            var ticket = await _ticket.TableNoTracking.Include(_ => _.Developer).ThenInclude(_ => _.User).FirstOrDefaultAsync(_ => _.Id == id);
            if (ticket is null)
            {
                TicketDto nullTicketDto = new();
                return new OperationResult<TicketDto>(nullTicketDto, false, "تیکتی ای با این مشخصات وجود ندارد");
            }
            TicketDto data = new()
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                DeveloperFullName = ticket.Developer.User.FullName,
                DeveloperEmail = ticket.Developer.User.Email,
                CreationDate = ticket.CreationDate.ToFarsiFull(),
                LastEditDate = ticket.LastEditDate.ToFarsiFull(),
            };
            return new OperationResult<TicketDto>(data);
        }

        public async Task<OperationResult> Edit(EditTicketDto dto)
        {
            var ticket = await _ticket.GetByIdAsync(CancellationToken.None, dto.Id);

            ticket.Edit(dto.Title, dto.Description);
            await _ticket.SaveChangesAsync();
            return new OperationResult(true, "عملیات ویرایش با موفقیت انجام شد");
        }

        public async Task<OperationResult<EditTicketDto>> Get(int id)
        {
            var ticket = await _ticket.TableNoTracking.Include(_ => _.Developer).ThenInclude(_ => _.User).FirstOrDefaultAsync(_ => _.Id == id);

            if (ticket is null)
            {
                EditTicketDto nullEditTicketDto = new();
                return new OperationResult<EditTicketDto>(nullEditTicketDto, false, "تیکتی با این مشخصات وجود ندارد");
            }
            EditTicketDto data = new()
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                DeveloperFullName = ticket.Developer.User.FullName,
                DeveloperEmail = ticket.Developer.User.Email
            };
            return new OperationResult<EditTicketDto>(data, true, "");
        }
    }
}
