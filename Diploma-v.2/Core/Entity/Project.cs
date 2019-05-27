using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity
{
    [Table("Project")]
    public class Project : EntityBase
    {
        [Column("Title")]
        public string Title { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Status")]
        public Status Status { get; set; }

        [Column("Rate")]
        public decimal Rate { get; set; }

        [Column("CreateAt")]
        public DateTime CreateAt { get; set; }

        [Column("UpdateAt")]
        public DateTime UpdateAt { get; set; }

        [Column("Deleted")]
        public bool Deleted { get; set; }

        [Column("AuthorID")]
        public Guid? AuthorId { get; set; }

        public User Author { get; set; }

        public ICollection<Invest> Invests { get; set; }

        public Project() => Invests = new HashSet<Invest>();
    }
}
