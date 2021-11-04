using KlinikAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlinikAPI.Interfaces
{
    public interface IProfinsiRepository
    {
        Task<IEnumerable<Profinsi>> GetProfinsisAsync();
        Task<IEnumerable<Profinsi>> GetProfinsisNameAsync(string ProfinsiName);
        Task<Profinsi> GetProfinsisIdAsync(int cityid);
        Task AddProfinsi(Profinsi profinsi);
        Task DeleteProfinsi(int cityid);
    }
}
