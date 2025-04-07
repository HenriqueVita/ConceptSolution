namespace WebAPI.Domain;

public class StatusPedido
{
    public Guid Id {get; set;}
    public required string Status {get; set;}   
    public string? Descricao {get; set;}
}
