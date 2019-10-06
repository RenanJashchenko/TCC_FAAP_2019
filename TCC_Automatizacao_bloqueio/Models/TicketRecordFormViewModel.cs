using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC_Automatizacao_bloqueio.Models
{
    public class TicketRecordFormViewModel
    {

        public TicketRecord TicketRecord { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
