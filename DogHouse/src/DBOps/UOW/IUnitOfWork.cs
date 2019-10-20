using System;
using System.Threading.Tasks;

namespace DBOps.UOW
{
    public interface IUnitOfWork : IDisposable
    {
         Task<bool> Commit();
    }
}