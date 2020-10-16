using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contact4.Models
{
    public class ContactDepart
    {
        public int Id { get; set; }
        public int ContactoId { get; set; }
        public int DepartamentoId { get; set; }

        public virtual Contacto Contacts { get; set; }
        public virtual Departamento Departs { get; set; }
    }
}