using KlinikAPI.Data.Repo;
using KlinikAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlinikAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }
        public IProfinsiRepository ProfinsiRepository => new ProfinsiRepository(dc);

        public IUserRepository UserRepository => new UserRepository(dc);

        public async Task<bool> save()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
