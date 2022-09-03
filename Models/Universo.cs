using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeroisCRUD.Models
{
    [Table("Universo")]
    public class Universo
    {
        [Key]
        public int UniversoID { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Heroi> Herois { get; set; }
    }
}