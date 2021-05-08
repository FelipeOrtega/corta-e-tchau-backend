using corta_e_tchau_backend.Infra;
using corta_e_tchau_backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace corta_e_tchau_backend.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly ApplicationDBContext context;

        public RepositoryBase(ApplicationDBContext context) : base()
        {
            this.context = context;
        }

        public void Update(TEntity entity)
        {
            context.InitTransaction();
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SendChanges();
        }

        public void Delete(TEntity entity)
        {
            var i = SelectById(entity.id);
            if (i == null)
                throw new Exception("Este cadastro não foi encontrado no banco de dados.");

            context.InitTransaction();
            context.Set<TEntity>().Remove(entity);
            context.SendChanges();
        }

        public int Insert(TEntity entity)
        {

            context.InitTransaction();
            context.Set<TEntity>().Add(entity);
            context.SendChanges();
            var id = entity.id;
            return id;
        }

        public List<TEntity> Get()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity SelectById(int codigo)
        {
            var entity = context.Set<TEntity>().Find(codigo);
            context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
