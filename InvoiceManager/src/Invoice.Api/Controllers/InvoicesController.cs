using Invoice.Api.DTOs;
using Invoice.Application.DTOs;
using Invoice.Application.UseCases.Invoices;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoicesController : Controller
    {
        private readonly ICreateInvoiceUseCase _create;
        private readonly IDeleteInvoiceUseCase _delete;
        private readonly IGetInvoicesUseCase _getAll;
        private readonly IGetInvoiceUseCase _getById;

        public InvoicesController(
            ICreateInvoiceUseCase create,
            IDeleteInvoiceUseCase delete,
            IGetInvoicesUseCase getAll,
            IGetInvoiceUseCase getById)
        {
            _create = create;
            _delete = delete;
            _getAll = getAll;
            _getById = getById;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var invoices = await _getAll.HandleAsync();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var invoice = await _getById.HandleAsync(id);
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

            var createdInvoiceId = await _create.HandleAsync(command);
            return CreatedAtAction(nameof(Get), new { id = createdInvoiceId }, createdInvoiceId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _delete.HandleAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
