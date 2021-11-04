using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlinikAPI.Interfaces
{
    public interface IUnitOfWork
    {
        IProfinsiRepository ProfinsiRepository { get; }

        IUserRepository UserRepository { get; }
        Task<bool> save();
    }
}
