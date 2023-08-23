using Client.Common.Enum;
using Client.DBO.Context;
using Client.DBO.Models;
using ClientRegistry.API.Interface;
using ClientRegistry.API.Mapper;
using ClientRegistry.API.Models;
using ClientRegistry.API.Models.Register;
using ClientRegistry.API.Models.Request;
using ClientRegistry.API.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace ClientRegistry.API.Services
{
    public class CustomerService : ICustomerService, IGetCustomersService
    {
        private readonly PrjContext _prjContext;

        public CustomerService(PrjContext prjContext)
        {
            _prjContext = prjContext;
        }

        public async Task<RegisteredCustomer> CreateCustomer(CustomerRegisterRequest model)
        {
            var customer = model.MapClientRequestToSQL();

            await _prjContext.RegisteredCustomer.AddAsync(customer);
            await _prjContext.SaveChangesAsync();

            await AddCustomerAddress(model.Address, customer.IdCustomer);
            await AddCustomerPhoneNumber(model.PhoneNumber, customer.IdCustomer);
            await AddCustomerEmail(model.Email, customer.IdCustomer);

            return customer;
        }

        public async Task AddCustomerAddress(List<CustomerAddressModel> model, int id)
        {
            List<CustomerAdresses> clientsAddresses = new List<CustomerAdresses>();

            clientsAddresses.AddRange(model.Select(x =>
            {
                var address = x.MapClientRequestAddressToSQL(id);
                return address;
            }));

            await _prjContext.CustomerAdresses.AddRangeAsync(clientsAddresses);
            await _prjContext.SaveChangesAsync();
        }

        public async Task AddCustomerEmail(List<CustomerEmailModel> model, int id)
        {
            List<CustomerEmails> clientsEmail = new List<CustomerEmails>();

            clientsEmail.AddRange(model.Select(x =>
            {
                var email = x.MapClientRequestEmailToSQL(id);
                return email;
            }));

            await _prjContext.CustomerEmails.AddRangeAsync(clientsEmail);
            await _prjContext.SaveChangesAsync();
        }

        public async Task AddCustomerPhoneNumber(List<CustomerPhoneNumberModel> model, int id)
        {
            List<CustomerPhoneNumbers> clientsPhoneNumber = new List<CustomerPhoneNumbers>();

            clientsPhoneNumber.AddRange(model.Select(x =>
            {
                var phoneNumber = x.MapClientRequestclientsPhoneNumberToSQL(id);
                return phoneNumber;
            }));

            await _prjContext.CustomerPhoneNumbers.AddRangeAsync(clientsPhoneNumber);
            await _prjContext.SaveChangesAsync();
        }

        public async Task<List<GetCustomersResponse>> GetCustomers()
        {
            var customers = await _prjContext.RegisteredCustomer
            .Select(x => x.MapClientsToGetCustomersResponse())
            .ToListAsync();

            return customers;
        }

        public async Task<InformationsCustomersModel> GetInformationsCustomers(InformationsCustomersRequest request)
        {
            var customerInformation = await _prjContext.RegisteredCustomer
            .Where(x => x.IdCustomer == request.IdCustomer)
            .Include(x => x.CustomerAdresses)
            .Include(x => x.CustomerEmails)
            .FirstOrDefaultAsync();

            if (customerInformation != null)
            {
                var principalAddress = customerInformation.CustomerAdresses.FirstOrDefault(a => a.Priority == TypePriority.Principal);
                var principalEmail = customerInformation.CustomerEmails.FirstOrDefault(e => e.Priority == TypePriority.Principal);

                if (principalAddress != null && principalEmail != null)
                {
                    var informationsModel = CustomersMapper.MapClientGeneralInformationClientInformationModel(principalEmail, principalAddress, customerInformation);

                    return informationsModel;
                }
            }
            return null;
        }

    }
}
