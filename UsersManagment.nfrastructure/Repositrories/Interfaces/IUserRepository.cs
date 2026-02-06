using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManagment.Domain.Entities;

namespace UsersManagment.infrastructure.Repositrories.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        Task<User> Update(User user);
    }
}
