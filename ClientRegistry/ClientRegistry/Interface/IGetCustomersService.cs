using ClientRegistry.API.Models.Response;

namespace ClientRegistry.API.Interface
{
    public interface IGetCustomersService
    {
        Task<List<GetCustomersResponse>> GetCustomers();
    }
}
