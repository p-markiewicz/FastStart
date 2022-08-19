using FastStart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastStart.Models
{
    public class CreateUsersDTO
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string eMail { get; set; }
        public long nrFBO { get; set; }
        public long nrTel { get; set; }
        public virtual List<Roles> Roles { get; set; }
        public string Nazwa { get; internal set; }
    }
}
