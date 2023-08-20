using ClientRegistry.API.Models.Register;

namespace ClientRegistry.API.Interface
{
    public interface IClientService
    {
        Task CreateClient(ClientRegisterRequest client);
    }
}
