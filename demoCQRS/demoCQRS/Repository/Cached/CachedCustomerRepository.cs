using System.Collections.Concurrent;
using demoCQRS.Models;

namespace demoCQRS.Repository.Cached;

public class CachedCustomerRepository : IRepositoryOrder
{
    private readonly IRepositoryOrder _repositoryOrder;
    private readonly ConcurrentDictionary<int, OrderResponse> _cached = new ConcurrentDictionary<int, OrderResponse>();
    public CachedCustomerRepository(IRepositoryOrder repositoryOrder)
    {
        _repositoryOrder = repositoryOrder;
        var dumOrdeer = new OrderResponse
        {
            Id = 1,
            NameCustomer = "test",
            NameProduct = "test"
        };
        _cached.TryAdd(dumOrdeer.Id, dumOrdeer);
    }

    public Response GetById(int id)
    {
        if (_cached.ContainsKey(id))
        {
            var order= _cached[id];
            return new Response
            {
                Success = true,
                OrderResponse = order
            };
        }
        var orderResponse =_repositoryOrder.GetById(id);
        _cached.TryAdd(id, orderResponse.OrderResponse);
        return orderResponse;
    }

    public List<OrderResponse> GetAll()
    {
        if (_cached.Count>0)
        {
            return _cached.Values.ToList();
        }

        var orders = _repositoryOrder.GetAll();
        foreach (var item in orders)
        {
            _cached.TryAdd(item.Id, item);
        }

        return orders;
    }

    public Response Create(OrderRequest orderRequest)
    {
       return _repositoryOrder.Create(orderRequest);
    }

    public Response Delete(int id)
    {
        return _repositoryOrder.Delete(id);
    }
}