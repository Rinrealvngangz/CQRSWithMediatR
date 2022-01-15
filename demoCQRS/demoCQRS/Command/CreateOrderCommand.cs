using demoCQRS.Models;
using MediatR;

namespace demoCQRS.Command;

public class CreateOrderCommand : IRequest<Response>
{
    public OrderRequest OrderRequest;
    public CreateOrderCommand(OrderRequest orderRequest)
    {
        OrderRequest = orderRequest;
    }
}