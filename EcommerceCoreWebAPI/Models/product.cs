using System;
using System.Collections.Generic;

namespace EcommerceCoreWebAPI.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<OrderItem> orderitems { get; set; } = new List<OrderItem>();
}
