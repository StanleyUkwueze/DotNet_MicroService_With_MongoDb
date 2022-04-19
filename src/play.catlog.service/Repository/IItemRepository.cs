using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using play.catlog.service.Entities;

namespace play.catlog.service.Repository
{
    public interface IItemRepository
    {
        Task CreateAsync(Item entity);
        Task<IReadOnlyCollection<Item>> getAllItems();
        Task<Item> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Item entity);
    }
}