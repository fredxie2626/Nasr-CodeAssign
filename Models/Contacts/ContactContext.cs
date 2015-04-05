using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeAssign.Models.Contacts
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("DefaultConnection") { }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Province> Provinces { get; set; }

        public DbSet<City> Cities { get; set; }

    }
}