
namespace WebAPI.Domain;

public interface IPedidoRepository
{
    public Task<Pedido> GetByIdAsync(int id);
    public Task<IEnumerable<Pedido>> GetAllAsync();
    public Task AddAsync(Pedido entity);
    public Task UpdateAsync(Pedido entity);
    public Task DeleteAsync(int id);
}