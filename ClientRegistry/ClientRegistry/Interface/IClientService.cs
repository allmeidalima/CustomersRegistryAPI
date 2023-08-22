using Client.DBO.Models;
using ClientRegistry.API.Models.Register;

namespace ClientRegistry.API.Interface
{
    public interface IClientService
    {
        Task<Clients> CreateClient(ClientRegisterRequest client);
    }
}
