using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using McDonaldoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace McDonaldoAPI.Services;

public class OrderRespository : IOrderRepository
{
    private readonly McDataBaseContext ctx;
    public OrderRespository(McDataBaseContext ctx)
        => this.ctx = ctx;

    public async Task AddItem(int orderId, int productId)
    {
        var order = await getOrder(orderId);
        if (order is null)
            throw new Exception("Order do not exist.");

        var products =
            from product in ctx.Products
            where product.Id == productId
            select product;
        var selectedProduct = await products.FirstOrDefaultAsync();
        if(selectedProduct is null)
            throw new Exception("Product do not exist.");

        var item = new ClientOrderItem();
        item.ClientOrderId = orderId;
        item.ProductId = productId;

        ctx.Add(item);
        await ctx.SaveChangesAsync();
    }

    public async Task CancelOrder(int orderId)
    {
        var order = await getOrder(orderId);
        if (order is null)
            throw new Exception("Order do not exist.");
        ctx.Remove(order);
        await ctx.SaveChangesAsync();
    }

    public async Task<int> CreateOrder(int storeId)
    {
        var selectedStore =
            from store in ctx.Stores
            where store.Id == storeId
            select store;
        if(!selectedStore.Any())
            throw new Exception("Store don't exist.");

        ClientOrder clientOrder = new ClientOrder();
        clientOrder.StoreId = storeId;
        clientOrder.OrderCode = "abcd1234";

        ctx.Add(clientOrder);
        await ctx.SaveChangesAsync();

        return clientOrder.Id;
    }

    public Task DeliveryOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task FinishOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task RemoveItem(int orderId, int productId)
    {
        throw new System.NotImplementedException();
    }

    private async Task<ClientOrder> getOrder(int orderId)
    {
        var orders =
            from order in ctx.ClientOrders
            where order.Id == orderId
            select order;

        return await orders.FirstOrDefaultAsync();
    }
}