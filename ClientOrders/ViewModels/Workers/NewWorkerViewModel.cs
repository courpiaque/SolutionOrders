using ClientOrders.ViewModels.Abstract;

namespace ClientOrders.ViewModels.Workers
{
    public class NewWorkerViewModel : BaseNewItemViewModel<Models.Worker>
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }
        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }
        public override bool ValidateSave()
            => !string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName);

        public override Models.Worker SetItem()
            => new Models.Worker()
            {
                Id = 0,
                FirstName = FirstName,
                LastName = LastName
            };
    }
}
