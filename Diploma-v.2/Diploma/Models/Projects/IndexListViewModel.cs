using Core.Entity;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Diploma.Models.Projects
{
    public class IndexListViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Status Status { get; set; }

        public decimal Rate { get; set; }

        public DateTime UpdateAt { get; set; }

        public bool Deleted { get; set; }

        public string Username { get; set; }

        public Expression<Func<Project, IndexListViewModel>> expression = x =>
         new IndexListViewModel
         {
             Id = x.Id,
             Title = x.Title,
             Status = x.Status,
             UpdateAt = x.UpdateAt
         };
    }
}
