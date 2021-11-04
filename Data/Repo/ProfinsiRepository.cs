using KlinikAPI.Interfaces;
using KlinikAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlinikAPI.Data.Repo
{
    public class ProfinsiRepository : IProfinsiRepository
    {
        private readonly DataContext dc;

        public ProfinsiRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task AddProfinsi(Profinsi profinsi)
        {
            //var uom = new UnitOfWork(dc);

            await dc.tProfinsi.AddAsync(profinsi);
            

        }

        public async Task DeleteProfinsi(int cityid)
        {
           var del = await dc.tProfinsi.FindAsync(cityid);
           dc.tProfinsi.Remove(del);
        }

        public async Task<IEnumerable<Profinsi>> GetProfinsisAsync()
        {
            return await dc.tProfinsi.ToListAsync();
        }

        public async Task<Profinsi> GetProfinsisIdAsync(int cityid)
        {
            return await dc.tProfinsi.FindAsync(cityid);
        }

        public async Task<IEnumerable<Profinsi>> GetProfinsisNameAsync(string ProfinsiName)
        {
            return await dc.tProfinsi.Where(w => w.name.Contains(ProfinsiName)).ToListAsync();
        }

    }
}
