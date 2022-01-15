using demoCQRS.Models;
using MediatR;

namespace demoCQRS.Query;

public class GetOrderByIdQuery : IRequest<Response>
{
    public int Id { get; }
    public GetOrderByIdQuery(int id)
    {
        Id = id;
    }
}