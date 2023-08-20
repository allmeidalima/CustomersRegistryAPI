namespace ClientRegistry.API.Models
{
    public class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<AddressClient> Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
