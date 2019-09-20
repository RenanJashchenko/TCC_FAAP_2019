using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC_Automatizacao_bloqueio.Models;

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
    }
}
