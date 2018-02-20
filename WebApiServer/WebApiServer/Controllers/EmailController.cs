using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiServer.Abstract;
using WebApiServer.Models.Entities;
using WebApiServer.Repositories;

namespace WebApiServer.Controllers
{
    public class EmailController : ApiController
    {
        private BaseRepository<Email> repo;

        public EmailController()
        {
            repo = new EmailRepository();
        } 

        [HttpGet]
        public async Task<IEnumerable<Email>> GetEmail()
        {
            await Task.Delay(500);
            return await repo.GetListAsync();
        }


        [HttpGet]
        [Route("api/email/getsync")]
        public IEnumerable<Email> GetSync()
        {
            Thread.Sleep(500);

            var res = repo.GetList();
            return res;
        }
      
    }
}
