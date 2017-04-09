using System.Collections.Generic;

namespace Tastr.Data 
{
    public interface ISessionDao : IGenericRepository<Session>
    {
        IEnumerable<Item> GetSessionItems(int sessionId);
    }
}