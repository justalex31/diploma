using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Diploma.Models.Users
{
    public class CreateViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        public static Expression<Func<CreateViewModel, User>> createToUser = x =>
            new User
            {
                Id = Guid.NewGuid(),
                Username = x.Username,
                Password = x.Password,
                RoleId = x.RoleId
            };
    }
}
