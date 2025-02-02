﻿using ClientOrders.Helpers;
using ClientOrders.Models;
using ClientOrders.Services.Abstract;
using ClientOrders.ViewModels.Abstract;

namespace ClientOrders.ViewModels.Orders
{
    public class NewOrderViewModel : BaseNewItemViewModel<Order>
    {
        public NewOrderViewModel(ICrudService crudService) : base(crudService)
        {
        }
        #region Fields
        private int id;
        private DateTime dataOrder = DateTime.Now;
        private string notes;
        private DateTime deliveryDate = DateTime.Now;
        private Client selectedClient;
        private Worker selectedWorker;
        private List<Client> clients;
        private List<Worker> workers;
		#endregion
		#region Properties

		public int Id
		{
			get => id;
			set => SetProperty(ref id, value);
		}
		public DateTime DataOrder
        {
            get => dataOrder;
            set => SetProperty(ref dataOrder, value);
        }
        public string Notes
        {
            get => notes;
            set => SetProperty(ref notes, value);
        }
        public List<Client> Clients
        {
            get => clients;
            set => SetProperty(ref clients, value);
        }
        public Client SelectedClient
        {
            get => selectedClient;
            set => SetProperty(ref selectedClient, value);
        }
        public List<Worker> Workers
        {
            get => workers;
            set => SetProperty(ref workers, value);
        }
        public Worker SelectedWorker
        {
            get => selectedWorker;
            set => SetProperty(ref selectedWorker, value);
        }
        public DateTime DeliveryDate
        {
            get => deliveryDate;
            set => SetProperty(ref deliveryDate, value);
        }
        #endregion

        public override async void OnAppearing()
        {
			Workers = (await CrudService.GetItemsAsync<Worker>()).ToList();
            Clients = (await CrudService.GetItemsAsync<Client>()).ToList();

            base.OnAppearing();
        }
        public override Order SetItem()
            => new Order
            {
                Id = Id,
                IdClient = selectedClient.Id,
                IdWorker = selectedWorker.Id,
                DataOrder = DataOrder,
                DeliveryDate = DeliveryDate,
                Notes = Notes,
            };

        public override bool ValidateSave()
        {
            return selectedClient?.Id != 0 && selectedWorker?.Id != 0;
        }
    }
}
