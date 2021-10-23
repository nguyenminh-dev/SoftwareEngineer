using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeeData.Entities
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Table")]
        public int TableId { get; set; }
        public virtual Table Table { set; get; }
        public string TableName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual IList<Order> OrderList { get; set; }
        [Column(TypeName = "datetime")]
        public System.Nullable <DateTime> DateCheckIn { get; set; }
        [Column(TypeName = "datetime")]
        public System.Nullable<DateTime> DateCheckOut { get; set; }
        [Column(TypeName = "float")]
        public float TotalPrice { get; set; }
    }
}
