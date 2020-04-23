using System.Threading.Tasks;

namespace NerdStore.Core.Interfaces
{
    public interface IUnitOfWork
    {
         Task<bool> Commit();
    }
}