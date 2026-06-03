using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Code_First_Approach.Models
{
    public class Movies
    {
        [Key]
        public int Mid { get; set; }

        public string MovieName { get; set; }

        public string DirectorName { get; set; }

        public DateTime DateOfRelease { get; set; }
    }
}