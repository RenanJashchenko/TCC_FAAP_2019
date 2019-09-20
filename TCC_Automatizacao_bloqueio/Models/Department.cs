using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC_Automatizacao_bloqueio.Models
{
    public class Department
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddUser (User user)
        {
            Users.Add(user);
        }
    }
}
