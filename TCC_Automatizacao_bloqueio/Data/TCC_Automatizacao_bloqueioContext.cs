using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCC_Automatizacao_bloqueio.Models;

namespace TCC_Automatizacao_bloqueio.Models
{
    public class TCC_Automatizacao_bloqueioContext : DbContext
    {
        public TCC_Automatizacao_bloqueioContext (DbContextOptions<TCC_Automatizacao_bloqueioContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<TicketRecord> TicketRecord { get; set; }


    }
}
