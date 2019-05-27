using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Diploma.Models.Roles
{
    public class CreateViewModel
    {
        [Required]
        public string Name { get; set; }

        public static Expression<Func<CreateViewModel, Role>> createToRole = x =>
            new Role
            {
                Id = Guid.NewGuid(),
                Name = x.Name
            };
    }
}
