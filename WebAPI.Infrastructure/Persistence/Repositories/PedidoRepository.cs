namespace WebAPI.Infrastructure;

using WebAPI.Domain;
using Microsoft.EntityFrameworkCore;

public class PedidoRepository : IPedidoRepository
{
    private readonly ApplicationDbContext _context;

    public PedidoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Pedido> GetByIdAsync(int id)
    {
        Pedido? _pedido = await _context.Pedidos.FindAsync(id);
        return _pedido!;
    }

    public async Task<IEnumerable<Pedido>> GetAllAsync()
    {
        return await _context.Pedidos.ToListAsync();
    }

    public async Task AddAsync(Pedido entity)
    {
        await _context.Pedidos.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pedido entity)
    {
        _context.Pedidos.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Pedidos.FindAsync(id);
        if (entity != null)
        {
            _context.Pedidos.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}