using SE_WEbClientBookMarkAsyncSample.App_Start;
using SE_WEbClientBookMarkAsyncSample.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SE_WEbClientBookMarkAsyncSample.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            Stopwatch timer = Stopwatch.StartNew();
            timer.Start();
            var feeds = GetFeeds();
            timer.Stop();
            feeds.TimeTaken = timer.ElapsedMilliseconds;
            return View(feeds);
        }

        public Dashboard GetFeeds()
        {
            string emails = new WebClient().DownloadString(SiteConstant.SERVER_ADRESS + "/Email");
            string myTasks = new WebClient().DownloadString(SiteConstant.SERVER_ADRESS + "/Task");
            string notes = new WebClient().DownloadString(SiteConstant.SERVER_ADRESS + "/Note");
            string bookmarks = new WebClient().DownloadString(SiteConstant.SERVER_ADRESS + "/Bookmark");

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