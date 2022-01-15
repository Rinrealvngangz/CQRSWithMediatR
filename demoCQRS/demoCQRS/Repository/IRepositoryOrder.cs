using demoCQRS.Models;

namespace demoCQRS.Repository;

public interface IRepositoryOrder
{
    Response GetById(int id);
    List<OrderResponse> GetAll();
    Response Create(OrderRequest orderRequest);
    Response Delete(int id);
}