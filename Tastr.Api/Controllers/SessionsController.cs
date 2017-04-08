using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tastr.Data;

namespace Tastr.Api.Controllers
{
    [Route("api/[controller]")]
    public class SessionsController : Controller
    {
        ISessionDao _sessionDao;
        public SessionsController(ISessionDao sessionDao) {
            this._sessionDao = sessionDao;
         }

        [HttpGet]
        public IEnumerable<Session> Get()
        {
            var sessions = _sessionDao.GetAll();
            return sessions;
        }

        [HttpGet("{id}")]
        public Session Get(int id)
        {
            var session = _sessionDao.Find(id);
            return session;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Session session)
        {
            _sessionDao.Add(session);
            return new CreatedResult($"/api/sessions/{session.Id}", session);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Session session)
        {

            var toUpdate = _sessionDao.Find(id);
            if (toUpdate == null) {
                _sessionDao.Add(session);
                return new CreatedResult($"/api/sessions/{session.Id}", session);
            }

            toUpdate.DateTime = session.DateTime;
            toUpdate.Title = session.Title;
            toUpdate.Description = session.Description;
            toUpdate.Location = session.Location;

            _sessionDao.Update(toUpdate);
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _sessionDao.Remove(id);        
            return new NoContentResult();
        }
    }
}
