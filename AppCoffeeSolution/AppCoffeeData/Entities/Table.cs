using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeeData.Entities
{
    public class Table
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Name { get; set; }
        [Column(TypeName = "Bit")]
        public bool Available { get; set; }
    }
}
