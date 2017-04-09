using System;
using System.Linq;
using System.Linq.Expressions;

namespace Tastr.Data
{
    public class ItemDao : IItemDao
    {
        private readonly TastrContext _context;

        public ItemDao(TastrContext context)
        {
            _context = context;
        }
        public Item Add(Item entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
             return entity;
        }

        public Item Find(int id)
        {
            return _context.Items.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Item> FindBy(Expression<Func<Item, bool>> predicate)
        {
            IQueryable<Item> query = _context.Set<Item>().Where(predicate);
            return query;
        }

        public IQueryable<Item> GetAll()
        {
            return _context.Items;
        }

        public void Remove(int id)
        {
            var entity = _context.Items.First(t => t.Id == id);
            _context.Items.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Item entity)
        {
            throw new NotImplementedException();
        }
    }

}