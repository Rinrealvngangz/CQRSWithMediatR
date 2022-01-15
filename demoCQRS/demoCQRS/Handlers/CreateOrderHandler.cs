using demoCQRS.Command;
using demoCQRS.Models;
using demoCQRS.Repository;
using MediatR;

namespace demoCQRS.Handlers;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand,Response>
{
    private readonly IRepositoryOrder _repositoryOrder;
    public CreateOrderHandler(IRepositoryOrder repositoryOrder)
    {
        _repositoryOrder = repositoryOrder;
    }
    public async Task<Response> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        return _repositoryOrder.Create(request.OrderRequest);
    }
}