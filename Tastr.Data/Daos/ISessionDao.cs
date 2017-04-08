using System.Collections.Generic;

namespace Tastr.Data 
{
    public interface ISessionDao
    {
        void Add(Session session);
        IEnumerable<Session> GetAll();
        Session Find(int id);
        void Remove(int id);
        void Update(Session session);
    }
}