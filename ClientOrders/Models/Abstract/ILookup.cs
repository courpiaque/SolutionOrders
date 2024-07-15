namespace ClientOrders.Models.Abstract;

// Interface which indicates if model is simple lookup value
public interface ILookup : IEntity
{
	public string Name { get; set; }

    public string Description { get; set; }
}
