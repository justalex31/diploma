using Core.Entity;
using DataAccessLayer.Interface.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IExtensionRepository<Project> Project { get; }
        IExtensionRepository<User> User { get; }
        IExtensionRepository<Role> Role { get; } 
        bool SaveChanges();
    }
}
