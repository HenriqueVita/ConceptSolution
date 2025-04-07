namespace WebAPI.Domain;

public class Pedido
{
    public Guid Id {get; set;}
    public required List<PedidoItem> Items {get; set;}   
    public StatusPedido? Status {get; set;}
    public required Pessoa Pessoa {get; set;}
    public DateTime? DataCriacao {get; set;}
    public DateTime? DataUltimoStatus {get; set;}
}
