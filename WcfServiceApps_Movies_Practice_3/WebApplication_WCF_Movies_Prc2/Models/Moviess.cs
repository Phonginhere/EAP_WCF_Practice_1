using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_WCF_Movies_Prc2.Models
{
    public class Moviess
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public System.DateTime ReleaseDate { get; set; }
        public int RunningTime { get; set; }
        public int GenreId { get; set; }
        public decimal BoxOffice { get; set; }

        public virtual Genress Genress { get; set; }
    }
}