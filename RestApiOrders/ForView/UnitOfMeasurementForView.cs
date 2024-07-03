using RestApiOrders.Helpers;
using RestApiOrders.Model;

namespace RestApiOrders.ForView
{
    public class UnitOfMeasurementForView
    {
        public int IdUnitOfMeasurement { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

		public static implicit operator UnitOfMeasurement(UnitOfMeasurementForView cli)
			=> new UnitOfMeasurement().CopyProperties(cli);
		public static implicit operator UnitOfMeasurementForView(UnitOfMeasurement cli)
			=> new UnitOfMeasurementForView().CopyProperties(cli);
	}
}
