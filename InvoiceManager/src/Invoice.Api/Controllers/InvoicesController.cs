using Invoice.Api.DTOs;
using Invoice.Application.DTOs;
using Invoice.Application.UseCases.Invoices.Commands.CreateInvoice;
using Invoice.Application.UseCases.Invoices.Commands.DeleteInvoice;
using Invoice.Application.UseCases.Invoices.Queries.GetInvoice;
using Invoice.Application.UseCases.Invoices.Queries.GetInvoices;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoicesController(
        ICreateInvoiceUseCase create,
        IDeleteInvoiceUseCase delete,
        IGetInvoicesUseCase getAll,
        IGetInvoiceUseCase getById) : Controller
    {
        private readonly ICreateInvoiceUseCase _create = create;
        private readonly IDeleteInvoiceUseCase _delete = delete;
        private readonly IGetInvoicesUseCase _getAll = getAll;
        private readonly IGetInvoiceUseCase _getById = getById;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var invoices = await _getAll.ExecuteAsync();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var invoice = await _getById.ExecuteAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateInvoiceRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map the request to a command
            var command = new CreateInvoiceCommand
            {
                CustomerName = request.CustomerName,
                InvoiceDate = request.InvoiceDate,
                Items = request.Items.Select(item => new InvoiceItemDto
                {
                    Description = item.Description,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                }).ToList()
            };

            var createdInvoiceId = await _create.ExecuteAsync(command);
            return CreatedAtAction(nameof(Get), new { id = createdInvoiceId }, createdInvoiceId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _delete.ExecuteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
