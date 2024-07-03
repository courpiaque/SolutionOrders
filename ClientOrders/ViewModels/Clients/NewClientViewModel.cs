﻿using ClientOrders.Models;
using ClientOrders.ViewModels.Abstract;

namespace ClientOrders.ViewModels.Clients
{
    public class NewClientViewModel : BaseNewItemViewModel<Models.Client>
    {
        #region Fields
        private string name;
        private string address;
        private string phoneNumber;
        #endregion
        #region Properties
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
        public override bool ValidateSave() => !string.IsNullOrWhiteSpace(Name);
        public override Client SetItem() 
        {
            return new Client()
            {
                Name = Name,
                Address = address,
                PhoneNumber = PhoneNumber
            };
        }
    }
}
