using System.Collections.Generic;
using System.Web.Http;
using WebApiServer.Abstract;
using WebApiServer.Models.Entities;
using WebApiServer.Repositories;

namespace WebApiServer.Controllers
{
    public class BookmarkController : ApiController
    {
        private BaseRepository<Bookmark> repository;

        public BookmarkController()
        {
            repository = new BookMarkRepository();
        }

        [HttpGet]
        public IEnumerable<Bookmark> GetBookmarks()
        {
            var res = repository.GetList();
            return res;
        }
    }
}
