using Client.DBO.Models;
using ClientRegistry.API.Models;
using ClientRegistry.API.Models.Register;
using ClientRegistry.API.Models.Response;

namespace ClientRegistry.API.Mapper
{
    static class CustomersMapper
    {
        #region [Map To Models]
        public static CustomerModel MapClientsToClientModel(this RegisteredCustomer entity)
        {
            return new CustomerModel
            {
                IdClient = entity.IdCustomer,
                Name = entity.Name,
                LastName = entity.LastName,
            };
        }

        public static InformationsCustomersModel MapClientGeneralInformationClientInformationModel(CustomerEmails entity1, CustomerAdresses entity2, RegisteredCustomer entity3)
        {
            return new InformationsCustomersModel
            {
                IdCustomer = entity3.IdCustomer,
                Name = entity3.Name,
                Email = entity1.Email,
                Address = entity2.Address,
                Neighborhood = entity2.Neighborhood,
                Number = entity2.Number,
            };
        }

        public static GetCustomersResponse MapClientsToGetCustomersResponse(this RegisteredCustomer model)
        {
            return new GetCustomersResponse
            {
                idCustomers = model.IdCustomer,
                Name = model.Name,
                LastName = model.LastName,
                registrationDate = model.CreateDate,
            };
        }
        #endregion

        #region [Map To SQL]
        public static RegisteredCustomer MapClientRequestToSQL(this CustomerRegisterRequest model)
        {
            return new RegisteredCustomer
            {
                Name = model.Name,
                LastName = model.LastName,
                CreateDate = DateTime.Now,
            };
        }

        public static CustomerEmails MapClientRequestEmailToSQL(this CustomerEmailModel model, int id)
        {
            return new CustomerEmails
            {
                IdClient = id,
                Priority = model.Priority,
                TypeEmail = model.TypeEmail,
                Email = model.Email,
                CreateDate = DateTime.Now,
            };
        }

        public static CustomerAdresses MapClientRequestAddressToSQL(this CustomerAddressModel model, int id)
        {
            return new CustomerAdresses
            {
                IdClient = id,
                Priority = model.Priority,
                TypeAddress = model.TypeAddress,
                Address = model.Address,
                Neighborhood = model.Neighborhood,
                Number = model.Number,
                PostalCode = model.PostalCode,
                CreateDate = DateTime.Now,
            };
        }

        public static CustomerPhoneNumbers MapClientRequestclientsPhoneNumberToSQL(this CustomerPhoneNumberModel model, int id)
        {
            return new CustomerPhoneNumbers
            {
                IdClient = id,
                Priority = model.Priority,
                PhoneNumber = model.PhoneNumber,
                CreateDate = DateTime.Now,
            };
        }
        #endregion

    }
}
