
namespace demoCQRS.Models;

public class Response
{
    public bool Success { get; set; }
    public OrderResponse OrderResponse { get; set; } 
}