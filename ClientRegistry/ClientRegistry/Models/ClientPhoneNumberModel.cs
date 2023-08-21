using Client.Common.Enum;

namespace ClientRegistry.API.Models
{
    public class ClientPhoneNumberModel
    {
        public string PhoneNumber { get; set; }
        public TypePriority Priority { get; set; }
        public TypePhoneNumber TypePhoneNumber { get; set; }
    }
}
