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

        public CustomerRegisterRequest CreateClientRegisterRequest()
        {
            List<CustomerEmailModel> email = new List<CustomerEmailModel>()
            {
                new CustomerEmailModel()
                {
                    TypeEmail = 0,
                    Priority = 0,
                    Email = "teste.email@gmail.com"
                }
            };

            List<CustomerAddressModel> address = new List<CustomerAddressModel>()
            {
                new CustomerAddressModel()
                {
                    Priority = 0,
                    TypeAddress = 0,
                    Address = "Rua Carmela",
                    Neighborhood = "Jardim Pereira",
                    Number = "371",
                    PostalCode = "07132-580"
                }
            };

            List<CustomerPhoneNumberModel> phoneNumber = new List<CustomerPhoneNumberModel>()
            {
                new CustomerPhoneNumberModel()
                {
                    Priority = 0,
                    TypePhoneNumber = 0,
                    PhoneNumber = "(11)93709-1682",
                }
            };

            return new CustomerRegisterRequest()
            {
                Name = "Lucas",
                LastName = "Lima",
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber,
            };
        }


        public CustomerRegisterRequest CreateClientRegisterInvalidRequest()
        {
            List<CustomerEmailModel> email = new List<CustomerEmailModel>()
            {
                new CustomerEmailModel()
                {
                    TypeEmail = 0,
                    Priority = 0,
                    Email = "çanmklçng@gmail.com"
                }
            };

            List<CustomerAddressModel> address = new List<CustomerAddressModel>()
            {
                new CustomerAddressModel()
                {
                    Priority = 0,
                    TypeAddress = 0,
                    Address = "Rua Carmela",
                    Neighborhood = "Jardim Pereira",
                    Number = "371",
                    PostalCode = "07132-580"
                }
            };

            List<CustomerPhoneNumberModel> phoneNumber = new List<CustomerPhoneNumberModel>()
            {
                new CustomerPhoneNumberModel()
                {
                    Priority = 0,
                    TypePhoneNumber = 0,
                    PhoneNumber = "(11)93709/1682",
                }
            };

            return new CustomerRegisterRequest()
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

        public static RegisteredCustomer MapClientRequestToSQL(CustomerRegisterRequest model)
        {
            return new RegisteredCustomer
            {
                Name = model.Name,
                LastName = model.LastName,
                CreateDate = DateTime.Now,
            };
        }
    }
}
