using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tastr.Data;

namespace Tastr.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        public UsersController(TastrContext context) : base(context) { }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = Context.Users;
            return users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = Context.Users
                                .Include(x => x.Sessions)
                                    .ThenInclude(s => s.SessionItems)
                                        .ThenInclude(s => s.Item)
                                .FirstOrDefault(u => u.Id == id);
            return user;
        }

        [HttpPost]
        public User Post([FromBody]User user)
        {
            Context.Users.Add(user);

            Context.SaveChanges();

            return user;
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
