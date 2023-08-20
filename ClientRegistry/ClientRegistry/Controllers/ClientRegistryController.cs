using ClientRegistry.API.Interface;
using ClientRegistry.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientRegistry.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("create")]
        public IActionResult CreateClient([FromBody] Client client)
        {
            try
            {
                _clientService.CreateClient(client);
                return Ok("Client created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}