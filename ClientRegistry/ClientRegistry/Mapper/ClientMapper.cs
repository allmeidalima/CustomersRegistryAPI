using Client.DBO.Models;
using ClientRegistry.API.Models;

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
    }
}
