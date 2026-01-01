using System;
using System.Collections.Generic;

namespace EcommerceCoreWebAPI.Models;

public partial class orderitem
{
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual order? Order { get; set; }

    public virtual product? Product { get; set; }
}
