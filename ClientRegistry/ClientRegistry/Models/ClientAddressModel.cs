using Client.Common.Enum;

namespace ClientRegistry.API.Models
{
    public class ClientAddressModel
    {
        public TypePriority Priority { get; set; }
        public TypeAddress TypeAddress { get; set; }
        public string Address { get; set; }
        public string Neighborhood { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
    }
}
