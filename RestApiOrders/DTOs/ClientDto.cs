using RestApiOrders.Helpers;
using RestApiOrders.Model;

namespace RestApiOrders.DTOs
{
    public class ClientDto
    {
        public int IdClient { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public static implicit operator Client(ClientDto cli)
            => new Client().CopyProperties(cli);
        public static implicit operator ClientDto(Client cli)
            => new ClientDto().CopyProperties(cli);
    }
}
