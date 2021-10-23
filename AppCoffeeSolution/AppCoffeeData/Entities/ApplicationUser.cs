using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeeData.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        [Column(TypeName = "DateTime")]

        public System.Nullable<DateTime> BeginWork { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Password { get; set; }
    }
}
