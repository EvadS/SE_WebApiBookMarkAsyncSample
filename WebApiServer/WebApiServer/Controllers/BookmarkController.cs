using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiServer.Abstract;
using WebApiServer.Models.Entities;
using WebApiServer.Repositories;

namespace WebApiServer.Controllers
{
    public class BookmarkController : ApiController
    {
        private BaseRepository<Bookmark> repo;

        public BookmarkController()
        {
            repo = new BookMarkRepository();
        }

        [HttpGet]
        public async Task<IEnumerable<Bookmark>> GetBookmark()
        {
            await Task.Delay(500);
            return await repo.GetListAsync();
        }


        [HttpGet]
        [Route("api/bookmark/getsync")]
        public IEnumerable<Bookmark> GetSync()
        {
            Thread.Sleep(500);
            var res = repo.GetList();
            return res;
        }

        // GET api/Bookmarks/5
        public Bookmark GetBookmark(int id)
        {
           var item =  repo.GetItem(id);

            if (item == null)            
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            

            return item;
        }

        public HttpResponseMessage PostBookmark(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                repo.Create(bookmark);
                repo.Save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, bookmark);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = bookmark.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // PUT api/Bookmarks/5
        public HttpResponseMessage PutBookmark(Int32 id, Bookmark bookmark)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != bookmark.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

          

            try
            {
                repo.Update(bookmark);
                repo.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/Bookmarks/5
        public HttpResponseMessage DeleteBookmark(Int32 id)
        {
            Bookmark bookmark = repo.GetItem(id);
            if (bookmark == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            repo.Delete(id);

            try
            {
                repo.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, bookmark);
        }

        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
