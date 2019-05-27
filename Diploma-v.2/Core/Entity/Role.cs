using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity
{
    [Table("Role")]
    public class Role : EntityBase
    {
        [Column("Name")]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        public Role() => Users = new HashSet<User>();
    }
}
