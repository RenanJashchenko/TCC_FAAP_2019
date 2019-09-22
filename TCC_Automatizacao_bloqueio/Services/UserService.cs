using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC_Automatizacao_bloqueio.Models;
using Microsoft.EntityFrameworkCore;
using TCC_Automatizacao_bloqueio.Services.Exceptions;

namespace TCC_Automatizacao_bloqueio.Services
{
    public class UserService
    {
        private readonly TCC_Automatizacao_bloqueioContext _context;

        public UserService(TCC_Automatizacao_bloqueioContext context)
        {
            _context = context;
        }

        public List<User> FindAll()
        {
            return _context.User.ToList();
        }

        public void Insert (User obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public User FindById (int id)
        {
            return _context.User.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove (int id)
        {
            var obj = _context.User.Find(id);
            _context.User.Remove(obj);
            _context.SaveChanges();
        }

        public void Update (User obj)
        {
            if (!_context.User.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
