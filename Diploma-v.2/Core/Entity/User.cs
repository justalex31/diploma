using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity
{
    [Table("User")]
    public class User : EntityBase
    {
        [Column("Username")]
        public string Username { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("RoleId")]
        public Guid? RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<Invest> Invests { get; set; }

        public User()
        {
            Projects = new HashSet<Project>();
            Invests = new HashSet<Invest>();
        }
    }
}
