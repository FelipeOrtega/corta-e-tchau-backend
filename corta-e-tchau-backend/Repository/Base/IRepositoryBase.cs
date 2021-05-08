using System.Collections.Generic;

namespace corta_e_tchau_backend.Repository
{
    public interface IRepositoryBase<TEntity>
    {
        int Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> Get();
        TEntity SelectById(int codigo);
    }
}
