namespace WebAPI.Domain;

public class PedidoItem
{
    public Guid Id {get; set;}
    public required Produto Item {get; set;}   
    public string? Quantidade {get; set;}
}
