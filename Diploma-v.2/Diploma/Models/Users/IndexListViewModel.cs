using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Diploma.Models.Users
{
    public class IndexListViewModel
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }

        public static Expression<Func<User, IndexListViewModel>> roleToIndex => x =>
            new IndexListViewModel
            {
                Id = x.Id,
                Username = x.Username,
                Role = x.Role == null ? string.Empty : x.Role.Name
            };
    }
}
