using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeAssign.Models.Contacts
{
    public class Province
    {
        public int ProvinceId { get; set; }

        public string ProvinceCode { get; set; }

        public string ProvinceName { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}