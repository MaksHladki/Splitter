using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Data.Converter.Common;
using Data.Model;
using Shared.Model.Common;
using Shared.Repository.Common;

namespace Data.Repository.Common
{
    public abstract class GenericRepository<DB, DTO> : IGenericRepository<DTO>
        where DTO : BaseEntity
        where DB : class
    {
        protected SplitterEntities Entities;
        private readonly DbSet _dbSet;

        private readonly GenericConverter<DB, DTO> converter;
        public GenericConverter<DB, DTO> Converter
        {
            get { return converter; }
        }

        internal abstract int GetEntityId(DB entityDB);
        internal abstract int GetEntityId(DTO entityDTO);

        internal GenericRepository(SplitterEntities entities, GenericConverter<DB, DTO> converter)
        {
            Entities = entities;
            _dbSet = Entities.Set(typeof(DB));
            this.converter = converter;
        }

        protected virtual DB FillCollections(DB entityDB, DTO entityDTO)
        {
            return entityDB;
        }

        public virtual DTO GetById(params object[] keyValues)
        {
            return converter.Convert(_dbSet.Find(keyValues) as DB); ;
        }

        public virtual DTO Add(DTO entityDTO)
        {
            var dbentity = converter.Convert(entityDTO);
            FillCollections(dbentity, entityDTO);
            var ins = _dbSet.Add(dbentity) as DB;
            Save();
            return ins != null ? converter.Convert(ins) : null;
        }

        public void Delete(DTO entityDTO)
        {
            _dbSet.Remove(_dbSet.Find(GetEntityId(entityDTO)));
            Save();
        }

        public void DeleteById(params object[] keyValues)
        {
            _dbSet.Remove(_dbSet.Find(keyValues));
            Save();
        }


        public virtual IEnumerable<DTO> GetAll()
        {
            return Converter.ConvertAll(((IQueryable<DB>)_dbSet));
        }

        public void Update(DTO entity)
        {
            var e = (DB)_dbSet.Find(GetEntityId(entity));
            Converter.Copy(entity, e);
            FillCollections(e, entity);
            Save();
        }

        public void Save()
        {
            try
            {
                Entities.SaveChanges();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        private void Rollback()
        {
            var dbContext = Entities;
            var manager = ((IObjectContextAdapter)dbContext).ObjectContext.ObjectStateManager;

            foreach (var entry in manager.GetObjectStateEntries(EntityState.Added).Where(entry => entry.Entity != null))
            {
                ((IObjectContextAdapter)dbContext).ObjectContext.DeleteObject(entry.Entity);
            }

            foreach (var entry in manager.GetObjectStateEntries(EntityState.Unchanged).Where(entry => entry.Entity != null))
            {
                ((IObjectContextAdapter)dbContext).ObjectContext.Refresh(RefreshMode.StoreWins, entry.Entity);
            }

            foreach (var entry in manager.GetObjectStateEntries(EntityState.Modified).Where(entry => entry.Entity != null))
            {
                ((IObjectContextAdapter)dbContext).ObjectContext.Refresh(RefreshMode.StoreWins, entry.Entity);
            }

            foreach (var entry in manager.GetObjectStateEntries(EntityState.Deleted).Where(entry => entry.Entity != null))
            {
                ((IObjectContextAdapter)dbContext).ObjectContext.Refresh(RefreshMode.StoreWins, entry.Entity);
            }

            ((IObjectContextAdapter)dbContext).ObjectContext.AcceptAllChanges();
        }
    }
}
