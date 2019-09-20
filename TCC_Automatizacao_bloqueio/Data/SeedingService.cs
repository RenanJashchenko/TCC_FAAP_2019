using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC_Automatizacao_bloqueio.Models;

namespace TCC_Automatizacao_bloqueio.Data
{
    public class SeedingService
    {
        private TCC_Automatizacao_bloqueioContext _context;

        public SeedingService(TCC_Automatizacao_bloqueioContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.User.Any() || _context.TicketRecord.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Estudante");
            Department d2 = new Department(2, "Idoso");
            Department d3 = new Department(3, "Comum");

            User s1 = new User(1, "Renan Jashchenko", "renan_g_j@hotmail.com", new DateTime(1995, 8, 20), d3);
            User s2 = new User(2, "Ana Lúcia Cox", "ana.c.cox@gmail.com", new DateTime(1994, 9, 12), d1);

            TicketRecord tr1 = new TicketRecord(1, new DateTime(2019, 9, 20), 1, Models.Enums.TicketStatus.Pending, s1);
            TicketRecord tr2 = new TicketRecord(2, new DateTime(2019, 9, 20), 1, Models.Enums.TicketStatus.Billed, s2);

            _context.Department.AddRange(d1, d2, d3);
            _context.User.AddRange(s1, s2);
            _context.TicketRecord.AddRange(tr1, tr2);

            _context.SaveChanges();
            
        }
    }
}
