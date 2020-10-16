using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contact4.Models
{
    public class Departamento
    {
        public Departamento()
        {
            this.ContactoDepartamentos = new HashSet<ContactDepart>();
        }
        public int Id { get; set; }
        public string NameDepartamento { get; set; }

        public virtual ICollection<ContactDepart> ContactoDepartamentos { get; set; }
    }
}