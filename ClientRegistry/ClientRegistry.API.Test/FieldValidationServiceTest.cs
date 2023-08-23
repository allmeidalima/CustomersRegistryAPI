using ClientRegistry.API.Interface;
using ClientRegistry.API.Models;
using ClientRegistry.API.Models.Register;
using Moq;

namespace ClientRegistry.API.Test
{
    public class FieldValidationServiceTest : MockingTests
    {
        private FieldValidation _fieldValidation;
        private Mock<IClientService> _mockClientService;


        [SetUp]
        public void Setup()
        {
            _mockClientService = new Mock<IClientService>();
            _mockClientService.SetupAllProperties();
            _fieldValidation = new FieldValidation(_mockClientService.Object);

        }

        [Test]
        public void CreateClient_InvalidEmail_ShouldThrowException()
        {
            // Arrange
            var request = CreateClientRegisterInvalidRequest();

            // Act & Assert
            _mockClientService.Verify(service => service.CreateClient(It.IsAny<ClientRegisterRequest>()), Times.Never);
        }

        [TestCase("teste.email@gmail.com")]
        public void IsValidEmail_ShouldVerifyIfTheEmailFromClientIsValid(string value)
        {
            //Act
            var response = _fieldValidation.IsValidEmail(value);


            //Assert
            Assert.IsTrue(response);
        }

        [TestCase("(11) 96437-1782")]
        public void IsValidNumber_ShouldVerifyIfThePhoneNumberFromClientIsValid(string value)
        {
            //Act
            var response = _fieldValidation.IsValidNumber(value);


            //Assert
            Assert.IsTrue(response);
        }
    }
}
