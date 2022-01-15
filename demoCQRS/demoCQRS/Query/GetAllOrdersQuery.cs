using demoCQRS.Models;
using MediatR;

namespace demoCQRS.Query;

public class GetAllOrdersQuery : IRequest<List<OrderResponse>>
{
    
}