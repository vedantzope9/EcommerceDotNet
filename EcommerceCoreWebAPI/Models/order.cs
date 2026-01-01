using System;
using System.Collections.Generic;

namespace EcommerceCoreWebAPI.Models;

public partial class order
{
    public int OrderId { get; set; }

    public string CustomerName { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public DateTime? OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<orderitem> orderitems { get; set; } = new List<orderitem>();
}
