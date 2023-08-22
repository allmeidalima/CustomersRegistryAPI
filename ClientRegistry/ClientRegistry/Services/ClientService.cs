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
    public class ClientService : IClientService, IGetCustomersService, IInformantionsCustomersService
    {
        private readonly PrjContext _prjContext;

        public ClientService(PrjContext prjContext)
        {
            _prjContext = prjContext;
        }

        public async Task<Clients> CreateClient(ClientRegisterRequest model)
        {
            var client = model.MapClientRequestToSQL();

            await _prjContext.Clients.AddAsync(client);
            await _prjContext.SaveChangesAsync();

            await AddClientAddress(model.Address, client.IdClient);
            await AddClientPhoneNumber(model.PhoneNumber, client.IdClient);
            await AddClientEmail(model.Email, client.IdClient);

            return client;
        }

        public async Task AddClientAddress(List<ClientAddressModel> model, int id)
        {
            List<ClientsAddress> clientsAddresses = new List<ClientsAddress>();

            clientsAddresses.AddRange(model.Select(x =>
            {
                var address = x.MapClientRequestAddressToSQL(id);
                return address;
            }));

            await _prjContext.ClientsAdresses.AddRangeAsync(clientsAddresses);
            await _prjContext.SaveChangesAsync();
        }

        public async Task AddClientEmail(List<ClientEmailModel> model, int id)
        {
            List<ClientsEmail> clientsEmail = new List<ClientsEmail>();

            clientsEmail.AddRange(model.Select(x =>
            {
                var email = x.MapClientRequestEmailToSQL(id);
                return email;
            }));

            await _prjContext.ClientsEmails.AddRangeAsync(clientsEmail);
            await _prjContext.SaveChangesAsync();
        }

        public async Task AddClientPhoneNumber(List<ClientPhoneNumberModel> model, int id)
        {
            List<ClientsPhoneNumber> clientsPhoneNumber = new List<ClientsPhoneNumber>();

            clientsPhoneNumber.AddRange(model.Select(x =>
            {
                var phoneNumber = x.MapClientRequestclientsPhoneNumberToSQL(id);
                return phoneNumber;
            }));

            await _prjContext.ClientsPhoneNumbers.AddRangeAsync(clientsPhoneNumber);
            await _prjContext.SaveChangesAsync();
        }

        public async Task<List<GetCustomersResponse>> GetCustomers()
        {
            var customers = await _prjContext.Clients
            .Select(x => x.MapClientsToGetCustomersResponse())
            .ToListAsync();

            return customers;
        }

        public async Task<InformationsCustomersModel> GetInformationsCustomers(InformationsCustomersRequest request)
        {
            var customerInformation = await _prjContext.Clients
            .Where(x => x.IdClient == request.IdCustomer && x.Name == request.CustomerName)
            .Include(x => x.Addresses)
            .Include(x => x.Emails)     
            .FirstOrDefaultAsync();

            if (customerInformation != null)
            {
                var principalAddress = customerInformation.Addresses.FirstOrDefault(a => a.Priority == TypePriority.Principal);
                var principalEmail = customerInformation.Emails.FirstOrDefault(e => e.Priority == TypePriority.Principal);

                if (principalAddress != null && principalEmail != null)
                {
                    var informationsModel = ClientMapper.MapClientGeneralInformationClientInformationModel(principalEmail, principalAddress, customerInformation);

                    return informationsModel;
                }
            }
            return null;
        }

    }
}
