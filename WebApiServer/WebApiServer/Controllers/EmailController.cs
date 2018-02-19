using System.Collections.Generic;
using System.Web.Http;
using WebApiServer.Abstract;
using WebApiServer.Models.Entities;
using WebApiServer.Repositories;

namespace WebApiServer.Controllers
{
    public class EmailController : ApiController
    {
        private BaseRepository<Email> repository;

        public EmailController()
        {
            repository = new EmailRepository();
        }

        [HttpGet]
        public IEnumerable<Email> GetEmail()
        {
            var res = repository.GetList();
            return res;
        }
    }
}
