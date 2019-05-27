using Core.Entity;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Diploma.Models.Projects
{
    public class EditViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Rate must be more than 0")]
        public decimal Rate { get; set; }

        [Required]
        public Status Status { get; set; }
        
        public string Username { get; set; }

        public static Expression<Func<Project, EditViewModel>> expression = x =>
         new EditViewModel
         {
             Id = x.Id,
             Title = x.Title,
             Description = x.Description,
             Status = x.Status,
             Rate = x.Rate,
             Username = x.Author.Username
         };
    }
}
