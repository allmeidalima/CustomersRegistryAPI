using Client.DBO.Models;
using ClientRegistry.API.Models;
using ClientRegistry.API.Models.Register;

namespace ClientRegistry.API.Mapper
{
    static class ClientMapper
    {
        public static ClientModel MapClientsToClientModel(this Clients entity)
        {
            return new ClientModel
            {
                IdClient = entity.IdClient,
                Name = entity.Name,
                LastName = entity.LastName,
            };
        }

        public static ClientInformationModel MapClientGeneralInformationClientInformationModel(this ClientsEmail entity1, ClientsAddress entity2, Clients entity3)
        {
            return new ClientInformationModel
            {
                IdClient = entity3.IdClient,
                Name = entity3.Name,
                Email = entity1.Email,
                Address = entity2.Address,
                Neighborhood = entity2.Neighborhood,
                Number = entity2.Number,
            };
        }

        public static Clients MapClientRequestToSQL(this ClientRegisterRequest model)
        {
            return new Clients
            {
                Name = model.Name,
                LastName = model.LastName,
                CreateDate = DateTime.Now,
            };
        }

        public static ClientsEmail MapClientRequestEmailToSQL(this ClientEmailModel model, int id)
        {
            return new ClientsEmail
            {
                IdClient = id,
                Priority = model.Priority,
                TypeEmail = model.TypeEmail,
                Email = model.Email,
                CreateDate = DateTime.Now,
            };
        }

        public static ClientsAddress MapClientRequestAddressToSQL(this ClientAddressModel model, int id)
        {
            return new ClientsAddress
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

        public static ClientsPhoneNumber MapClientRequestclientsPhoneNumberToSQL(this ClientPhoneNumberModel model, int id)
        {
            return new ClientsPhoneNumber
            {
                IdClient = id,
                Priority = model.Priority,
                PhoneNumber = model.PhoneNumber,
                CreateDate = DateTime.Now,
            };
        }

    }
}
