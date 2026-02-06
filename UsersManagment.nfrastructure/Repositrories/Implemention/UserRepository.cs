using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UsersManagment.Domain.Entities;
using UsersManagment.infrastructure.Data;
using UsersManagment.infrastructure.Repositrories.Interfaces;

namespace UsersManagment.infrastructure.Repositrories.Implemention
{
    public class UserRepository :Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<User> Update(User user)
        {
            _db.Users.Update(user);
            return user;
        }
    }
}
