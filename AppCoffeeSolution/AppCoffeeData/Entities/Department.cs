using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeeData.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        /*[ForeignKey("DepartmentID")]
        public ICollection<ApplicationUser> Users { get; set; }*/
    }
}
