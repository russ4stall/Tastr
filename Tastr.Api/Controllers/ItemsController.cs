using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tastr.Data;

namespace Tastr.Api.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : BaseController
    {
        public ItemsController(TastrContext context) : base(context) {}

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            var items = Context.Items;    
            return items ;
        }

        [HttpGet("{id}")]
        public Item Get(int id)
        {
            var item = Context.Items.FirstOrDefault(i => i.Id == id);    
            return item ;
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
