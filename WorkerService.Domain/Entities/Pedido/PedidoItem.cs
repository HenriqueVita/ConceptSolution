namespace WorkerService.Domain;

public class PedidoItem
{
    public Guid Id {get; set;}
    public required Produto Item {get; set;}   
    public int? Quantidade {get; set;}
}
