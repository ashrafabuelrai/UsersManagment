using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManagment.infrastructure.Data;
using UsersManagment.infrastructure.Repositrories.Interfaces;

namespace UsersManagment.infrastructure.Repositrories.Implemention
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; private set; }
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            UserRepository = new UserRepository(_db);
        }
        public async Task Save()
        {
            _db.SaveChanges();
        }
    }
}
