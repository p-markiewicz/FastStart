using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace FastStart.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string eMail { get; set; }
        public long nrFBO { get; set; }
        public long nrTel { get; set; }
        public virtual List<Roles> Roles { get; set; }

    }
}
