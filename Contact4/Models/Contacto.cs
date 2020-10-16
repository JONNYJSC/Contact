using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contact4.Models
{
    public class Contacto
    {
        public Contacto()
        {
            this.ContactoDepartamentos = new HashSet<ContactDepart>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public virtual ICollection<ContactDepart> ContactoDepartamentos { get; set; }
    }
}