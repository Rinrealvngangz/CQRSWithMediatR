using demoCQRS.Models;
using demoCQRS.Query;
using demoCQRS.Repository;
using MediatR;

namespace demoCQRS.Handlers;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery,List<OrderResponse>>
{
    private readonly IRepositoryOrder _repositoryOrder;
    public GetAllOrdersHandler(IRepositoryOrder repositoryOrder)
    {
        _repositoryOrder = repositoryOrder;
    }
    public async Task<List<OrderResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
      return  _repositoryOrder.GetAll();
    }
}