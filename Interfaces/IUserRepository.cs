using KlinikAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlinikAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(String Username, String Password);
    }
}
