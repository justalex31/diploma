using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Diploma.Models.Projects
{
    public class CreateViewModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Rate must be more than 0")]
        public decimal Rate { get; set; }

        public string Username { get; set; }

        public static Expression<Func<CreateViewModel, Project>> createToProject = x =>
            new Project
            {
                Id = Guid.NewGuid(),
                Title = x.Title,
                Description = x.Description,
                Rate = x.Rate,
                Status = Core.Enum.Status.Moderated,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Deleted = false
            };
    }
}
