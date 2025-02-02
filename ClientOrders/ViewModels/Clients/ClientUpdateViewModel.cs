﻿using ClientOrders.Helpers;
using ClientOrders.Models;
using ClientOrders.Services.Abstract;
using ClientOrders.ViewModels.Abstract;
using System.Diagnostics;

namespace ClientOrders.ViewModels.Clients
{
    public class ClientUpdateViewModel : BaseItemUpdateViewModel<Client>
    {
        public ClientUpdateViewModel(ICrudService crudService) : base(crudService)
        {
        }

        #region Fields
        private int id;
        private string name;
        private string address;
        private string phoneNumber;

        #endregion
        #region Properties
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }
        #endregion
        public override async Task LoadItem(int id)
        {
            try
            {
                var item = await CrudService.GetItemAsync<Client>(id);
                if (item == null)
                    return;
                Id = id;
                this.CopyProperties(item);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public override Client SetItem()
            => new Client()
            {
                Id = ItemId
            }.CopyProperties(this);

        public override bool ValidateSave()
            => !string.IsNullOrWhiteSpace(Name) 
            && !string.IsNullOrWhiteSpace(Address)
            && !string.IsNullOrWhiteSpace(PhoneNumber);
    }
}
