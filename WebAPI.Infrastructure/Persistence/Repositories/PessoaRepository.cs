namespace WebAPI.Infrastructure;

using WebAPI.Domain;
using Microsoft.EntityFrameworkCore;

public class PessoaRepository : IPessoaRepository
{
    private readonly ApplicationDbContext _context;

    public PessoaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Pessoa> GetByIdAsync(int id)
    {
        Pessoa? _pessoa = await _context.Pessoas.FindAsync(id);
        return _pessoa!;
    }

    public async Task<IEnumerable<Pessoa>> GetAllAsync()
    {
        return await _context.Pessoas.ToListAsync();
    }

    public async Task AddAsync(Pessoa entity)
    {
        await _context.Pessoas.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pessoa entity)
    {
        _context.Pessoas.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Pessoas.FindAsync(id);
        if (entity != null)
        {
            _context.Pessoas.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}