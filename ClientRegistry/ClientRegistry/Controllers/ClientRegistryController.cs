using ClientRegistry.API.Interface;
using ClientRegistry.API.Models.Register;
using ClientRegistry.API.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace ClientRegistry.Controllers
{
    [ApiController]
    [Route("api/Customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _fieldValidation;
        private readonly IGetCustomersService _getCustomersService;

        public CustomerController(ICustomerService fieldValidation, IGetCustomersService getCustomersService)
        {
            _fieldValidation = fieldValidation;
            _getCustomersService = getCustomersService;
        }

        [HttpPost]
        [Route("CustomerRegistration")]
        public async Task<IActionResult> CreateClient([FromBody] CustomerRegisterRequest client)
        {
            try
            {
                //Direciona para criação de clientes.
                // oi
                await _fieldValidation.CreateCustomer(client);

                return Ok("Client created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCostumers")]
        public async Task<IActionResult> ListCustomers()
        {
            try
            {
                var listCustomers = await _getCustomersService.GetCustomers();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ConsultCustomers")]
        public async Task<IActionResult> ConsultCustomers([FromBody] InformationsCustomersRequest customerInformation)
        {
            try
            {
                var informations = await _getCustomersService.GetInformationsCustomers(customerInformation);
                return Ok(informations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}