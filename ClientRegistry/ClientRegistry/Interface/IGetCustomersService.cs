using ClientRegistry.API.Models;
using ClientRegistry.API.Models.Request;
using ClientRegistry.API.Models.Response;

namespace ClientRegistry.API.Interface
{
    public interface IGetCustomersService
    {
        Task<List<GetCustomersResponse>> GetCustomers();

        Task<InformationsCustomersModel> GetInformationsCustomers(InformationsCustomersRequest request);
    }
}
