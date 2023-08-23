using AutoFixture;
using Client.DBO.Context;
using ClientRegistry.API.Interface;
using ClientRegistry.API.Models.Register;
using ClientRegistry.API.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ClientRegistry.API.Test
{
    public class CustomersServicesTest : MockingTests
    {
        private PrjContext prjContext;
        private Mock<ICustomerService> _mockCustomerService;
        private Mock<IGetCustomersService> _getCustomerService;
        private CustomerService _customerService;
        private Fixture fixture;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<PrjContext>()
                 .UseInMemoryDatabase(databaseName: "Customers")
                 .Options;

            prjContext = new PrjContext(options);
            _customerService = new CustomerService(prjContext);

            fixture = new Fixture();
        }

        [Test]
        public async Task CreateCustomer_ShouldRegisteredClientInSQLServer()
        {
            var model = fixture.Create<CustomerRegisterRequest>();

            await _customerService.CreateCustomer(model);
        }
    }
}
