using KlinikAPI.Interfaces;
using KlinikAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlinikAPI.Data.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dc;

        public UserRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<User> Authenticate(string Username, string Password)
        {
            return await dc.tUsers.FirstOrDefaultAsync(x => x.Username == Username && x.Password == Password);
        }

    }
}
