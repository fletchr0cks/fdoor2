﻿using System;
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


//FletcherFridge texts DMs from anyone. in this case fletchtweet
namespace LinqToTwitterMvcDemo.Controllers
{

    public class MobileController : Controller
    {
        DataRepository dataRepository = new DataRepository();
        private fddbDataContext db = new fddbDataContext();
        private IOAuthCredentials credentials = new SessionStateCredentials();

        private MvcAuthorizer auth;
        private TwitterContext twitterCtx;

        private const string clientId = "651937086252-na99drkmmna0k5purb5h27mnfifvc2tr.apps.googleusercontent.com";
        private const string secret = "l16kKa9wSc6E0oJzeyzRS5Ne";

        public ActionResult Index(string zcguid)
        {
            if (zcguid == null) //id parameter is set ?
            {

                try
                {
                    string guid_str = Request.Cookies["GUID"].Value;
                    Guid guid = new Guid(guid_str);
                    var userid = dataRepository.getID(guid);
                    string tname = dataRepository.getT_twtid(dataRepository.getID(guid));
                    if (tname == null)
                    {
                        ViewData["twitter"] = "<a href=\"#\" onclick=\"Auth(1,'Twitter')\" class=\"ui-btn ui-btn-b ui-corner-all\">Authenticate</a><div>Allows Fridge Door to read your tweets.</div>";
                    }
                    else
                    {
                        ViewData["twitter"] = "<a href=\"#\" onclick=\"Auth(0,'Twitter')\" class=\"ui-btn ui-btn-b ui-corner-all\">Uauthenticate</a><div>Twitter authenticated for <strong>" + tname + ".</strong></div>";
                        //"<div class=\"button-wrap\"><button onclick=\"Auth(0,'Twitter')\" class=\"ui-shadow ui-btn ui-corner-all\">Unauthenticate</button></div>";
                        //<div>Twitter authenticated for <strong>" + tname + "</strong></div>";
                        //"<div class=\"button-wrap\"><button class=\"ui-shadow ui-btn ui-corner-all\">Button</button></div>";
                        //
                    }
                }
                catch
                {
                    ViewData["twitter"] = "<a href=\"#\" onclick=\"Auth(1,'Twitter')\" class=\"ui-btn ui-btn-b ui-corner-all\">Authenticate</a><div>Allows Fridge Door to read your tweets.</div>";
                }


                try
                {
                    string guid_str = Request.Cookies["GUID"].Value;
                    Guid guid = new Guid(guid_str);
                    string JsonIDs = dataRepository.getG_idlist(dataRepository.getID(guid));
                    JObject o = JObject.Parse(JsonIDs);
                    // JArray items = (JArray)o["items"];
                    var names = Convert.ToString(o["Fullname"]);
                    var userid = dataRepository.getID(guid);
                    var count = Convert.ToString(o["Count"]);
                    int idcount = Convert.ToInt32(count);
                    //string name = (string)o["kind"];
                    var ids = names.Replace("[", "").Replace("]", "").Replace("\"", "");

                    ViewData["google"] = "<a href=\"#\" onclick=\"Auth(0,'Google')\" class=\"ui-btn ui-btn-b ui-corner-all\">Unauthenticate</button></a><div>Google calendar authenticated for <strong>" + ids + ".</strong></div>";
                }
                catch
                {
                    ViewData["google"] = "<a href=\"#\" onclick=\"Auth(1,'Google')\" class=\"ui-btn ui-btn-b ui-corner-all\">Authenticate</a><div>Allows Fridge Door to read your Google calendar.</div>";
                    //<button onclick=\"Auth(1,'Google')\" class=\"ui-btn ui-btn-b ui-corner-all\">Authenticate</button><div>Allows Fridge Door to read your Google calendar</div>";
                }

                try
                {
                    string guid_str = Request.Cookies["GUID"].Value;
                    Guid guid = new Guid(guid_str);
                    var userid = dataRepository.getID(guid);
                    var loc = dataRepository.getLocation(userid);
                    var latlng = dataRepository.getLatLng(userid);
                    if (loc != null)
                    {
                        ViewData["location"] = "<a href=\"#\" onclick=\"ChangeLoc()\" class=\"ui-btn ui-btn-b ui-corner-all\">Change</a><div>Location set to: " + loc + " (" + latlng + ")</div>";
                    }
                    else
                    {
                        //ViewData["location"] = "<button onclick=\"SetLoc()\" class=\"ui-btn ui-btn-b ui-btn-inline\">Set Location</button></div>Daily weather from Accuweather</div>"; 
                        ViewData["location"] = "<a href=\"#\" onclick=\"SetLoc()\" class=\"ui-btn ui-btn-b ui-corner-all\">Set Location</a><div>Daily weather from Accuweather</div>";
                    }
                }
                catch
                {
                    ViewData["location"] = "<a href=\"#\" onclick=\"SetLoc()\" class=\"ui-btn ui-btn-b ui-corner-all\">Set Location</a><div>Daily weather from Accuweather</div>";
                }

                return View();
            }
                else {

                Guid guidnew = new Guid(zcguid);

                if (dataRepository.checkGUIDzc(guidnew) == 1)
                {
                    var guidCookie = new HttpCookie("GUID", zcguid.ToString());
                    guidCookie.Expires = DateTime.Now.AddYears(1);
                    Response.AppendCookie(guidCookie);
                    try
                    {
                        string JsonIDs = dataRepository.getG_idlist(dataRepository.getID(guidnew));
                        var IDCookie = new HttpCookie("IDList", JsonIDs);
                        IDCookie.Expires = DateTime.Now.AddYears(1);
                        Response.AppendCookie(IDCookie);

                        var GrantCookie = new HttpCookie("Granted", "True");
                        GrantCookie.Expires = DateTime.Now.AddYears(1);
                        Response.AppendCookie(GrantCookie);
                        int userid = dataRepository.getID(guidnew);
                        var token = dataRepository.getG_refreshtoken(userid);
                        //saveG_refresh(tokenData.Refresh_Token);

                        Session["GoogleAPIToken"] = token;
                        var lat = dataRepository.getLat(userid);
                        var lng = dataRepository.getLng(userid);
                        SetCookie("lat", lat);
                        SetCookie("long", lng);

                        //get from db lat lng and set cookies

                    }
                    catch
                    {

                    }
                    RedirectToAction("Index");
                }

               }
                return View();
//            }   
        }

        public ActionResult Index_o()
        {
            // By default, we display all the events from the last 10 days
            return ListEvents(DateTime.Now.Subtract(TimeSpan.FromDays(10)), DateTime.Now.AddHours(22 - DateTime.Now.Hour));
        }

        public ActionResult ListEvents(DateTime startDate, DateTime endDate)
        {


            var authenticator = GetAuthenticator();

            var service = new GoogleCalendarServiceProxy(authenticator);
            var model = service.GetEvents("nick.fletcher@gmail.com");

            return View("Index", model);
        }

