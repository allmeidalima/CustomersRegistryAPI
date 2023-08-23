using Client.DBO.Models;
using ClientRegistry.API.Interface;
using ClientRegistry.API.Models.Register;
using System.Text.RegularExpressions;

namespace ClientRegistry.API.Models
{
    public class FieldValidation : ICustomerService
    {
        private readonly ICustomerService _decoratedService;
        const string EmailPattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
        const string PhoneNumberPattern = @"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$";

        public FieldValidation(ICustomerService decoratedService)
        {
            _decoratedService = decoratedService;
        }

        public async Task<RegisteredCustomer> CreateCustomer(CustomerRegisterRequest client)
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


            return await _decoratedService.CreateCustomer(client);
        }

        public bool IsValidEmail(string email)
        {
            return !string.IsNullOrEmpty(email) ? Regex.IsMatch(email, EmailPattern) : false;
        }

        public bool IsValidNumber(string number)
        {
            return !string.IsNullOrEmpty(number) ? Regex.IsMatch(number, PhoneNumberPattern) : false;
        }
    }
}
