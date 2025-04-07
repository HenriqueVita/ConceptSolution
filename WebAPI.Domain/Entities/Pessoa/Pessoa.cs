namespace WebAPI.Domain;

public class Pessoa
{
    public Guid Id {get; set;}
    public required string Nome {get; set;}    
    public string? Sobrenome {get; set;}
    public DateTime? DataNascimento {get; set;}
    public string? Sexo {get; set;}
}
