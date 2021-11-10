using eAgenda.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eAgenda.Infra.Data.ORM
{

    public class RepositoryOrmBase<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly eAgendaDbContext db;
        protected readonly DbSet<TEntity> dbSet;

        public RepositoryOrmBase(eAgendaDbContext dbContext)
        {
            db = dbContext;
            dbSet = db.Set<TEntity>();
        }

        public virtual bool Inserir(TEntity entity)
        {
            try
            {
                dbSet.Add(entity);

                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return true;
        }

        public virtual bool Editar(TEntity entityNewValues)
        {
            try
            {
                db.Update(entityNewValues);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return true;
        }

        public virtual bool Editar(int id, TEntity entityNewValues)
        {
            try
            {
                TEntity entityForUpdate = dbSet.SingleOrDefault(x => x.Id.Equals(id));

                entityNewValues.Id = id;

                db.Entry(entityForUpdate).CurrentValues.SetValues(entityNewValues);

                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return true;
        }

        public virtual bool Excluir(int id)
        {
            try
            {
                TEntity entityForDelete = SelecionarPorId(id);

                db.Remove(entityForDelete);

                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        public virtual TEntity SelecionarPorId(int id)
        {
            return dbSet.SingleOrDefault(x => x.Id.Equals(id));
        }

        public virtual List<TEntity> SelecionarTodos()
        {
            return dbSet.ToList();
        }

        public virtual bool Excluir(TEntity entity)
        {
            dbSet.Remove(entity);

            db.SaveChanges();

            return true;
        }
    }
}
