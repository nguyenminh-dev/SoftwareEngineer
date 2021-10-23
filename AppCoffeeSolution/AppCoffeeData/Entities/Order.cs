using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeeData.Entities
{
    public class Order
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        [ForeignKey("Bill")]
        public int BillID { set; get; }

        [ForeignKey("Drink")]
        public int DrinkID { set; get; }
        public string DrinkName { set; get; }
        public virtual Drink Drink { set; get; }

        [Column(TypeName = "int")]
        public int Quantity { get; set; }

        [Column(TypeName = "float")]
        public float Price { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Status { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string CustomReq { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Note { get; set; }
    }
}
