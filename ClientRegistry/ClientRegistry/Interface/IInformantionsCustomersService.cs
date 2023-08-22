using ClientRegistry.API.Models;
using ClientRegistry.API.Models.Request;

namespace ClientRegistry.API.Interface
{
    public interface IInformantionsCustomersService
    {
        Task<InformationsCustomersModel> GetInformationsCustomers(InformationsCustomersRequest request);
    }
}
