using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [DefaultValue(Role.User)]
        public Role Roles { get; set; }
    }
}