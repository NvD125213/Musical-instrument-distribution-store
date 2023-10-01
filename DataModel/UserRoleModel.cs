using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataModel
{
    [Table("UserRole")]
    public class UserRoleModel
    {
        [ForeignKey("User")]
        public int UserId { get; set; } 
        [ForeignKey("Role")]
        public int RoleId { get; set; }

    }
}
