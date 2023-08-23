using Client.Common.Enum;

namespace ClientRegistry.API.Models
{
    public class CustomerEmailModel
    {
        public TypePriority Priority { get; set; }
        public TypeEmail TypeEmail { get; set; }
        public string Email { get; set; }
    }
}
