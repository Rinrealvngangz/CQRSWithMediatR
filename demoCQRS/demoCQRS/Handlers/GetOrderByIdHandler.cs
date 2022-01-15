using demoCQRS.Models;
using demoCQRS.Query;
using demoCQRS.Repository;
using MediatR;

namespace demoCQRS.Handlers;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery,Response>
{
    private readonly IRepositoryOrder _repositoryOrder;
    public GetOrderByIdHandler(IRepositoryOrder repositoryOrder)
    {
        _repositoryOrder = repositoryOrder;
    }
    public async Task<Response> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return _repositoryOrder.GetById(request.Id);
    }
}