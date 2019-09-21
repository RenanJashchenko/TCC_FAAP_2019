using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC_Automatizacao_bloqueio.Models;
using System.Linq;

namespace TCC_Automatizacao_bloqueio.Services
{
    public class DepartmentService
    {
        private readonly TCC_Automatizacao_bloqueioContext _context;

        public DepartmentService(TCC_Automatizacao_bloqueioContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
