namespace ClientRegistry.API.Models.Register
{
    public class ClientRegisterRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<ClientEmailModel> Email { get; set; }
        public List<ClientAddressModel> Address { get; set; }
        public List<ClientPhoneNumberModel> PhoneNumber { get; set; }
    }
}