        private GoogleAuthenticator GetAuthenticator()
        {
            var authenticator = (GoogleAuthenticator)Session["authenticator"];

            if (authenticator == null || !authenticator.IsValid)
            {
                // Get a new Authenticator using the Refresh Token
                var refreshToken = "4/3o0Kk1v-TGrT3yFsvR4dh7eJUS1h.ssuJV7KhxAkQOl05ti8ZT3YF-9safAI";
                authenticator = GoogleAuthorizationHelper.RefreshAuthenticator(refreshToken);
                Session["authenticator"] = authenticator;
            }

            return authenticator;
        }

        private static string _GoogleClientId = "651937086252-na99drkmmna0k5purb5h27mnfifvc2tr.apps.googleusercontent.com";
        private static string _GoogleSecret = "l16kKa9wSc6E0oJzeyzRS5Ne";
        private static string _ReturnUrl_local = "http://localhost:5010/Mobile/CallBack";
        private static string _ReturnUrl = "http://FridgeDoor.apphb.com/Mobile/CallBack";

        public ActionResult checkGglIDlist()
        {
            try
            {
                string guid_str = Request.Cookies["GUID"].Value;
                Guid guid = new Guid(guid_str);
                string JsonIDs = dataRepository.getG_idlist(dataRepository.getID(guid));
                return Json(new { IDlist = JsonIDs }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { IDlist = "No IDList" }, JsonRequestBehavior.AllowGet); ;
            }
        }

        public ActionResult checkTwtID()
        {
            try
            {
                string guid_str = Request.Cookies["GUID"].Value;
                Guid guid = new Guid(guid_str);

                string JsonIDs = dataRepository.getT_twtid(dataRepository.getID(guid));

                if (JsonIDs == null)
                {
                    return Json(new { ID = "No Twitter" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { ID = JsonIDs }, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new { ID = "No GUID" }, JsonRequestBehavior.AllowGet); ;
            }
        }

        public ActionResult Choose()
        {
           
            try
            {
                string guid_str = Request.Cookies["GUID"].Value;
                Guid guid = new Guid(guid_str);
                var userid = dataRepository.getID(guid);
                string tname = dataRepository.getT_twtid(dataRepository.getID(guid));
                if (tname == null)
                {
                    ViewData["twitter"] = "<div class=\"term3\" style=\"cursor:pointer\" onclick=\"Auth(1,'Twitter')\">Click to Authenticate</div>";
                    //ViewData["twdata"] = "Not auth ... Guid: " + guid + " ID: " + userid;
                }
                else
                {
                    ViewData["twitter"] = "<div class=\"term3\" style=\"cursor:pointer\" onclick=\"Auth(0,'Twitter')\">Using " + tname + ", click to Disable</div>";
                    //ViewData["twdata"] = "Guid: " + guid + " ID: " + userid;
                }
            }
            catch
            {
                ViewData["twitter"] = "<div class=\"term3\" style=\"cursor:pointer\" onclick=\"Auth(1,'Twitter')\">Click to Authenticate</div>";
            }


            try
            {
                //string idlist = Request.Cookies["IDList"].Value;
                string guid_str = Request.Cookies["GUID"].Value;
                Guid guid = new Guid(guid_str);
                string JsonIDs = dataRepository.getG_idlist(dataRepository.getID(guid));
                JObject o = JObject.Parse(JsonIDs);
                JArray items = (JArray)o["items"];
                var names = Convert.ToString(o["Fullname"]);
                var userid = dataRepository.getID(guid);
                ViewData["google"] = "<div class=\"term3\" style=\"cursor:pointer\" onclick=\"Auth(0,'Google')\">Using " + names + ", click to Disable</div>";
                //ViewData["godata"] = "Guid: " + guid + " ID: " + userid;
            }
            catch
            {
                ViewData["google"] = "<div class=\"term3\" style=\"cursor:pointer\" onclick=\"Auth(1,'Google')\">Click to Authenticate</div>";
            }

            

            return View();
        }

        public ActionResult ChooseT()
        {
            //
            return View();
        }

        public ActionResult AuthGoogle()
        {

            var token = Session["GoogleAPIToken"];

            if (Convert.ToString(token).Length < 2)
            {
                //session expired or new
                //try cookie
                try
                {
                    //have refresh token, get new access token
                    //do GUID cookie check
                    var granted = Request.Cookies["Granted"].Value;
                    if (granted == "True")
                    {
                        return Redirect("/Mobile/GoogleRefresh");
                    }
                    else
                    {
                        return Redirect(GenerateGoogleOAuthUrl());
                    }
                }
                catch
                {
                    return Redirect(GenerateGoogleOAuthUrl());
                }
                //return Redirect(GenerateGoogleRefreshUrl());

            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult refresh()
        {
            return Redirect(GenerateGoogleRefreshUrl());
        }

        private string GenerateGoogleRefreshUrl()
        {

            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            string refresh_token = dataRepository.getG_refreshtoken(dataRepository.getID(guid));
            string Url = "https://accounts.google.com/o/oauth2/token";
            string grant_type = "refresh_token";

            var request_url = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Contains("~"));
            string urlBase = Request.Url.ToString();
            Uri myUri = new Uri(Request.Url.ToString());
            string redirect_uri_encode;
            if (request_url.Contains("localhost"))
            {
                redirect_uri_encode = UrlEncodeForGoogle(_ReturnUrl_local);
            }

            else
            {
                redirect_uri_encode = UrlEncodeForGoogle(_ReturnUrl);
            }

            string data = "client_id={0}&client_secret={1}&refresh_token={2}&grant_type={3}";
            var urlstr = string.Format(Url, data, _GoogleClientId, _GoogleSecret, refresh_token, grant_type);
            return string.Format(Url, data, _GoogleClientId, _GoogleSecret, refresh_token, grant_type);
        }

        private string GenerateGoogleOAuthUrl()
        {

            //NOTE: Key piece here, from Andrew's reply -> access_type=offline forces a refresh token to be issued
            string Url = "https://accounts.google.com/o/oauth2/auth?scope={0}&redirect_uri={1}&response_type={2}&client_id={3}&state={4}&access_type=offline&approval_prompt=force";
            string scope = UrlEncodeForGoogle("https://www.googleapis.com/auth/calendar https://www.googleapis.com/auth/calendar.readonly").Replace("%20", "+");
            var request = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Contains("~"));
            string urlBase = Request.Url.ToString();
            Uri myUri = new Uri(Request.Url.ToString());
            string redirect_uri_encode;
            if (request.Contains("localhost"))
            {
                redirect_uri_encode = UrlEncodeForGoogle(_ReturnUrl_local);
            }

            else
            {
                redirect_uri_encode = UrlEncodeForGoogle(_ReturnUrl);
            }
            string response_type = "code";
            string state = "";

            return string.Format(Url, scope, redirect_uri_encode, response_type, _GoogleClientId, state);

        }

        private static string UrlEncodeForGoogle(string url)
        {
            string UnReservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
            var result = new StringBuilder();

            foreach (char symbol in url)
            {
                if (UnReservedChars.IndexOf(symbol) != -1)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.Append('%' + String.Format("{0:X2}", (int)symbol));
                }
            }

            return result.ToString();
        }

        class GoogleTokenData
        {
            public string Access_Token { get; set; }
            public string Refresh_Token { get; set; }
            public string Expires_In { get; set; }
            public string Token_Type { get; set; }
        }



        public ActionResult CallBack(string code, bool? remove)
        {

           
            if (string.IsNullOrEmpty(code)) return Content("Missing code");

            string Url = "https://accounts.google.com/o/oauth2/token";
            string grant_type = "authorization_code";
            var request_url = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Contains("~"));
            string urlBase = Request.Url.ToString();
            Uri myUri = new Uri(Request.Url.ToString());
            string redirect_uri_encode;
            if (request_url.Contains("localhost"))
            {
                redirect_uri_encode = UrlEncodeForGoogle(_ReturnUrl_local);
            }

            else
            {
                redirect_uri_encode = UrlEncodeForGoogle(_ReturnUrl);
            }
            string data = "code={0}&client_id={1}&client_secret={2}&redirect_uri={3}&grant_type={4}";

            HttpWebRequest request = HttpWebRequest.Create(Url) as HttpWebRequest;
            string result = null;
            request.Method = "POST";
            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";
            string param = string.Format(data, code, _GoogleClientId, _GoogleSecret, redirect_uri_encode, grant_type);
            var bs = Encoding.UTF8.GetBytes(param);
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }

