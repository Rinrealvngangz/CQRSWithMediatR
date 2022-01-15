namespace demoCQRS.Models;

public class OrderRequest
{
    public int Id { get; set; }
    public string NameCustomer { get; set; }
    public string NameProduct  { get; set; }
}