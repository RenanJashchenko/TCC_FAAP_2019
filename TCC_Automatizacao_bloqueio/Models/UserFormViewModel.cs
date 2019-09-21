using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC_Automatizacao_bloqueio.Models
{
    public class UserFormViewModel
    {
        public User User { get; set; }
        public ICollection<Department> Departments { get; set; }

    }
}
