using BusLocator.Persistence.Context;
using BusLocator.Persistence.UnitofWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Persistence.UnitofWork.Concrete
{
    public class UnitofWork : IUnitofWork
    {
        private readonly IDbFactory dbFactory;
        private BusLocatorContext dbContext;

        public UnitofWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public BusLocatorContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            //using(var dbTransaction = DbContext.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        DbContext.Commit();
            //        dbTransaction.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        dbTransaction.Rollback();
            //    }
            //}
            DbContext.Commit();
        }

        public async Task CommitAsync()
        {
            await DbContext.CommitAsync();
        }
    }
}
