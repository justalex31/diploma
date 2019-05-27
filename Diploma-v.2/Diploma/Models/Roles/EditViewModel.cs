using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Diploma.Models.Roles
{
    public class EditViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public static Expression<Func<Role, EditViewModel>> roleToEdit = x =>
            new EditViewModel
            {
                Id = x.Id,
                Name = x.Name
            };
    }
}
