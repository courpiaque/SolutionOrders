namespace ClientOrders.Models.Abstract;

public interface ILookup : IEntity
{
	public string Name { get; set; }

    public string Description { get; set; }
}
