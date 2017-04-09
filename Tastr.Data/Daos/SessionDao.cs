using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Tastr.Data
{
    public class SessionDao : ISessionDao
    {
        private readonly TastrContext _context;

        public SessionDao(TastrContext context)
        {
            _context = context;
        }

        public Session Add(Session session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return session;
        }

        public IQueryable<Session> FindBy(Expression<Func<Session, bool>> predicate)
        {
            IQueryable<Session> query = _context.Set<Session>().Where(predicate);
            return query;
        }

        public IQueryable<Session> GetAll()
        {
            return _context.Sessions;
        }

        public Session Find(int id)
        {
            return _context.Sessions.FirstOrDefault(t => t.Id == id);
        }

        public void Remove(int id)
        {
            var entity = _context.Sessions.First(t => t.Id == id);
            _context.Sessions.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Session session)
        {
            _context.Sessions.Update(session);
            _context.SaveChanges();
        }

        public IEnumerable<Item> GetSessionItems(int sessionId)
        {
            var session = _context.Sessions
                                    .Include(x => x.SessionItems)
                                        .ThenInclude(x => x.Item)
                                        .FirstOrDefault(x => x.Id == sessionId);

            var items = session.SessionItems.Select(x => x.Item);
            return items;
        }
    }
}
