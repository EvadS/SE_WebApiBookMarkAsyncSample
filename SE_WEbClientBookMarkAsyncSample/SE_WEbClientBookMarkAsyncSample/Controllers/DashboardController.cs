using SE_WEbClientBookMarkAsyncSample.App_Start;
using SE_WEbClientBookMarkAsyncSample.Models.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net;

namespace SE_WEbClientBookMarkAsyncSample.Controllers
{
    public class DashboardController : AsyncController
    {
        // GET: Dashboard
        public async Task<ActionResult> Index()
        {
            Stopwatch timer = Stopwatch.StartNew();
            timer.Start();
            var feeds = await GetFeeds();
            timer.Stop();
            feeds.TimeTaken = timer.ElapsedMilliseconds;
            return View(feeds);
        }

        public ActionResult IndexSync()
        {
            Stopwatch timer = Stopwatch.StartNew();
            timer.Start();
            var feeds = GetFeedsSync();
            timer.Stop();
            feeds.TimeTaken = timer.ElapsedMilliseconds;
            return View(feeds);
        }


        public Dashboard GetFeedsSync()
        {
            string emails = new WebClient().DownloadString(SiteConstant.SERVER_ADRESS + "/Email/getsync");
            string myTasks = new WebClient().DownloadString(SiteConstant.SERVER_ADRESS + "/task/getsync");
            string notes = new WebClient().DownloadString(SiteConstant.SERVER_ADRESS + "/note/getsync");
            string bookmarks = new WebClient().DownloadString(SiteConstant.SERVER_ADRESS + "/bookmark/getsync");

            Dashboard dash = new Dashboard();
            dash.Emails = Deserialize<Email>(emails);
            dash.Bookmarks = Deserialize<Bookmark>(bookmarks);
            dash.Notes = Deserialize<Note>(notes);
            dash.Tasks = Deserialize<MyTask>(myTasks);
            return dash;
        }

        public async Task<Dashboard> GetFeeds()
        {
            string emails = await new HttpClient().GetStringAsync(SiteConstant.SERVER_ADRESS + "/Email");
            string myTasks = await new HttpClient().GetStringAsync(SiteConstant.SERVER_ADRESS + "/Task");
            string notes = await new HttpClient().GetStringAsync(SiteConstant.SERVER_ADRESS + "/Note");
            string bookmarks = await new HttpClient().GetStringAsync(SiteConstant.SERVER_ADRESS + "/Bookmark");

            Dashboard dash = new Dashboard();
            dash.Emails = Deserialize<Email>(emails);
            dash.Bookmarks = Deserialize<Bookmark>(bookmarks);
            dash.Notes = Deserialize<Note>(notes);
            dash.Tasks = Deserialize<MyTask>(myTasks);
            return dash;
        }

        public List<T> Deserialize<T>(string data)
        {
            List<T> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(data);
            return list;
        }
    }
}