using RestApiOrders.Helpers;
using RestApiOrders.Model;

namespace RestApiOrders.ForView
{
    public class ClientForView
    {
        public int IdClient { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public static implicit operator Client(ClientForView cli)
            => new Client().CopyProperties(cli);
        public static implicit operator ClientForView(Client cli)
            => new ClientForView().CopyProperties(cli);
    }
}
