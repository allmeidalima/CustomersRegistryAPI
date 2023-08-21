using ClientRegistry.API.Interface;
using ClientRegistry.API.Models;
using ClientRegistry.API.Models.Register;
using Microsoft.AspNetCore.Mvc;

namespace ClientRegistry.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly FieldValidation _fieldValidation;
        

        public ClientController(IClientService clientService, FieldValidation fieldValidation)
        {
            _clientService = clientService;
            _fieldValidation = fieldValidation;
        }

        [HttpPost("CustomerRegistration")]
        public async Task<IActionResult> CreateClient([FromBody] ClientRegisterRequest client)
        {
            try
            {
                await _fieldValidation.CreateClient(client);
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