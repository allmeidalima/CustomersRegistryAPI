using Client.DBO.Models;
using ClientRegistry.API.Models.Register;

namespace ClientRegistry.API.Interface
{
    public interface ICustomerService
    {
        Task<RegisteredCustomer> CreateCustomer(CustomerRegisterRequest client);
    }
}
