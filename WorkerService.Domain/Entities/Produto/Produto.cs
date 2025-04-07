namespace WorkerService.Domain;

public class Produto
{
    public Guid Id {get; set;}
    public required string Nome {get; set;}      
    public required string Descricao {get; set;}
    public DateTime? DataCriacao {get; set;}
    public string? PrecoUnitario {get; set;}
}
