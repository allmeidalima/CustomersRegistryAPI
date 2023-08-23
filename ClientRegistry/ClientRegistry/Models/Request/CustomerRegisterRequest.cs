namespace ClientRegistry.API.Models.Register
{
    public class CustomerRegisterRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<CustomerEmailModel> Email { get; set; }
        public List<CustomerAddressModel> Address { get; set; }
        public List<CustomerPhoneNumberModel> PhoneNumber { get; set; }
    }
}
