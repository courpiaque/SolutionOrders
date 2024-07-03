﻿using ClientOrders.Models.Abstract;

namespace ClientOrders.Models
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
