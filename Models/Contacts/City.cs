using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeAssign.Models.Contacts
{
    public class City
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public int ProvinceId { get; set; }

        public Province Province { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}