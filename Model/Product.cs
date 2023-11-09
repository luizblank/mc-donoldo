using System;
using System.Collections.Generic;

namespace McDonaldoAPI.Model;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; }

    public byte[] Photo { get; set; }

    public string DescriptionText { get; set; }

    public virtual ICollection<ClientOrderItem> ClientOrderItems { get; set; } = new List<ClientOrderItem>();

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
