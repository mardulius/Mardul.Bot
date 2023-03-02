using Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddUserAsync(UserDto data);
    }
}
