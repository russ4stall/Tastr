using System;
using System.Collections.Generic;
using System.Linq;

namespace Tastr.Data
{
    public class SessionDao : ISessionDao
    {
        private readonly TastrContext _context;

        public SessionDao(TastrContext context)
        {
            _context = context;
        }

        public void Add(Session session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
        }

        public IEnumerable<Session> GetAll()
        {
            return _context.Sessions.ToList();
        }

        public Session Find(int key)
        {
            return _context.Sessions.FirstOrDefault(t => t.Id == key);
            throw new NotImplementedException();
        }

        public void Remove(int key)
        {
            var entity = _context.Sessions.First(t => t.Id == key);
            _context.Sessions.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Session session)
        {
            _context.Sessions.Update(session);
            _context.SaveChanges();
        }
    }
}
