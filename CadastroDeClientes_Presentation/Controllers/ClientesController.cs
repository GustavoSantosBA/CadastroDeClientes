using CadastroDeClientes_Application.Clientes.Commands;
using CadastroDeClientes_Application.Clientes.Queries;
using CadastroDeClientes_Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeClientes_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var query = new GetClienteQuery();
            var cliente = await _mediator.Send(query);
            return Ok(cliente);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var query = new GetClienteByIdQuery { Id = id };
            var cliente = await _mediator.Send(query);

            return cliente != null ? Ok(cliente) : NotFound("Cliente não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente(CreateClienteCommand command)
        {
            var createdCliente = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCliente), new { id = createdCliente.Id }, createdCliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, UpdateClienteCommand command)
        {
            command.Id = id;
            var updatedCliente = await _mediator.Send(command);

            return updatedCliente != null ? Ok(updatedCliente) : NotFound("Cliente não encontrado.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var command = new DeleteClienteCommand { Id = id };
            var deletedCliente = await _mediator.Send(command);

            return deletedCliente != null ? Ok(deletedCliente) : NotFound("Cliente não encontrado.");
        }
    }
}
