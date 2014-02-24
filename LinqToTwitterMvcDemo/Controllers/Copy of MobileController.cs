using System;
using LinqToTwitter;
using LinqToTwitterMvcDemo.Models;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using System.Security;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Utilities;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Samples.Helper;
using Google.Apis.Tasks.v1;
using Google.Apis.Tasks.v1.Data;
using Google.Apis.Calendar;
using Google.Apis.Calendar.v3;
using Google.Apis.Util;


namespace LinqToTwitterMvcDemo.Controllers
{
    public class CopyMobileController : Controller
    {
        private IOAuthCredentials credentials = new SessionStateCredentials();

        private MvcAuthorizer auth;
        private TwitterContext twitterCtx;

        public ActionResult AuthTwitter()
        //enter twitter username and message for restful api
        {

            try
            {
                string tname = Request.Cookies["TwitterID"].Value;
                string accesstoken = Request.Cookies["oauth_accessToken"].Value;
                string oauthtoken = Request.Cookies["oauth_oauthToken"].Value;

                return RedirectToAction("Choose");

            }
            catch
            {
                return RedirectToAction("SetTwitterID");
            }
        }

        public ActionResult SetTwitterID()
        {
            credentials.ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"];
            credentials.ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"];
            //credentials.AccessToken = "v3g3lcENHnDPNNYTpSLLZZtZmCJ43bnvohLlDnNg7w";
            //credentials.OAuthToken = "1317302059-F57J7rhJw18BYymjoZ5nJGqwhKd0nqax3jaItN5";

            auth = new MvcAuthorizer
            {
                Credentials = credentials
            };

            auth.CompleteAuthorization(Request.Url);

            if (!auth.IsAuthorized)
            {
                Uri specialUri = new Uri(Request.Url.ToString());
                return auth.BeginAuthorization(specialUri);
            }

            var accesstoken = credentials.AccessToken;
            var oauthtoken = credentials.OAuthToken;
            var twitterID = credentials.ScreenName;

            //SetCookie("oauth_accessToken", accesstoken);
            //SetCookie("oauth_oauthToken", oauthtoken);
            //SetCookie("TwitterID", twitterID);

            return RedirectToAction("AuthTwitter");


        }

      

        public ActionResult JsonTweets()
        {
            string tname = Request.Cookies["TwitterID"].Value;
            string accesstoken = Request.Cookies["oauth_accessToken"].Value;
            string oauthtoken = Request.Cookies["oauth_oauthToken"].Value;
            var msg = "hardcoded test " + DateTime.Now;
            credentials.ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"];
            credentials.ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"];
            credentials.AccessToken = accesstoken;
            credentials.OAuthToken = oauthtoken;
  
            if (credentials.ConsumerKey == null || credentials.ConsumerSecret == null)
            {
                credentials.ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"];
                credentials.ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"];
            }

            auth = new MvcAuthorizer
            {
                Credentials = credentials
            };

            auth.CompleteAuthorization(Request.Url);

            if (!auth.IsAuthorized)
            {
                Uri specialUri = new Uri(Request.Url.ToString());
                return auth.BeginAuthorization(specialUri);
            }
            //("oauth_accessToken", credentials.AccessToken);
            //SetCookie("oauth_oauthToken", credentials.OAuthToken);
            twitterCtx = new TwitterContext(auth);

            var friendTweets =
                (from tweet in twitterCtx.Status
                 where tweet.Type == StatusType.User
                 // && tweet.SinceID == 397389362088132608
                 select new TweetViewModel
                 {
                     //ImageUrl = tweet.Entities.,
                     // ScreenName = tweet.StatusID,
                     //TimeStamp = formatTimeStamp(tweet.CreatedAt.ToUniversalTime()),
                     //Convert.ToString(tweet.CreatedAt.ToUniversalTime()),
                     Tweet = tweet.Text,
                     //BannerText = GetBannerText(tweet),
                     ID = tweet.StatusID,
                     //SinceID = tweet.SinceID,
                     //Convert.ToString(tweet.Entities.MediaEntities.Count),
                     //MediaUrl = GetTweetMediaUrl(tweet)
                 });

            var banners =
                (from tweet in twitterCtx.Status
                 where tweet.Type == StatusType.User
                && tweet.Text.Contains("#banner")
                 select new TweetViewModel
                 {
                     //BannerText = GetBannerText(tweet),
                     //BannerTime = GetBannerTime(tweet),
                 });

            //.Take(9).ToList();


            string status = "hihi " + DateTime.Now;
            // var tweetnew = twitterCtx.UpdateStatus(status);
            //var dtweet = twitterCtx.NewDirectMessage(tname,msg);
            var oauthToken = auth.Credentials.OAuthToken;
            var oauthAccessT = auth.Credentials.AccessToken;
            var userd = auth.Credentials.ScreenName + " " + auth.Credentials.UserId;
            //http://localhost:5010/?oauth_token=9IWia8yWenYytqosbErCRno7KcJPr55fMXHvqJkoY&oauth_verifier=g6pbTya6OOcsH2O0f3PuzQKUtCQBz1lQBz0BmnixHU
            ViewData["authdeets"] = oauthAccessT;
            //Auth: oauthtoken=1317302059-F57J7rhJw18BYymjoZ5nJGqwhKd0nqax3jaItN5 id=FletcherFridge 1317302059 oathaccesstoken= v3g3lcENHnDPNNYTpSLLZZtZmCJ43bnvohLlDnNg7w
            //+ save id first time.
            // var jsonresults = JsonConvert.SerializeObject(friendTweets);
            var latestid = friendTweets.First().ID;
            var latesttime = friendTweets.First().TimeStamp;
            //var topBanner = GetBannerText(friendTweets.First())
            var doBanner = "false";
            var BannerID = "";

            if (friendTweets.First().BannerText.Length > 1)
            {
                doBanner = "true";
                BannerID = friendTweets.First().ID;
            }
            return Json(new { results = friendTweets.Take(6), banners = banners, latestid = latestid, doBanner = doBanner, BannerID = BannerID, twitterID = tname }, JsonRequestBehavior.AllowGet);
            //return Json("Index", friendTweets);

        }

        //
        // GET: /Mobile/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Mobile/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Mobile/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Mobile/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Mobile/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Mobile/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Mobile/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Mobile/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
