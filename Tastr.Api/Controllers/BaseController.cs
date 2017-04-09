using Tastr.Data;

namespace Tastr.Api.Controllers
{
    public class BaseController
    {
        protected TastrContext Context { get; set; }
        protected TastrContext _context { get; set; }

        public BaseController(TastrContext context)
        {
            this.Context = context;
            this._context = context;
        }
    }
}
