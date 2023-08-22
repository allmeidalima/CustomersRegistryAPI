using ClientRegistry.API.Interface;
using ClientRegistry.API.Models.Register;
using System.Text.RegularExpressions;

namespace ClientRegistry.API.Models
{
    public class FieldValidation
    {
        private readonly IClientService _decoratedService;

        public FieldValidation(IClientService decoratedService)
        {
            _decoratedService = decoratedService;
        }

        public async Task CreateClient(ClientRegisterRequest client)
        {
            client.Email.ForEach(email =>
            {
                if (!IsValidEmail(email.Email))
                {
                    throw new Exception($"Invalid email {email.Email}");
                }
            });

            client.PhoneNumber.ForEach(phoneNumber =>
            {
                if (!IsValidNumber(phoneNumber.PhoneNumber))
                {
                    throw new Exception("Invalid email format.");
                }
            });


            await _decoratedService.CreateClient(client);
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            bool isValid = Regex.IsMatch(email, emailPattern);

            return isValid;
        }

        private bool IsValidNumber(string number)
        {
            string numberPattern = @"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$";

            bool isValid = Regex.IsMatch(number, numberPattern);

            return isValid;
        }
    }
}
