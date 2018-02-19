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
            // string emails = new WebClient().DownloadString(SiteConstant.SERVER_ADRESS + "/Emails");
            // string myTasks = new WebClient().DownloadString("http://localhost:18545/api/Tasks");
            // string notes = new WebClient().DownloadString("http://localhost:18545/api/Notes");
            var bookMarkUrl = SiteConstant.SERVER_ADRESS + "/Bookmarks";
            string bookmarks = new WebClient().DownloadString("http://localhost:8004/api/Bookmark");

            Dashboard dash = new Dashboard();
            //dash.Emails = Deserialize(emails);
           // dash.Bookmarks = Deserialize(bookmarks);
            //dash.Notes = Deserialize(notes);
            //dash.Tasks = Deserialize(myTasks);

            dash.Bookmarks = Deserialize<Bookmark>(bookmarks);

            return dash;
        }

        public List<T> Deserialize<T>(string data)
        {
            List<T> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(data);
            return list;
        }
    }
}