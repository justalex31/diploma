using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity
{
    [Table("Invest")]
    public class Invest : EntityBase
    {
        [Column("UserId")]
        public Guid UserId { get; set; }

        [Column("ProjectID")]
        public Guid ProjectId { get; set; }

        [Column("Cash")]
        public double Cash { get; set; }

        [Column("CreateAt")]
        public DateTime CreateAt { get; set; }

        public User User { get; set; }

        public Project Project { get; set; }
    }
}
