using Core.Entity;
using DataAccessLayer.AppData;
using DataAccessLayer.Impl;
using DataAccessLayer.Interface;
using DataAccessLayer.Interface.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region [Attributes]
        protected readonly ApplicationContext context;
        #endregion

        #region [Constructor]
        public UnitOfWork(ApplicationContext context)
        {
            this.context = context;
        }
        #endregion

        #region [Dispose]
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
            {
                
            }

            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true); 
            GC.SuppressFinalize(this);  
        }
        #endregion

        #region [Repository]
        private IExtensionRepository<Project> _projectRepository;

        public IExtensionRepository<Project> Project => _projectRepository ?? (_projectRepository = new ImplExtensionRepository<Project>(context));

        private IExtensionRepository<User> _userRepository;

        public IExtensionRepository<User> User => _userRepository ?? (_userRepository = new ImplExtensionRepository<User>(context));

        private IExtensionRepository<Role> _roleRepository;

        public IExtensionRepository<Role> Role => _roleRepository ?? (_roleRepository = new ImplExtensionRepository<Role>(context));
        #endregion

        #region [Save]
        public bool SaveChanges()
        {
            bool returnValue = true;
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {                      
                    returnValue = false;
                    dbContextTransaction.Rollback();
                }
            }

            return returnValue;
        }
        #endregion
    }
}
