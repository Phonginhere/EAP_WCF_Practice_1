using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_WCF_Movies_Prc2.Models
{
    public class Genress
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Moviess> Moviess { get; set; }
    }
}