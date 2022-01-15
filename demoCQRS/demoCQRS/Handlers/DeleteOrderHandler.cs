using demoCQRS.Command;
using demoCQRS.Models;
using demoCQRS.Repository;
using MediatR;

namespace demoCQRS.Handlers;

public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand,Response>
{
    private readonly IRepositoryOrder _repositoryOrder;
    public DeleteOrderHandler(IRepositoryOrder repositoryOrder)
    {
        _repositoryOrder = repositoryOrder;
    }
    public async Task<Response> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        return _repositoryOrder.Delete(request.id);
    }
}