using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_WCF_Movies.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public String GenreName { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}