using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppCoffeeData.Entities;

namespace AppCoffeApplication.UserModels
{
    public class UserDTOs
    {
        public string Id { get; set; }

        [Column(TypeName= " nvarchar(256)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Tên nhân viên không được bỏ trống")]
        public string FullName { get; set; }

        [Column(TypeName = " nvarchar(max)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public virtual Department Department { set; get; }

        public string DepartmentName { get; set; }

        [Column(TypeName = "DateTime")]
        public System.Nullable<DateTime> BeginWork { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Password { get; set; }
    }
}
