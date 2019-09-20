using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC_Automatizacao_bloqueio.Models.Enums;

namespace TCC_Automatizacao_bloqueio.Models
{
    public class TicketRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public TicketStatus Status { get; set; }

        public User User { get; set; }  

        public TicketRecord()
        {
        }

        public TicketRecord(int id, DateTime date, double amount, TicketStatus status, User user)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            User = user;
        }
    }
}
