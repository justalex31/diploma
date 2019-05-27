using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccessLayer.Interface
{
    public interface IUnitOfWorkFactory<T>
    {
        IUnitOfWork Create(IsolationLevel isolationLevel);
        IUnitOfWork Create(); // For default isolationLevel = Isolationlevel.ReadCommited
    }
}
