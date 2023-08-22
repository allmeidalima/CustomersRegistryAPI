namespace ClientRegistry.API.Models.Response
{
    public class GetCustomersResponse
    {
        public int idCustomers { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime registrationDate { get; set; }
    }
}
