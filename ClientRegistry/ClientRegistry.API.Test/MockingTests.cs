using Client.DBO.Models;
using ClientRegistry.API.Models;
using ClientRegistry.API.Models.Register;
using ClientRegistry.API.Models.Request;

namespace ClientRegistry.API.Test
{
    public abstract class MockingTests
    {

        [SetUp]
        public virtual void Setup()
        {

        }

        public ClientRegisterRequest CreateClientRegisterRequest()
        {
            List<ClientEmailModel> email = new List<ClientEmailModel>()
            {
                new ClientEmailModel()
                {
                    TypeEmail = 0,
                    Priority = 0,
                    Email = "teste.email@gmail.com"
                }
            };

            List<ClientAddressModel> address = new List<ClientAddressModel>()
            {
                new ClientAddressModel()
                {
                    Priority = 0,
                    TypeAddress = 0,
                    Address = "Rua Carmela",
                    Neighborhood = "Jardim Pereira",
                    Number = "371",
                    PostalCode = "07132-580"
                }
            };

            List<ClientPhoneNumberModel> phoneNumber = new List<ClientPhoneNumberModel>()
            {
                new ClientPhoneNumberModel()
                {
                    Priority = 0,
                    TypePhoneNumber = 0,
                    PhoneNumber = "(11)93709-1682",
                }
            };

            return new ClientRegisterRequest()
            {
                Name = "Lucas",
                LastName = "Lima",
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber,
            };
        }


        public ClientRegisterRequest CreateClientRegisterInvalidRequest()
        {
            List<ClientEmailModel> email = new List<ClientEmailModel>()
            {
                new ClientEmailModel()
                {
                    TypeEmail = 0,
                    Priority = 0,
                    Email = "çanmklçng@gmail.com"
                }
            };

            List<ClientAddressModel> address = new List<ClientAddressModel>()
            {
                new ClientAddressModel()
                {
                    Priority = 0,
                    TypeAddress = 0,
                    Address = "Rua Carmela",
                    Neighborhood = "Jardim Pereira",
                    Number = "371",
                    PostalCode = "07132-580"
                }
            };

            List<ClientPhoneNumberModel> phoneNumber = new List<ClientPhoneNumberModel>()
            {
                new ClientPhoneNumberModel()
                {
                    Priority = 0,
                    TypePhoneNumber = 0,
                    PhoneNumber = "(11)93709/1682",
                }
            };

            return new ClientRegisterRequest()
            {
                Name = "Lucas",
                LastName = "Lima",
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber,
            };
        }


        public InformationsCustomersRequest GetCustomerFromId()
        {
            return new InformationsCustomersRequest()
            {
                IdCustomer = 1
            };
        }

        public static Clients MapClientRequestToSQL(ClientRegisterRequest model)
        {
            return new Clients
            {
                Name = model.Name,
                LastName = model.LastName,
                CreateDate = DateTime.Now,
            };
        }
    }
}
