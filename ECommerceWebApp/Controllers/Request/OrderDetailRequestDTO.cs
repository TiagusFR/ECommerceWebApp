﻿namespace ECommerceWebApp.Controllers.Request
{
    public class OrderDetailRequestDTO
    {
        public Guid Id { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }
    }
}
