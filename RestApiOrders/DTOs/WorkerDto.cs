using RestApiOrders.Helpers;
using RestApiOrders.Model;

namespace RestApiOrders.DTOs
{
    public class WorkerDto
    {
        public int IdWorker { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Login { get; set; }
        public bool IsActive { get; set; }

        //move to copy service
        public static implicit operator Worker(WorkerDto cli)
            => new Worker().CopyProperties(cli);
        public static implicit operator WorkerDto(Worker cli)
            => new WorkerDto().CopyProperties(cli);
    }
}
