using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tastr.Data;

namespace Tastr.Api.Controllers
{
    [Route("api/sessions/{sId:int}/items")]
    public class SessionItemsController : Controller
    {
        ISessionDao _sessionDao;
        public SessionItemsController(ISessionDao sessionDao)
        {
            this._sessionDao = sessionDao;
        }

        [HttpGet]
        public IEnumerable<Item> Get(int sId)
        {
            var items = _sessionDao.GetSessionItems(sId);

            return items;
        }

        [HttpPost]
        public ActionResult Post(int sId, int itemId)
        {
            return null;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int sId, int itemId)
        {
            _sessionDao.Remove(itemId);
            return new NoContentResult();
        }
    }
}
