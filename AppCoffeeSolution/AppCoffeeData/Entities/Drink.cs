using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeeData.Entities
{
    public class Drink
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [Column(TypeName = "float(2)")]
        public float Price { get; set; }
        [Column(TypeName = "Bit")]
        public bool Available { get; set; }
    }
}
