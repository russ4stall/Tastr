using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tastr.Data;

namespace Tastr.Api.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            var items = new List<Item>();
            items.Add(new Item() 
            {
                Id = 1,
                Name = "Jack Daniels",
                Description = "Tennessee Bourbon. Whiskey made..."
            });

            return items ;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