            using (WebResponse response = request.GetResponse())
            {
                var sr = new StreamReader(response.GetResponseStream());
                result = sr.ReadToEnd();
                sr.Close();
            }

            var jsonSerializer = new JavaScriptSerializer();
            var tokenData = jsonSerializer.Deserialize<GoogleTokenData>(result);
            var GrantCookie = new HttpCookie("Granted", "True");
            //var refreshCookie = new HttpCookie("RefreshToken", tokenData.Refresh_Token);
            saveG_refresh(tokenData.Refresh_Token);
            GrantCookie.Expires = DateTime.Now.AddYears(1);
            Response.AppendCookie(GrantCookie);

            //refreshCookie.Expires = DateTime.Now.AddYears(1);
            //Response.AppendCookie(refreshCookie);

            Session["GoogleAPIToken"] = tokenData.Access_Token;
            //dataRepository.saveGoogleAPIToken(tokenData.Access_Token);
            var accessToken = tokenData.Access_Token;
            var urlBuilder = new System.Text.StringBuilder();

            urlBuilder.Append("https://");
            urlBuilder.Append("www.googleapis.com");
            urlBuilder.Append("/calendar/v3/users/me/calendarList");
            urlBuilder.Append("?minAccessRole=writer");
            // urlBuilder.Append("&access_token=4/ZsN6Wn19QrcPbk6WarRGEIXSHaKO.QubFbrJ1OpsSOl05ti8ZT3ZDPtonfAI");

            //https://www.googleapis.com/calendar/v3/users/me/calendarList?minAccessRole=writer&access_token=4/ZsN6Wn19QrcPbk6WarRGEIXSHaKO.QubFbrJ1OpsSOl05ti8ZT3ZDPtonfAI

            var httpWebRequest = HttpWebRequest.Create(urlBuilder.ToString())
                as HttpWebRequest;
            //httpWebRequest.ContentType = "application/json ; charset=UTF-8";
            httpWebRequest.CookieContainer = new CookieContainer();
            httpWebRequest.Headers["Authorization"] = string.Format("Bearer {0}", accessToken);

            var responsec = httpWebRequest.GetResponse();

            string textout = responsec.ReadReponse();

            var jsonS = new JavaScriptSerializer();
            var textout2 = jsonS.DeserializeObject(textout);

            System.Collections.Generic.List<string> ID_array = new System.Collections.Generic.List<string>();
            System.Collections.Generic.List<string> Fn_array = new System.Collections.Generic.List<string>();


            var idlist = "";
            JObject o = JObject.Parse(textout);
            JArray items = (JArray)o["items"];
            string count = (string)items.Count.ToString();
            int idcount = Convert.ToInt32(count);
            string name = (string)o["kind"];
            if (idcount == 1)
            {
                ID_array.Add((string)items[0]["id"]);
                Fn_array.Add((string)items[0]["summary"]);
            }
            else
            {
                idcount = idcount - 1;
                while (idcount > -1)
                {
                    ID_array.Add((string)items[idcount]["id"]);
                    Fn_array.Add((string)items[idcount]["summary"]);
                    idcount--;
                }
            }
            //idlist = idlist + (string)items[0]["id"];

            CalIDs calids = new CalIDs();
            calids.Count = count;
            calids.Id = ID_array.ToArray();
            calids.Fullname = Fn_array.ToArray();

            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            int userid = dataRepository.getID(guid);

            string jsonIDs = JsonConvert.SerializeObject(calids);
            var IDCookie = new HttpCookie("IDList", jsonIDs);
            IDCookie.Expires = DateTime.Now.AddYears(1);
            Response.AppendCookie(IDCookie);

            dataRepository.saveG_idlist(jsonIDs, userid);

           

            ViewData["caldata"] = textout + "kind: " + name + count + idlist + jsonIDs;

            return RedirectToAction("AuthGoogle");
            //return View();
            //return JavaScript("Refresh Token: " + tokenData.Refresh_Token);

        }

        public void saveLogin()
        {
            //System.Collections.ArrayList browser_array = Request.Browser.Browsers;
            String userAgent;
            //var br_str = "";
            //foreach (var br in browser_array)
            //{
              //  br_str = br_str + " " + br.ToString();
            //}
            var UAmax = Request.UserAgent;
            userAgent = Request.Browser.Platform + " " + Request.Browser.Browser;
            Guid guid = checkGUID();
            var userid = dataRepository.getID(guid);
            dataRepository.saveUseragent(userAgent, userid, UAmax);
           

        }

