using System.Collections.Generic;
using System.Threading.Tasks;
using McDonaldoAPI.Model;

namespace McDonaldoAPI.Services;

using System;
using Model;

public class FakeOrderRepository : IOrderRepository
{
    int orderId = 42;

    public async Task AddItem(int orderId, int productId)
    {
        throw new System.NotImplementedException();
    }

    public async Task CancelOrder(int orderId)
    {
        orderId= Random.Shared.Next();
    }

    public async Task<int> CreateOrder(int storeId)
    {
        return orderId;
    }

    public async Task DeliveryOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public async Task FinishOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<List<Product>> GetMenu(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public async Task RemoveItem(int orderId, int productId)
    {
        throw new System.NotImplementedException();
    }
}