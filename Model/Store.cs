using System;
using System.Collections.Generic;

namespace McDonaldoAPI.Model;

public partial class Store
{
    public int Id { get; set; }

    public string Localization { get; set; }

    public virtual ICollection<ClientOrder> ClientOrders { get; set; } = new List<ClientOrder>();

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
