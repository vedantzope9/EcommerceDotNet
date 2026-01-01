using System;
using System.Collections.Generic;

namespace EcommerceCoreWebAPI.Models;

public partial class product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<orderitem> orderitems { get; set; } = new List<orderitem>();
}
