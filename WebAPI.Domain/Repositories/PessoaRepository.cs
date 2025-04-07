
namespace WebAPI.Domain;

public interface IPessoaRepository
{
    public Task<Pessoa> GetByIdAsync(int id);
    public Task<IEnumerable<Pessoa>> GetAllAsync();
    public Task AddAsync(Pessoa entity);
    public Task UpdateAsync(Pessoa entity);
    public Task DeleteAsync(int id);
}