using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace TCC_Automatizacao_bloqueio.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Display (Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }

        public ICollection<TicketRecord> Tickets { get; set; } = new List<TicketRecord>();

        public User()
        {
        }

        public User(int id, string name, string email, DateTime birthDate, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Department = department;
        }

        public void AddTickets (TicketRecord tr)
        {
            Tickets.Add(tr);
        }

        public void RemoveTickets (TicketRecord tr)
        {
            Tickets.Remove(tr);
        }

        public double TotalTickets (DateTime initial, DateTime final)
        {
            return Tickets.Where(tr => tr.Date >= initial && tr.Date <= final).Sum(tr => tr.Amount);
        }
    }
}
