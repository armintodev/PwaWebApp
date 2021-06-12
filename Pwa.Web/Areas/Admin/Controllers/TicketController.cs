using Microsoft.AspNetCore.Mvc;
using Pwa.Application.Contracts.Product.Ticket;
using System.Threading.Tasks;

namespace Pwa.Web.Areas.Admin.Controllers
{
    public class TicketController : AdminBaseController
    {
        private readonly ITicketApplication _ticket;
        public TicketController(ITicketApplication ticket)
        {
            _ticket = ticket;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _ticket.List();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _ticket.Create(dto);
                if (result.Success)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _ticket.Get(id);
            if (ticket.Success is false)
                return NotFound();
            return View(ticket.Data);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTicketDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _ticket.Edit(dto);
                if (result.Success)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var ticket = await _ticket.Detail(id);
            if (ticket.Success is false)
                return NotFound();

            return View(ticket.Data);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _ticket.Get(id);
            if (ticket.Success is false)
                return NotFound();

            var result = await _ticket.Delete(id);
            if (result.Success)
                return RedirectToAction("Index");

            return BadRequest(result.Message);
        }
    }
}
