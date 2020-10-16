using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contact4.Models
{
    public class Contact4Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Contact4Context() : base("name=Contact4Context")
        {
        }

        public DbSet<Contacto> Contactoes { get; set; }

        public DbSet<Departamento> Departamentoes { get; set; }

        public System.Data.Entity.DbSet<Contact4.Models.ContactDepart> ContactDeparts { get; set; }
    }
}
