using Client.DBO.Context;
using Client.DBO.Models;
using ClientRegistry.API.Interface;
using ClientRegistry.API.Mapper;
using ClientRegistry.API.Models;
using ClientRegistry.API.Models.Register;

namespace ClientRegistry.API.Services
{
    public class ClientService : IClientService
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
    }
}
