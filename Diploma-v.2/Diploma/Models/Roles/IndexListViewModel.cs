using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Diploma.Models.Roles
{
    public class IndexListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<Role, IndexListViewModel>> roleToIndex = x =>
            new IndexListViewModel
            {
                Id = x.Id,
                Name = x.Name
            };
    }
}
