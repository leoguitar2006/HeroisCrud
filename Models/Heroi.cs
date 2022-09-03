using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeroisCRUD.Models
{
    [Table("Heroi")]
    public class Heroi
    {
        [Key]
        public int HeroiID { get; set; }
        public int UniversoID { get; set; }
        public string Nome { get; set; }
        public virtual Universo Universo { get; set; }
    }
}