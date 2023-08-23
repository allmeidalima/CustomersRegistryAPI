using ClientRegistry.API.Interface;
using ClientRegistry.API.Models;
using ClientRegistry.API.Models.Register;
using ClientRegistry.API.Models.Request;
using ClientRegistry.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ClientRegistry.API.Test
{
    public class ControllersTest : MockingTests
    {
        private CustomerController _clientController;
        private FieldValidation _fieldValidation;
        private Mock<IGetCustomersService> _mockGetCustomersService;
        private Mock<IInformantionsCustomersService> _mockInformantionsCustomersService;
        private Mock<ICustomerService> _mockClientService;


        [SetUp]
        public void Setup()
        {
            _mockClientService = new Mock<ICustomerService>();
            _mockClientService.SetupAllProperties();
            _mockGetCustomersService = new Mock<IGetCustomersService>();
            _mockGetCustomersService.SetupAllProperties();
            _mockInformantionsCustomersService = new Mock<IInformantionsCustomersService>();
            _mockInformantionsCustomersService.SetupAllProperties();
            _fieldValidation = new FieldValidation(_mockClientService.Object);

            _clientController = new CustomerController(_fieldValidation, _mockGetCustomersService.Object, _mockInformantionsCustomersService.Object);
        }

        [Test]
        public async Task CreateClient_ShouldGetRequestAndAddOnServer()
        {
            //Arrange
            CustomerRegisterRequest request = CreateClientRegisterRequest();

            //Act
            IActionResult response = await _clientController.CreateClient(request);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        [Test]
        public async Task CreateClient_ShouldShowAllCustomersInServer()
        {
            //Act
            IActionResult response = await _clientController.ListCustomers();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        [Test]
        public async Task CreateClient_ShouldGetCustomerFromIdCustomer()
        {
            //Arrange
            InformationsCustomersRequest request = GetCustomerFromId();

            //Act
            IActionResult response = await _clientController.ConsultCustomers(request);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(response);
        }

    }
}