        public void saveSel(string selection)
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            var userid = dataRepository.getID(guid);
            dataRepository.saveSel(userid, selection);

        }

        public string getSel()
        {
            try
            {
                string guid_str = Request.Cookies["GUID"].Value;
                Guid guid = new Guid(guid_str);
                var userid = dataRepository.getID(guid);
                var selection = dataRepository.getSel(userid);
                if (selection == null)
                {
                    return "none";
                }
                else
                {
                    return selection;
                }
            }
            catch
            {
                return null;
            }

        }

        public void saveG_refresh(string value)
        {
            Guid guid = checkGUID();
            var userid = dataRepository.getID(guid);
            dataRepository.saveG_refresh(value, userid);

        }

        public void saveT_accesstoken(string value)
        {
            Guid guid = checkGUID();
            var userid = dataRepository.getID(guid);
            dataRepository.saveT_accesstoken(value, userid);
          

        }

        public void saveT_oauthtoken(string value)
        {
            Guid guid = checkGUID();
            var userid = dataRepository.getID(guid);
            dataRepository.saveT_oauthtoken(value, userid);

        }

        public void saveT_twid(string value)
        {
            Guid guid = checkGUID();
            var userid = dataRepository.getID(guid);
            dataRepository.saveT_twtid(value, userid);

        }

        public JsonResult getAgents()
        {
            var kindles = (from s in db.devices where s.UAmax.Contains("kindle") select s).Count().ToString();
            var chromes = (from s in db.devices where s.UAmax.Contains("chrome") select s).Count().ToString();
                      //TimeStamp = formatTimeStamp(tweet.CreatedAt.ToUniversalTime()),
                  

            return Json(new { kindles = kindles, chromes = chromes }, JsonRequestBehavior.AllowGet);
        }

        public Guid checkGUID()
        {
            try
            {
                string guid_str = Request.Cookies["GUID"].Value;
                Guid guid = new Guid(guid_str);

                return guid;
            }
            catch
            {
                
                //var guid = createGUID();
                Guid guid = Guid.NewGuid();
                var guidCookie = new HttpCookie("GUID", guid.ToString());
                guidCookie.Expires = DateTime.Now.AddYears(1);
                Response.AppendCookie(guidCookie);
                return guid;
            }

        }

        public ActionResult GoogleRefresh()
        {
            //use refresh token to get new access token
            //            POST /o/oauth2/token HTTP/1.1
            //Host: accounts.google.com
            //Content-Type: application/x-www-form-urlencoded

            //client_id=8819981768.apps.googleusercontent.com&
            //client_secret={client_secret}&
            //refresh_token=1/6BMfW9j53gdGImsiyUH5kU5RsR4zwI9lUVX-tqf8JXQ&
            //grant_type=refresh_token
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            string refresh_token = dataRepository.getG_refreshtoken(dataRepository.getID(guid));
            string Url = "https://accounts.google.com/o/oauth2/token";
            string grant_type = "refresh_token";
            var request_url = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Contains("~"));
            string urlBase = Request.Url.ToString();
            Uri myUri = new Uri(Request.Url.ToString());
            string redirect_uri_encode;
            if (request_url.Contains("localhost"))
            {
                redirect_uri_encode = UrlEncodeForGoogle(_ReturnUrl_local);
            }

            else
            {
                redirect_uri_encode = UrlEncodeForGoogle(_ReturnUrl);
            }
            string data = "client_id={0}&client_secret={1}&refresh_token={2}&grant_type={3}";

            HttpWebRequest request = HttpWebRequest.Create(Url) as HttpWebRequest;
            string result = null;
            request.Method = "POST";
            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";
            string param = string.Format(data, _GoogleClientId, _GoogleSecret, refresh_token, grant_type);
            var bs = Encoding.UTF8.GetBytes(param);
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }

            using (WebResponse response = request.GetResponse())
            {
                var sr = new StreamReader(response.GetResponseStream());
                result = sr.ReadToEnd();
                sr.Close();
            }

            var jsonSerializer = new JavaScriptSerializer();
            var tokenData = jsonSerializer.Deserialize<GoogleTokenData>(result);
            //var CalCookie = new HttpCookie("CalToken", tokenData.Access_Token);

            //CalCookie.Expires = DateTime.Now.AddYears(1);
            //Response.AppendCookie(CalCookie);

            Session["GoogleAPIToken"] = tokenData.Access_Token;

            return RedirectToAction("Index");

        }

        public void saveLocation(string lat, string lng, string loc)
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            int userid = dataRepository.getID(guid);
            dataRepository.saveLocation(lat, lng, userid, loc);
            //SetCookie("lat", lat);
            //SetCookie("long", lng);
            //save cookie
            //RedirectToAction("Index_T");
            //return RedirectToAction("Choose");
        }

        public ActionResult SaveTwID(string id)
        {
            SetCookie("TwitterID", id);

            return Redirect("/Mobile/Index_T");
        }

        public ActionResult Index_T_old()
        //enter twitter username and message for restful api
        {

            try
            {
                string tname = Request.Cookies["TwitterID"].Value;
                string accesstoken = Request.Cookies["oauth_accessToken"].Value;
                string oauthtoken = Request.Cookies["oauth_oauthToken"].Value;
                var msg = "hardcoded test " + DateTime.Now;
                //http://localhost:5010/Home/SetTwitterID?oauth_token=JjJCdn2Tn3o9Cz3lHEFotAZQ5xZSz8VbTAjHhg1aTt0&oauth_verifier=TP7PWgnTi2CIu2YuQ7AIpRDknEYuSe0H1RcYXMSp5g
                //Auth: oauthtoken=1317302059-F57J7rhJw18BYymjoZ5nJGqwhKd0nqax3jaItN5 id=FletcherFridge 1317302059 oathaccesstoken= v3g3lcENHnDPNNYTpSLLZZtZmCJ43bnvohLlDnNg7w
                credentials.ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"];
                credentials.ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"];
                credentials.AccessToken = accesstoken;
                //"36777457-120pFjOwR6YjwAHZcYnlrlwsW7cMBrmP7IAvH1NIY";
                //oauthverifier;
                //hWSN0pUWsBFlvS8fQbwpR31iqWLbhEnbUBCU3jZfI     from server
                //36777457-120pFjOwR6YjwAHZcYnlrlwsW7cMBrmP7IAvH1NIY
                credentials.OAuthToken = oauthtoken;
                //"71UrF3zuFNouejyu0RUhIqRVWsREuzzIpiwWYSc8A";
                //oauthtoken;
                //71UrF3zuFNouejyu0RUhIqRVWsREuzzIpiwWYSc8A

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
                     where tweet.Type == StatusType.Home
                     //&&     tweet.ScreenName == tname
                     select new TweetViewModel
                     {
                         ImageUrl = tweet.User.ProfileImageUrl,
                         ScreenName = tweet.User.Identifier.ScreenName,
                         TimeStamp = Convert.ToString(tweet.CreatedAt.Date),
                         Tweet = tweet.Text,
                         BannerText = GetBannerText(tweet),
                         // ID = Convert.ToString(tweet.Entities.MediaEntities.Count),
                         MediaUrl = GetTweetMediaUrl(tweet)
                     }).Take(9).ToList();


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
                return View("Index", friendTweets);

            }
            catch
            {
                return RedirectToAction("SetTwitterID");
            }
        }

        public ActionResult AuthTwitter()
        //enter twitter username and message for restful api
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            string TwID = dataRepository.getT_twtid(dataRepository.getID(guid));
            if (TwID != null)
            {
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("SetTwitterID");

            }

        }

        public ActionResult DeleteCookies(string type)
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            int userid = dataRepository.getID(guid);
            if (type == "Twitter")
            {
                dataRepository.del_twt(userid);
            }

            if (type == "Google")
            {
                dataRepository.del_ggl(userid);
                Session["GoogleAPIToken"] = "";
                SetCookie("Granted", "False");
                DelCookie("IDList", "");
            }

            if (type == "weather")
            {
                DelCookie("lat", "");
                DelCookie("long", "");
                //cycle thru others

            }

            return RedirectToAction("Index");
        }

        public ActionResult SiteHome()
        {

            return View("Index");
        }

        public ActionResult Mobile()
        {

            return View("Mobile");
        }

        public ActionResult JsonTweets(string timenow, int getnum)
        {
            
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            string tname = dataRepository.getT_twtid(dataRepository.getID(guid));
            string accesstoken = dataRepository.getT_accesstoken(dataRepository.getID(guid));
            string oauthtoken = dataRepository.getT_oauthtoken(dataRepository.getID(guid));
            var userid = dataRepository.getID(guid);
            var msg = "hardcoded test " + DateTime.Now;
            //http://localhost:5010/Home/SetTwitterID?oauth_token=JjJCdn2Tn3o9Cz3lHEFotAZQ5xZSz8VbTAjHhg1aTt0&oauth_verifier=TP7PWgnTi2CIu2YuQ7AIpRDknEYuSe0H1RcYXMSp5g
            //Auth: oauthtoken=1317302059-F57J7rhJw18BYymjoZ5nJGqwhKd0nqax3jaItN5 id=FletcherFridge 1317302059 oathaccesstoken= v3g3lcENHnDPNNYTpSLLZZtZmCJ43bnvohLlDnNg7w
            credentials.ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"];
            credentials.ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"];
            credentials.AccessToken = accesstoken;
            //"36777457-120pFjOwR6YjwAHZcYnlrlwsW7cMBrmP7IAvH1NIY";
            //oauthverifier;
            //hWSN0pUWsBFlvS8fQbwpR31iqWLbhEnbUBCU3jZfI     from server
            //36777457-120pFjOwR6YjwAHZcYnlrlwsW7cMBrmP7IAvH1NIY
            credentials.OAuthToken = oauthtoken;
            //"71UrF3zuFNouejyu0RUhIqRVWsREuzzIpiwWYSc8A";
            //oauthtoken;
            //71UrF3zuFNouejyu0RUhIqRVWsREuzzIpiwWYSc8A

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

            var mentions =
            (from tweet in twitterCtx.Status
             where tweet.Type == StatusType.Mentions
             // && tweet.SinceID == 397389362088132608
             select new TweetViewModel
             {
                 //ImageUrl = tweet.Entities.,
                 ScreenName = tweet.ScreenName,
                 TimeStamp = formatTimeStamp(tweet.CreatedAt.ToUniversalTime()),
                 //Convert.ToString(tweet.CreatedAt.ToUniversalTime()),
                 Tweet = tweet.Text,
                 BannerText = GetBannerText(tweet),
                 BannerTime = GetBannerTime(tweet),
                 ID = tweet.StatusID,
                 ImageUrl = tweet.User.ProfileImageUrl,
                 //SinceID = tweet.SinceID,
                 //Convert.ToString(tweet.Entities.MediaEntities.Count),
                 MediaUrl = GetTweetMediaUrl(tweet),
                 EntityUrl = GetTweetUrlEntities(tweet)
             });

            var home =
            (from tweet in twitterCtx.Status
             where tweet.Type == StatusType.Home
             // && tweet.SinceID == 397389362088132608
             select new TweetViewModel
             {
                 //ImageUrl = tweet.Entities.,
                 ScreenName = tweet.ScreenName,
                 TimeStamp = formatTimeStamp(tweet.CreatedAt.ToUniversalTime()),
                 //Convert.ToString(tweet.CreatedAt.ToUniversalTime()),
                 Tweet = tweet.Text,
                 BannerText = GetBannerText(tweet),
                 BannerTime = GetBannerTime(tweet),
                 ID = tweet.StatusID,
                 ImageUrl = tweet.User.ProfileImageUrl,
                 //SinceID = tweet.SinceID,
                 //Convert.ToString(tweet.Entities.MediaEntities.Count),
                 MediaUrl = GetTweetMediaUrl(tweet),
                 EntityUrl = GetTweetUrlEntities(tweet)
             });

 
            var mytweets =
                (from tweet in twitterCtx.Status
                 where tweet.Type == StatusType.User
                 // && tweet.SinceID == 397389362088132608
                 select new TweetViewModel
                 {
                     //ImageUrl = tweet.Entities.,
                     ScreenName = tweet.User.Name,
                     TimeStamp = formatTimeStamp(tweet.CreatedAt.ToUniversalTime()),
                     //Convert.ToString(tweet.CreatedAt.ToUniversalTime()),
                     Tweet = tweet.Text,
                     BannerText = GetBannerText(tweet),
                     BannerTime = GetBannerTime(tweet),
                     ID = tweet.StatusID,
                     ImageUrl = tweet.User.ProfileImageUrl,
                     //SinceID = tweet.SinceID,
                     //Convert.ToString(tweet.Entities.MediaEntities.Count),
                     MediaUrl = GetTweetMediaUrl(tweet),
                     EntityUrl = GetTweetUrlEntities(tweet)
                 });

            string status = "hihi " + DateTime.Now;
            var oauthToken = auth.Credentials.OAuthToken;
            var oauthAccessT = auth.Credentials.AccessToken;
            var userd = auth.Credentials.ScreenName + " " + auth.Credentials.UserId;
            //http://localhost:5010/?oauth_token=9IWia8yWenYytqosbErCRno7KcJPr55fMXHvqJkoY&oauth_verifier=g6pbTya6OOcsH2O0f3PuzQKUtCQBz1lQBz0BmnixHU
            ViewData["authdeets"] = oauthAccessT;
            //Auth: oauthtoken=1317302059-F57J7rhJw18BYymjoZ5nJGqwhKd0nqax3jaItN5 id=FletcherFridge 1317302059 oathaccesstoken= v3g3lcENHnDPNNYTpSLLZZtZmCJ43bnvohLlDnNg7w
            //+ save id first time.
            // var jsonresults = JsonConvert.SerializeObject(friendTweets);
            var latestid = mytweets.First().ID;
            var latesttime = mytweets.First().TimeStamp;
            //var topBanner = GetBannerText(friendTweets.First())
            var doBanner = "false";
            var BannerID = mytweets.First().ID;
            var bannertime = "";
            var topname = "";
            int banchk = dataRepository.checkBanner(Convert.ToInt32(userid),BannerID);
            if ((mytweets.First().BannerText.Length > 1) && (banchk == 0))
            {
                doBanner = "true";
                
                bannertime = mytweets.First().BannerTime;
                topname = mytweets.First().ScreenName;
            }

            return Json(new { mytweets = mytweets.Take(getnum), home = home.Take(getnum), getmore = getnum, topname = topname, mentions = mentions, latestid = latestid, doBanner = doBanner, BannerID = BannerID, twitterID = tname, bannertime = bannertime}, JsonRequestBehavior.AllowGet);
            //return Json("Index", friendTweets);

        }

        public ActionResult GetBanner(string ID)
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            string tname = dataRepository.getT_twtid(dataRepository.getID(guid));
            string accesstoken = dataRepository.getT_accesstoken(dataRepository.getID(guid));
            string oauthtoken = dataRepository.getT_oauthtoken(dataRepository.getID(guid));
            var userid = dataRepository.getID(guid);
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
            twitterCtx = new TwitterContext(auth);

            var friendTweets =
                (from tweet in twitterCtx.Status
                 where tweet.Type == StatusType.User
                 && tweet.StatusID == ID
                 select new TweetViewModel
                 {
                     // ImageUrl = tweet.User.ProfileImageUrl,
                     // ScreenName = tweet.StatusID,
                     BannerText = GetBannerText(tweet),
                     BannerTime = GetBannerTime(tweet),
                    
                 });
            //.Take(9).ToList();

            var oauthToken = auth.Credentials.OAuthToken;
            var oauthAccessT = auth.Credentials.AccessToken;
            var userd = auth.Credentials.ScreenName + " " + auth.Credentials.UserId;
            ViewData["authdeets"] = oauthAccessT;
            //var latestid = friendTweets.First().ID;
            dataRepository.saveBanner(Convert.ToInt32(userid),ID,"type");
            return Json(new { BannerText = friendTweets.First().BannerText }, JsonRequestBehavior.AllowGet);


        }

        public ActionResult CheckJsonTweets()
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            string tname = dataRepository.getT_twtid(dataRepository.getID(guid));
            string accesstoken = dataRepository.getT_accesstoken(dataRepository.getID(guid));
            string oauthtoken = dataRepository.getT_oauthtoken(dataRepository.getID(guid));

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
            twitterCtx = new TwitterContext(auth);

            var friendTweets =
                (from tweet in twitterCtx.Status
                 where tweet.Type == StatusType.User
                 select new TweetViewModel
                 {
                     // ImageUrl = tweet.User.ProfileImageUrl,
                     // ScreenName = tweet.StatusID,
                     ID = tweet.StatusID,
                 });
            //.Take(9).ToList();

            var oauthToken = auth.Credentials.OAuthToken;
            var oauthAccessT = auth.Credentials.AccessToken;
            var userd = auth.Credentials.ScreenName + " " + auth.Credentials.UserId;
            ViewData["authdeets"] = oauthAccessT;
            var latestid = friendTweets.First().ID;
            return Json(new { LatestID = latestid }, JsonRequestBehavior.AllowGet);


        }


        private string formatTimeStamp(DateTime datetime)
        {
            DateTime now = DateTime.Now;
            var daysago = (now - datetime).Days;
            var time_txt = "";
            time_txt = daysago + "d";
            if (Convert.ToInt32(daysago) == 0)
            {
                var hoursago = (now - datetime).Hours;
                time_txt = hoursago + "h";

                if (Convert.ToInt32(hoursago) < 1)
                {
                    var minsago = (now - datetime).Minutes;
                    time_txt = minsago + "m";

                    if (Convert.ToInt32(minsago) < 1)
                    {
                        var secsago = (now - datetime).Seconds;
                        time_txt = secsago + "s";
                    }

                }

            }


            return time_txt;
        }

        //status.Entities.MediaEnt

        private string GetTweetUrlEntities(Status status)
        {
            if (status.Entities != null &&
                status.Entities.UrlEntities.Count > 0)
            {
                return status.Entities.UrlEntities[0].ExpandedUrl;
            }
            return "";
        }

        private string GetTweetMediaUrl(Status status)
        {
            if (status.Entities != null &&
                status.Entities.MediaEntities.Count > 0)
            {
                return status.Entities.MediaEntities[0].MediaUrl;
            }
            return "";
        }

        private string GetBannerText(Status status)
        {
            var tweet_txt = status.Text;
            var bantxt = getBetween(tweet_txt, "#banner");
            return bantxt;
            //var tweet_type;
           // if (tweet_txt.Contains("#bannernow"))
          //  {
          //      var bantxt = getBetween(tweet_txt, "#bannernow", "now");
          //      return bantxt;
          //  }
          //  else if (tweet_txt.Contains("#bannertime"))
          //  {
          //      var bantxt = getBetween(tweet_txt, "#bannertime", "time");
          //      return bantxt;
          //  }
            
        }

        private string GetBannerTime(Status status)
        {
            var tweet_txt = status.Text;
            int tfstart = tweet_txt.IndexOf("#banner", 0) + 8;
            if (tfstart > 8)
            {
                try
                {
                    int start = tweet_txt.Length - 1;
                    int end = tweet_txt.Length;
                    var bantxt = tweet_txt.Substring(tfstart, (tweet_txt.Length - tfstart));
                    //var time = Convert.ToInt32(tweet_txt.Substring(tweet_txt.Length - 2, tweet_txt.Length - 1));
                    var timetxt = bantxt.Split(' ')[0];
                    var timeval = timetxt.Substring(0, timetxt.Length - 1);
                    var timeframe = timetxt.Substring(timetxt.Length - 1, 1);
                    int time = Convert.ToInt32(timeval);
                    try
                    {
                        int ms = 1;
                        if (timeframe == "h")
                        {
                            ms = 3600000;

                        }
                        else if (timeframe == "m")
                        {

                            ms = 60000;
                        }

                        else if (timeframe == "s")
                        {

                            ms = 1000;
                        }
                        //var tweet_type;
                        return Convert.ToString(ms * time);

                    }
                    catch
                    {

                        return "10000";

                    }
                }
                catch
                {

                    return "0";
                }
            }
            else
            {

                return "0";

            }

            //return "10000";
        }

        public static string getBetween(string strSource, string strStart)
        {
            int Start, End;

            if (strSource.Contains(strStart))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.Length;
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        public ActionResult Index_Test()
        //enter twitter username and message for restful api
        {

            try
            {
                string guid_str = Request.Cookies["GUID"].Value;
                Guid guid = new Guid(guid_str);
                string tname = dataRepository.getT_twtid(dataRepository.getID(guid));
                string accesstoken = dataRepository.getT_accesstoken(dataRepository.getID(guid));
                string oauthtoken = dataRepository.getT_oauthtoken(dataRepository.getID(guid));

                var msg = "hardcoded test " + DateTime.Now;
                //http://localhost:5010/Home/SetTwitterID?oauth_token=JjJCdn2Tn3o9Cz3lHEFotAZQ5xZSz8VbTAjHhg1aTt0&oauth_verifier=TP7PWgnTi2CIu2YuQ7AIpRDknEYuSe0H1RcYXMSp5g
                //Auth: oauthtoken=1317302059-F57J7rhJw18BYymjoZ5nJGqwhKd0nqax3jaItN5 id=FletcherFridge 1317302059 oathaccesstoken= v3g3lcENHnDPNNYTpSLLZZtZmCJ43bnvohLlDnNg7w
                credentials.ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"];
                credentials.ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"];
                credentials.AccessToken = accesstoken;
                //"36777457-120pFjOwR6YjwAHZcYnlrlwsW7cMBrmP7IAvH1NIY";
                //oauthverifier;
                //hWSN0pUWsBFlvS8fQbwpR31iqWLbhEnbUBCU3jZfI     from server
                //36777457-120pFjOwR6YjwAHZcYnlrlwsW7cMBrmP7IAvH1NIY
                credentials.OAuthToken = oauthtoken;
                //"71UrF3zuFNouejyu0RUhIqRVWsREuzzIpiwWYSc8A";
                //oauthtoken;
                //71UrF3zuFNouejyu0RUhIqRVWsREuzzIpiwWYSc8A

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
                     where tweet.Type == StatusType.User &&
                           tweet.ScreenName == tname
                     select new TweetViewModel
                     {
                         ImageUrl = tweet.User.ProfileImageUrl,
                         ScreenName = tweet.User.Identifier.ScreenName,
                         TimeStamp = Convert.ToString(tweet.CreatedAt.Date),
                         Tweet = tweet.Text,
                         //   ID = tweet.ID
                     }).Take(5).ToList();
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
                return View("IndexTest", friendTweets);

            }
            catch
            {
                return RedirectToAction("SetTwitterID");
            }
        }

        public ActionResult testout()
        {
            ServiceReferenceText.Service1SoapClient Client = new ServiceReferenceText.Service1SoapClient();
            // var output = from d in Client.stripHTML("http://www.bbcgoodfood.com/recipes/2459643/vintage-chocolate-chip-cookies", 1)
            //            select d;
            var test = Client.stripHTML("http://www.bbcgoodfood.com/recipes/2459643/vintage-chocolate-chip-cookies", 1);


            // ViewData["output"] = output;

            return View();

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
                //Uri specialUri = new Uri("http://localhost:5010/Mobile/DoneTwitterAuth");
                return auth.BeginAuthorization(specialUri);
            }

            // var at = auth.Credentials.AccessToken;
            // var oauthtoken = auth.Credentials.OAuthToken;

            var accesstoken = credentials.AccessToken;
            var oauthtoken = credentials.OAuthToken;
            var twitterID = credentials.ScreenName;

            saveT_accesstoken(accesstoken);
            saveT_oauthtoken(oauthtoken);
            saveT_twid(twitterID);

            //SetCookie("oauth_accessToken", accesstoken);
            //SetCookie("oauth_oauthToken", oauthtoken);
            //SetCookie("TwitterID", twitterID);

            return RedirectToAction("AuthTwitter");


        }

        public ActionResult DoneTwitterAuth(string oauth_token, string oauth_verifier)
        {
            ViewData["deets"] = oauth_verifier + oauth_token;

            SetCookie("oauth_tokenT", oauth_token);
            SetCookie("oauth_verifierT", oauth_verifier);
            //return RedirectToAction("Index_T");
            return View();
        }

        public ActionResult Done()
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            string JsonIDs = dataRepository.getG_idlist(dataRepository.getID(guid));
            //string JsonIDs = Request.Cookies["IDList"].Value;

            JObject o = JObject.Parse(JsonIDs);
            JArray items = (JArray)o["items"];
            //string count = (string)items.Count.ToString();
            //int idcount = Convert.ToInt32(count);
            string count = (string)o["Count"];
            ViewData["caldata"] = "IDs found: " + count + "JSON=" + JsonIDs;
            return View();
        }


        public ActionResult SetChoice(string Twitter, string Google, string weather)
        {

            if (Twitter == "on")
            {
                SetCookie("Twitter", Twitter);
            }
            else
            {
                SetCookie("Twitter", "off");
            }

            return View("ChoiceT");
        }

        private void SetCookie(string name, string value)
        {
            var cookie = new HttpCookie(name, value);
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.AppendCookie(cookie);
        }

        private void DelCookie(string name, string value)
        {
            var cookie = new HttpCookie(name, value);
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.AppendCookie(cookie);
        }

        public JsonResult DoneTest(string email, int max, int min)
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            string JsonIDs = dataRepository.getG_idlist(dataRepository.getID(guid));
            //var textout2 = jsonS.DeserializeObject(textout);

            System.Collections.Generic.List<string> ID_array = new System.Collections.Generic.List<string>();


            var idlist = "";
            JObject o = JObject.Parse(JsonIDs);
            JArray items = (JArray)o["items"];
            //string count = (string)items.Count.ToString();
            //int idcount = Convert.ToInt32(count);
            string count = (string)o["Count"];

            //do an ajax request for Done and return json
            var accessToken = Session["GoogleAPIToken"];
            //Request.Cookies["CalToken"].Value;
            //
            var urlBuilder = new System.Text.StringBuilder();
            var urlBuilder2 = new System.Text.StringBuilder();
            urlBuilder.Append("https://");
            urlBuilder.Append("www.googleapis.com");
            urlBuilder.Append("/calendar/v3/users/me/calendarList");
            urlBuilder.Append("?minAccessRole=writer");

            //DateTime UtcDateTime = TimeZoneInfo.ConvertTimeToUtc(DateTime);
            //return XmlConvert.ToString(UtcDateTime, XmlDateTimeSerializationMode.Utc);
            DateTime UtcDateTime = new DateTime();
            UtcDateTime = DateTime.Now;
            //2002-10-02T15:00:00Z
            UtcDateTime.AddDays(-1);
            var datestr_min = UtcDateTime.AddDays(min).Year + "-" + UtcDateTime.AddDays(min).Month + "-" + UtcDateTime.AddDays(min).Day + "T00:00:00Z";
            var datestr_max = UtcDateTime.AddDays(max).Year + "-" + UtcDateTime.AddDays(max).Month + "-" + UtcDateTime.AddDays(max).Day + "T00:00:00Z";
            urlBuilder2.Append("https://");
            urlBuilder2.Append("www.googleapis.com");
            urlBuilder2.Append("/calendar/v3/calendars/" + email + "/events");
            urlBuilder2.Append("?maxResults=5&orderBy=startTime&singleEvents=true&timeMax=" + datestr_max + "&timeMin=" + datestr_min);
            //updatedMin=2013-03-28T12%3A00%3A00.000%2B00%3A00");
            // urlBuilder.Append("&access_token=4/ZsN6Wn19QrcPbk6WarRGEIXSHaKO.QubFbrJ1OpsSOl05ti8ZT3ZDPtonfAI");
            var url = urlBuilder2.ToString();

            //https://www.googleapis.com/calendar/v3/calendars/nick.fletcher%40gmail.com/events?maxResults=5&orderBy=startTime&singleEvents=true&updatedMin=2013-04-01T12%3A00%3A00.000%2B00%3A00&key={YOUR_API_KEY}


            //https://www.googleapis.com/calendar/v3/users/me/calendarList?minAccessRole=writer&access_token=4/ZsN6Wn19QrcPbk6WarRGEIXSHaKO.QubFbrJ1OpsSOl05ti8ZT3ZDPtonfAI

            var httpWebRequest = HttpWebRequest.Create(urlBuilder2.ToString())
                as HttpWebRequest;
            //httpWebRequest.ContentType = "application/json ; charset=UTF-8";
            httpWebRequest.CookieContainer = new CookieContainer();
            httpWebRequest.Headers["Authorization"] =
                string.Format("Bearer {0}", accessToken);
            try
            {

                var responsec = httpWebRequest.GetResponse();
                // if (responsec.ContentType == "Unauthorized") {


                //responsec.ContentType = "application/json ; charset=UTF-8";
                var outj = responsec.ReadReponse();
                var outj2 = outj;
                //string textout = responsec.ReadReponse();
                var jsonS = new JavaScriptSerializer();
                var textout = jsonS.DeserializeObject(outj2);


                // var calendar = calendarService.CalendarList.List().Fetch().Items.FirstOrDefault(c => c.Summary.Contains(calendarId));

                return Json(textout);

            }
            catch
            {
                return Json(new { type = "refresh" });
            }
        }



        public ActionResult Authenticate()
        {
            //var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description); 

            UserAgentClient consumer = new UserAgentClient(GoogleAuthenticationServer.Description, clientId, secret);
            IAuthorizationState state = new AuthorizationState(new[] { CalendarService.Scopes.Calendar.GetStringValue() });
            //IAuthorizationState state = new AuthorizationState(new[] { TasksService.Scopes.Tasks.GetStringValue() });
            state.Callback = new Uri(Url.Action("OAuthCallback", "Home", null, "http"));
            var request = consumer.RequestUserAuthorization(state);
            return Redirect(request.ToString());
        }

        public ActionResult OAuthCallback(string code)
        {
            UserAgentClient consumer = new UserAgentClient(GoogleAuthenticationServer.Description, clientId, secret);
            OAuth2Authenticator<UserAgentClient> authenticator = new OAuth2Authenticator<UserAgentClient>(consumer, ProcessAuth);
            //IAuthorizationState state = new AuthorizationState(new[] { TasksService.Scopes.Tasks.GetStringValue() });
            IAuthorizationState state = new AuthorizationState(new[] { CalendarService.Scopes.Calendar.GetStringValue() });
            state.Callback = new Uri(Url.Action("OAuthSuccess", "Home", null, "http"));
            authenticator.LoadAccessToken();
            ViewData["token"] = "token = " + state.AccessToken;
            return RedirectToAction("Done", "Home");
        }

        public ActionResult OAuthSuccess(string access_token)
        {
            Session["token"] = access_token;
            ViewData["token"] = "token = " + access_token;
            return RedirectToAction("Done", "Home");
        }


        public ActionResult start()
        {
            string url = GoogleAuthorizationHelper.GetAuthorizationUrl("nick.fletcher@gmail.com");
            Response.Redirect(url);
            ViewData["token"] = "at the start";
            return RedirectToAction("Done", "Home");

        }





        public ActionResult GoogleAuthorization(string code)
        {
            // Retrieve the authenticator and save it in session for future use
            var authenticator = GoogleAuthorizationHelper.GetAuthenticator(code);
            Session["authenticator"] = authenticator;

            // Save the refresh token locally
            /*
            using (var dbContext = new UsersContext())
            {
                var userName = User.Identity.Name;
                var userRegistry = dbContext.GoogleRefreshTokens.FirstOrDefault(c => c.UserName == userName);

                if (userRegistry == null)
                {
                    dbContext.GoogleRefreshTokens.Add(
                        new GoogleRefreshToken()
                        {
                            UserName = userName,
                            RefreshToken = authenticator.RefreshToken
                        });
                }
                else
                {
                    userRegistry.RefreshToken = authenticator.RefreshToken;
                }

                dbContext.SaveChanges();
            }
            
             */

            return RedirectToAction("Done", "Home", new { code = code });
        }

        //step tru with tasks

        //   public static IAuthorizationState GetAuthentication(NativeApplicationClient arg)
        //        {
        // Get the auth URL:
        //           IAuthorizationState state = new AuthorizationState(new[] { CalendarService.Scopes.Calendar.ToString()});
        //         state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
        //       Uri authUri = arg.RequestUserAuthorization(state);


        private IAuthorizationState ProcessAuth(UserAgentClient arg)
        {
            //var state = arg.ProcessUserAuthorization(
            IAuthorizationState state = new AuthorizationState(new[] { CalendarService.Scopes.Calendar.ToString() });
            //state.Callback = new Uri(UserAgentClient.
            //NativeApplicationClient.OutOfBandCallbackUrl);
            Uri authUri = arg.RequestUserAuthorization(state);

            return arg.ProcessUserAuthorization(authUri, state);
            //state.AccessToken = "4/RiivG661wjtmM2OnwOgUOSnfWB26.YnfGCkZtijUROl05ti8ZT3aza-cZfAI";
            //return state;
        }

        //The following required parameters were missing from the 
        //DotNetOpenAuth.OAuth2.Messages.AccessTokenAuthorizationCodeRequest message: redirect_uri

        public ActionResult About()
        {

            var accessToken = "4/aLHDvYTtOTpXEeL88FAU8CLYqdGN.srCE09tmIfISOl05ti8ZT3Y3vYMFfAI";
            //moduleModel.User.AccessToken.Token;

            var urlBuilder = new System.Text.StringBuilder();

            urlBuilder.Append("https://");
            urlBuilder.Append("www.googleapis.com");
            urlBuilder.Append("/calendar/v3/users/me/calendarList");
            urlBuilder.Append("?minAccessRole=writer");
            // urlBuilder.Append("&access_token=4/ZsN6Wn19QrcPbk6WarRGEIXSHaKO.QubFbrJ1OpsSOl05ti8ZT3ZDPtonfAI");

            //https://www.googleapis.com/calendar/v3/users/me/calendarList?minAccessRole=writer&access_token=4/ZsN6Wn19QrcPbk6WarRGEIXSHaKO.QubFbrJ1OpsSOl05ti8ZT3ZDPtonfAI

            var httpWebRequest = HttpWebRequest.Create(urlBuilder.ToString())
                as HttpWebRequest;
            //httpWebRequest.ContentType = "application/json ; charset=UTF-8";
            httpWebRequest.CookieContainer = new CookieContainer();
            httpWebRequest.Headers["Authorization"] =
                string.Format("Bearer {0}", accessToken);

            var response = httpWebRequest.GetResponse();

            //var responseText = response.get.GetResponseText();
            var rtext = response.GetResponseStream();
            var rtext2 = rtext.Length;

            var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description)
            {
                ClientIdentifier = "651937086252-na99drkmmna0k5purb5h27mnfifvc2tr.apps.googleusercontent.com",
                ClientSecret = "l16kKa9wSc6E0oJzeyzRS5Ne"

            };



            //        CalendarService service_a = new CalendarService();

            //       CalendarsResource.GetRequest cr = service_a.Calendars.Get("{primary}");

            //        if (cr.CalendarId != null)
            //      {
            //      Console.WriteLine("Fetching calendar");
            //        //Google.Apis.Calendar.v3.Data.Calendar c = service.Calendars.Get("{primary}").Fetch();

            //    }
            //      else
            //       {
            //         Console.WriteLine("Service not found");
            //   }

            //           var auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthentication);
            //         var service = new CalendarService(new BaseClientService.Initializer()
            //       {
            //             Authenticator = auth
            //       });

            //     CalendarsResource.GetRequest cr2 = service.Calendars.Get("{primary}");
            //Google.Apis.Calendar.v3.Data.Calendar cr3 = service.Calendars.Get("{primary}").Fetch();
            var data = "";
            //cr3.Id;
            //   var results = service.CalendarList.List().Fetch();


            // 
            // AuthenticatorFactory.GetInstance().RegisterAuthenticator(() => new OAuth2Authenticator(provider, GetAuthentication));
            //access token = v3g3lcENHnDPNNYTpSLLZZtZmCJ43bnvohLlDnNg7w;
            //GetAuthentication();
            //var auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthentication);
            // auth.LoadAccessToken;
            //   ViewData["authcode"] = auth + "d=" + data + results;
            return View();
        }

        //        public static IAuthorizationState GetAuthentication(NativeApplicationClient arg)
        //        {
        // Get the auth URL:
        //           IAuthorizationState state = new AuthorizationState(new[] { CalendarService.Scopes.Calendar.ToString()});
        //         state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
        //       Uri authUri = arg.RequestUserAuthorization(state);

        // Request authorization from the user (by opening a browser window):
        //Process.Start(authUri.ToString());
        //           Console.Write("  Authorization Code: ");
        //           string authCode = authUri.UserInfo;
        //           Console.WriteLine();

        //return RedirectResult(authUri);

        // Retrieve the access token by using the authorization code:
        //         return arg.ProcessUserAuthorization(authCode, state);
        //   }

        private static IAuthorizationState RedirectResult(Uri authUri)
        {
            throw new NotImplementedException();
        }
    }
}
