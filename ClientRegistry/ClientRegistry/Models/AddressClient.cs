using ClientRegistry.API.Enum;

namespace ClientRegistry.API.Models
{
    public class AddressClient
    {
        public Address Address { get; set; }
        public TypeAddress TypeAddress { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
    }
}
