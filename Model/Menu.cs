using System;
using System.Collections.Generic;

namespace McDonaldoAPI.Model;

public partial class Menu
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int StoreId { get; set; }

    public decimal Price { get; set; }

    public virtual Product Product { get; set; }

    public virtual Store Store { get; set; }
}
