using Emeraldcave.Domain.Common;
using Emeraldcave.Domain.Interfaces;
using Emeraldcave.Infrastructure.Store.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emeraldcave.Infrastructure.Store.Repositories
{
    public class ProductRepository<T> : IProductRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
