using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webapi_Assessment_.Models
{
    public class Country
    {
        [Key]
        public int ID { get; set; }

        public string CountryName { get; set; }

        public string Capital { get; set; }
    }
        
}