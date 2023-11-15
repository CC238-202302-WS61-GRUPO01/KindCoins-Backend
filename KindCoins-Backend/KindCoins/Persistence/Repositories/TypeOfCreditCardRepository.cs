using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.Shared.Persistence.Contexts;
using KindCoins_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.KindCoins.Persistence.Repositories;

public class TypeOfCreditCardRepository: BaseRepository, ITypeOfCreditCardRepository
{
    public TypeOfCreditCardRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TypeOfCreditCard>> ListAsync()
    {
        return await _context.TypeOfCreditCards.ToListAsync();
    }

    public async Task AddAsync(TypeOfCreditCard typeOfCreditCard)
    {
        await _context.TypeOfCreditCards.AddAsync(typeOfCreditCard);
    }

    public async Task<TypeOfCreditCard> FindByIdAsync(int id)
    {
        return await _context.TypeOfCreditCards.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<TypeOfCreditCard> FindByNameAsync(string name)
    {
        return await _context.TypeOfCreditCards
            .FirstOrDefaultAsync(p => p.Name == name);
    }

    public void Update(TypeOfCreditCard typeOfCreditCard)
    {
        _context.TypeOfCreditCards.Update(typeOfCreditCard);
    }

    public void Remove(TypeOfCreditCard typeOfCreditCard)
    {
        _context.TypeOfCreditCards.Remove(typeOfCreditCard);
    }
}