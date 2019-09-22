using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC_Automatizacao_bloqueio.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException (string message) :base(message)
        {
        }
    }
}
