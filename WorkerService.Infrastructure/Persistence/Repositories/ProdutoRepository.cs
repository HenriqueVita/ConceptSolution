namespace WorkerService.Infrastructure;

using WorkerService.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ApplicationDbContext _context;

    public ProdutoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    [return: MaybeNull]
    public async Task<Produto>? GetByIdAsync(int id)
    {
        Produto? _produto = await _context.Produtos!.FindAsync(id);
        return _produto!;
    }

    [return: MaybeNull]
    public async Task<IEnumerable<Produto>>? GetAllAsync()
    {
        return await _context.Produtos!.ToListAsync();
    }

    public async Task AddAsync(Produto entity)
    {
        await _context.Produtos.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Produto entity)
    {
        _context.Produtos.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Produtos.FindAsync(id);
        if (entity != null)
        {
            _context.Produtos.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}