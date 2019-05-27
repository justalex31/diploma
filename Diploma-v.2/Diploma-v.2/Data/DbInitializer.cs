using Core.Entity;
using DataAccessLayer.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma_v._2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            if (context.Projects.Any()) { return; }

            var projects = new Project[]
            {
                new Project
                {
                    Id = Guid.NewGuid(),
                    Title = "Stadia",
                    Description = "Cloud gaming",
                    Status = Core.Enum.Status.Moderated,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Deleted = false
                },
                new Project
                {
                    Id = Guid.NewGuid(),
                    Title = "IPhone 12",
                    Description = "New SmartPhone",
                    Status = Core.Enum.Status.Rejected,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Deleted = false
                }
            };

            context.Projects.AddRange(projects);
            context.SaveChanges();
        }
    }
}
