using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Piton.Banking.Managers
{
    public class ExtendedDomainService<TEntity, TKey> : DomainService
        where TEntity : class, IEntity<TKey>
    {
        protected internal readonly IRepository<TEntity, TKey> Repository;

        public ExtendedDomainService(IRepository<TEntity, TKey> repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            var entity = await Repository.FindAsync(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }
            return entity;
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            return await Repository.GetListAsync();
        }
    }
}
