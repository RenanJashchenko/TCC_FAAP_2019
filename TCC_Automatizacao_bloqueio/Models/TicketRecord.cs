using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC_Automatizacao_bloqueio.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace TCC_Automatizacao_bloqueio.Models
{
    public class TicketRecord
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
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
