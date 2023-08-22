namespace ClientRegistry.API.Models.Request
{
    public class InformationsCustomersRequest
    {
        public int IdCustomer { get; set; }
        public string CustomerName { get; set; } = string.Empty;
    }
}
