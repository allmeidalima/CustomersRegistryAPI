using ClientRegistry.API.Interface;
using ClientRegistry.API.Models.Register;
using Microsoft.AspNetCore.Mvc;

namespace ClientRegistry.Controllers
{
    [ApiController]
    [Route("api/Customers")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;


        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        [Route("CustomerRegistration")]
        public async Task<IActionResult> CreateClient([FromBody] ClientRegisterRequest client)
        {
            try
            {
                await _clientService.CreateClient(client);
                return Ok("Client created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListClients")]
        public async Task<IActionResult> ListCustomers()
        {
            try
            {
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ConsultCustomers")]
        public async Task<IActionResult> ConsultCustomers()
        {
            try
            {
                return Ok("OK");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}