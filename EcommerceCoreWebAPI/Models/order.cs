using System;
using System.Collections.Generic;

namespace EcommerceCoreWebAPI.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string CustomerName { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public DateTime? OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<OrderItem> orderitems { get; set; } = new List<OrderItem>();
}
