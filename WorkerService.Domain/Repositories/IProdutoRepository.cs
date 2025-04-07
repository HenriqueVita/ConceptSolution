
namespace WorkerService.Domain;

public interface IProdutoRepository
{
    public Task<Produto>? GetByIdAsync(int id);
    public Task<IEnumerable<Produto>>? GetAllAsync();
    public Task AddAsync(Produto entity);
    public Task UpdateAsync(Produto entity);
    public Task DeleteAsync(int id);
}