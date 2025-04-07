namespace WorkerService.Infrastructure;

using WorkerService.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

public class PedidoRepository : IPedidoRepository
{
    private readonly ApplicationDbContext _context;

    public PedidoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    [return: MaybeNull]
    public async Task<Pedido>? GetByIdAsync(int id)
    {
        Pedido? _pedido = await _context.Pedidos!.FindAsync(id);
        return _pedido!;
    }

    [return: MaybeNull]
    public async Task<IEnumerable<Pedido>>? GetAllAsync()
    {
        return await _context.Pedidos!.ToListAsync();
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