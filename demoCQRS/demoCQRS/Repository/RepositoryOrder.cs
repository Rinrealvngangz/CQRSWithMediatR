using demoCQRS.Models;

namespace demoCQRS.Repository;

public class RepositoryOrder : IRepositoryOrder
{
    private readonly List<OrderResponse> listOrders;

    public RepositoryOrder()
    {
        listOrders = new List<OrderResponse>(); 
    }
    public Response  GetById(int id)
    {
        Console.WriteLine($"Order id:{id}");
       var order = listOrders.FirstOrDefault(x => x.Id == id);
      
       return new Response
       {
           Success = order is not null,
           OrderResponse = order
               
       };
    }

    public List<OrderResponse> GetAll()
    {
        return listOrders;
    }

    public Response Create(OrderRequest orderRequest)
    {
        var newOrder = new OrderResponse
        {
            Id = orderRequest.Id,
            NameCustomer = orderRequest.NameCustomer,
            NameProduct = orderRequest.NameProduct
        };
        listOrders.Add(newOrder);
        return new Response
        {
            Success = true,
            OrderResponse = newOrder

        };
    }

    public Response Delete(int id)
    {
       var item = listOrders.FirstOrDefault(x => x.Id == id);
       bool isRemove =true;
       if (item is not null)
       {
          isRemove = listOrders.Remove(item); 
       }

       return new Response
       {
           Success = isRemove,
           OrderResponse = item
       };
    }
}