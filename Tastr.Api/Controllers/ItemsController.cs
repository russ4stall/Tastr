using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tastr.Data;

namespace Tastr.Api.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private IItemDao _itemDao;
        public ItemsController(IItemDao itemDao) {
            _itemDao = itemDao;
        }

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            var items = _itemDao.GetAll();            
            return items ;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _itemDao.Find(id);
            if (item == null) {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Item item)
        {
            _itemDao.Add(item);
            return new CreatedResult($"/api/items/{item.Id}", item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Item item)
        {
            var toUpdate = _itemDao.Find(id);
            if (toUpdate == null) {
                _itemDao.Add(item);
                return new CreatedResult($"/api/items/{item.Id}", item);
            }

            toUpdate.Name = item.Name;
            toUpdate.Description = item.Description;

            _itemDao.Update(toUpdate);
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _itemDao.Remove(id);
            return new NoContentResult();
        }
    }
}
