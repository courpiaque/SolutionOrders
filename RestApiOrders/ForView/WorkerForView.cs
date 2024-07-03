using RestApiOrders.Helpers;
using RestApiOrders.Model;

namespace RestApiOrders.ForView
{
    public class WorkerForView
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; }

        //move to copy service
        public static implicit operator Worker(WorkerForView cli)
            => new Worker().CopyProperties(cli);
        public static implicit operator WorkerForView(Worker cli)
            => new WorkerForView().CopyProperties(cli);
    }
}
