using RestApiOrders.Helpers;
using RestApiOrders.Model;

namespace RestApiOrders.DTOs
{
    public class UnitOfMeasurementDto
    {
        public int IdUnitOfMeasurement { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

		public static implicit operator UnitOfMeasurement(UnitOfMeasurementDto cli)
			=> new UnitOfMeasurement().CopyProperties(cli);
		public static implicit operator UnitOfMeasurementDto(UnitOfMeasurement cli)
			=> new UnitOfMeasurementDto().CopyProperties(cli);
	}
}
