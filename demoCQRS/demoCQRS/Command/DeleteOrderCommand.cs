using demoCQRS.Models;
using MediatR;

namespace demoCQRS.Command;

public class DeleteOrderCommand : IRequest<Response>
{
    public int id;
    public DeleteOrderCommand(int id)
    {
        this.id = id;
    }
}