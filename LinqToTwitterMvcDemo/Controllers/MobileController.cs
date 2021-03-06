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


        public ActionResult IndexC(string zcguid)  //copy this one
        {
            //var token1 = Session["GoogleAPIToken"];
            //ViewData["token"] = token1;



            if (zcguid == null) //id parameter is set ?
            {

                try
                {
                    int userid = 0;
                    string guid_str = Request.Cookies["GUID"].Value;
                    Guid guid = new Guid(guid_str);

                    if (dataRepository.checkGUIDzc(guid) == 1)
                    {
                        userid = dataRepository.getUserid(guid, "master");
                        ViewData["banner"] = "Welcome parent device";
                    }

                    if (dataRepository.checkGUIDzc(guid) == 2)
                    {
                        userid = dataRepository.getUserid(guid, "child");
                        ViewData["banner"] = "Welcome child device, no GUID but cookies";
                        ViewData["type"] = "child";
                        //if first login, ask for PIN
                        //set cookies
                        string tname = dataRepository.getT_twtid(userid);
                        if (tname != null)
                        {
                            ViewData["details"] = "have twitter id " + tname;
                            SetCookie("tweets", "dm");
                            SetCookie("GrantedT","True");

                            
                        }
                        

                    }


                    //var userid = dataRepository.getID(guid);
                    string tname1 = dataRepository.getT_twtid(userid);
                    if (tname1 == null)
                    {
                        ViewData["details"] = "no twitter ID";
                    }
                    else
                    {
                        ViewData["details"] = "have twitter id "  + tname1;
                        
                    }

                    //check for google and weather settings in db


                }
                catch
                {
                    ViewData["details"] = "catch from try for GUID cookie, make a GUID";
                        Guid guid = Guid.NewGuid();
                        var guidCookie = new HttpCookie("GUID", guid.ToString());
                        guidCookie.Expires = DateTime.Now.AddYears(1);
                        Response.AppendCookie(guidCookie);
                        var userid = dataRepository.getID(guid);
                        return View();
                }


                try
                {

                    int userid = 0;
                    string guid_str = Request.Cookies["GUID"].Value;
                    Guid guid = new Guid(guid_str);

                    if (dataRepository.checkGUIDzc(guid) == 1)
                    {
                        userid = dataRepository.getUserid(guid, "master");
                    }

                    if (dataRepository.checkGUIDzc(guid) == 2)
                    {
                        userid = dataRepository.getUserid(guid, "child");

                    }


                    int tempid = dataRepository.getID(guid);
                    string JsonIDs = dataRepository.getG_idlist(tempid);
                    
                    
                    JObject o = JObject.Parse(JsonIDs);
                    // JArray items = (JArray)o["items"];
                    var names = Convert.ToString(o["Fullname"]);
                    
                    var count = Convert.ToString(o["Count"]);
                    int idcount = Convert.ToInt32(count);
                    //string name = (string)o["kind"];
                    var ids = names.Replace("[", "").Replace("]", "").Replace("\"", "");
                    var IDCookie = new HttpCookie("IDList", JsonIDs);
                    IDCookie.Expires = DateTime.Now.AddYears(1);
                    Response.AppendCookie(IDCookie);
                    ViewData["details"] = "Have google id " + ids;
                }
                catch
                {
                    ViewData["details"] = "no google ID";
                    //<button onclick=\"Auth(1,'Google')\" class=\"ui-btn ui-btn-b ui-corner-all\">Authenticate</button><div>Allows Fridge Door to read your Google calendar</div>";
                }

                try
                {

                    int userid = 0;
                    string guid_str = Request.Cookies["GUID"].Value;
                    Guid guid = new Guid(guid_str);

                    userid = dataRepository.getUserid(guid, "master");  //own userid for weather
                   
                    var loc = dataRepository.getLocation(userid);
                    var latlng = dataRepository.getLatLng(userid);
                    
                    if (loc != null)
                    {
                       // ViewData["location"] = "<a href=\"#\" onclick=\"ChangeLoc()\" class=\"ui-btn ui-btn-b ui-corner-all\">Change</a><div>Location set to: " + loc + " (" + latlng + ")</div>";
                    }
                    else
                    {
                        //ViewData["location"] = "<button onclick=\"SetLoc()\" class=\"ui-btn ui-btn-b ui-btn-inline\">Set Location</button></div>Daily weather from Accuweather</div>"; 
                       // ViewData["location"] = "<a href=\"#\" onclick=\"SetLoc()\" class=\"ui-btn ui-btn-b ui-corner-all\">Set Location</a><div>Daily weather from Accuweather</div>";
                    }
                }
                catch
                {
                    //ViewData["location"] = "<a href=\"#\" onclick=\"SetLoc()\" class=\"ui-btn ui-btn-b ui-corner-all\">Set Location</a><div>Daily weather from Accuweather</div>";
                }

                return View();
            }
            else
            {
                //have a GUID in the URL
                Guid guidnew = new Guid(zcguid);

                if (dataRepository.checkGUIDzc(guidnew) > 0)   //1=no parent, 2=has parent
                {

                    //if it has a parent ID, get settings
                    //set cookies for twitter and google and weather as per settings
                    var guidCookie = new HttpCookie("GUID", zcguid.ToString());
                    guidCookie.Expires = DateTime.Now.AddYears(1);
                    Response.AppendCookie(guidCookie);
                    int userid = 0;

                    if (dataRepository.checkGUIDzc(guidnew) == 1)
                    {
                        userid = dataRepository.getUserid(guidnew, "master");
                        var useridCookie = new HttpCookie("userID", Convert.ToString(userid));
                        useridCookie.Expires = DateTime.Now.AddYears(1);
                        Response.AppendCookie(useridCookie);
                        //parent, need to reauthenticate
                        ViewData["details2"] = "parent, reauth one";
                    }

                    if (dataRepository.checkGUIDzc(guidnew) == 2)
                    {
                        userid = dataRepository.getUserid(guidnew, "child");
                        var useridCookie = new HttpCookie("masterID", Convert.ToString(userid));
                        useridCookie.Expires = DateTime.Now.AddYears(1);
                        Response.AppendCookie(useridCookie);
                        //child, need to enter PIN
                        ViewData["details2"] = "child, GUID in URL, no cookie, enter PIN";
                        ViewData["type"] = "child";
                        //if first login, ask for PIN
                        //set cookies
                        string tname = dataRepository.getT_twtid(userid);
                        if (tname != null)
                        {
                            ViewData["details"] = "have twitter id " + tname;
                            SetCookie("tweets", "my");
                            SetCookie("GrantedT", "True");
                        }
                        
                    }

                    /*
                    try
                    {
                        string JsonIDs = dataRepository.getG_idlist(userid);
                        var IDCookie = new HttpCookie("IDList", JsonIDs);
                        IDCookie.Expires = DateTime.Now.AddYears(1);
                        Response.AppendCookie(IDCookie);

                        var GrantCookie = new HttpCookie("Granted", "True");
                        GrantCookie.Expires = DateTime.Now.AddYears(1);
                        Response.AppendCookie(GrantCookie);
                        //int userid = dataRepository.getID(guidnew);
                        var token = dataRepository.getG_refreshtoken(userid);
                        //saveG_refresh(tokenData.Refresh_Token);

                        Session["GoogleAPIToken"] = token;
                        var lat = dataRepository.getLat(userid);
                        var lng = dataRepository.getLng(userid);
                        SetCookie("lat", lat);
                        SetCookie("long", lng);

                        //get from db lat lng and set cookies
                        return View();
                       // return RedirectToAction("IndexC");
                    }
                    catch
                    {

                    }
                    */
                    return View();
                    //RedirectToAction("IndexC");
                }

            }
            return View();
            //          
        }


        public ActionResult Index(string zcguid) //now in use
        {

            var token1 = Session["GoogleAPIToken"];
            ViewData["token"] = token1;


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
                        ViewData["twitter"] = "<a href=\"#\" onclick=\"Auth(1,'Twitter')\" class=\"ui-btn ui-btn-b ui-corner-all\">Authenticate</a><div>Allows OK fridge to read your tweets.</div>";
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
                    ViewData["google"] = "<a href=\"#\" onclick=\"Auth(1,'Google')\" class=\"ui-btn ui-btn-b ui-corner-all\">Authenticate</a><div>Allows OK fridge to read your Google calendar.</div>";
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

                if (dataRepository.checkGUIDzc(guidnew) > 0)   //1=no parent, 2=has parent
                {

                    //if it has a parent ID, get settings
                    //set cookies for twitter and google and weather as per settings
                    var guidCookie = new HttpCookie("GUID", zcguid.ToString());
                    guidCookie.Expires = DateTime.Now.AddYears(1);
                    Response.AppendCookie(guidCookie);
                    int userid = 0;

                    if (dataRepository.checkGUIDzc(guidnew) == 1)
                    {
                        userid = dataRepository.getUserid(guidnew, "master");
                        var useridCookie = new HttpCookie("userID", Convert.ToString(userid));
                        useridCookie.Expires = DateTime.Now.AddYears(1);
                        Response.AppendCookie(useridCookie);
                    }

                    if (dataRepository.checkGUIDzc(guidnew) == 2)
                    {
                        userid = dataRepository.getUserid(guidnew, "child");
                        var useridCookie = new HttpCookie("masterID", Convert.ToString(userid));
                        useridCookie.Expires = DateTime.Now.AddYears(1);
                        Response.AppendCookie(useridCookie);
                    }

                    try
                    {
                        string JsonIDs = dataRepository.getG_idlist(userid);
                        var IDCookie = new HttpCookie("IDList", JsonIDs);
                        IDCookie.Expires = DateTime.Now.AddYears(1);
                        Response.AppendCookie(IDCookie);

                        var GrantCookie = new HttpCookie("Granted", "True");
                        GrantCookie.Expires = DateTime.Now.AddYears(1);
                        Response.AppendCookie(GrantCookie);
                        //int userid = dataRepository.getID(guidnew);
                        var token = dataRepository.getG_refreshtoken(userid);
                        //saveG_refresh(tokenData.Refresh_Token);

                        Session["GoogleAPIToken"] = token;
                        var lat = dataRepository.getLat(userid);
                        var lng = dataRepository.getLng(userid);
                        SetCookie("lat", lat);
                        SetCookie("long", lng);

                        //get from db lat lng and set cookies

                        return RedirectToAction("Index");
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
                    string guid_str = Request.Cookies["GUID"].Value;
                    Guid guid = new Guid(guid_str);
                    var userid = dataRepository.getID(guid);
                    var refreshchk = dataRepository.getG_refreshtoken(userid);
                    if (refreshchk.Length > 5)
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
           // var approval_prompt = "force";
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
            var GrantCookie = new HttpCookie("GrantedG", "True");
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

        public void saveComment(string comment, int ArtID, string name)
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            var userid = dataRepository.getID(guid);
            dataRepository.saveComment(comment, userid, name, ArtID);

        }

        public void setDays2Go(string eventname, string eventdatetime, string eventid)
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            var userid = dataRepository.getID(guid);
            eventid = eventid.Split('=')[1];
            
            dataRepository.setDays2Go(eventname, eventdatetime, userid, eventid);

        }
         
        public ActionResult getComments(int ArtID)
        {

            var comments = from co in db.comments
                           where co.articleid == ArtID
                           orderby co.datetime descending
                           select new

                           {
                               commenttxt = co.comment1,
                               datetime = String.Format("{0:d/M/yyyy HH:mm:ss}", co.datetime),
                               name = co.name,
                               devicetxt = co.user.devices.First().UAmax,

                           };

            var num = comments.Count();
       
            return Json(new { Comments = comments, num = num}, JsonRequestBehavior.AllowGet);
             
        }

        public void removeDays2Go(int id)
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            var userid = dataRepository.getID(guid);
            dataRepository.delDays2Go(userid, id);
        }

        public ActionResult getDays2Go()
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            var userid = dataRepository.getID(guid);
            
            var days2go = from d in db.days2gos
                           where d.userid == userid 
                           //&& (Convert.ToInt64(d.eventdatetime) > Convert.ToInt64(DateTime.UtcNow))
                           orderby d.eventdatetime descending
                           select new
                           {
                               text = d.eventname,
                               days = formatDays2GoE(d.eventdatetime), //formatDays2Go(Convert.ToDateTime(d.eventdatetime)),
                               daystxt = formatDays2GoStrE(d.eventdatetime), //formatDays2GoStr(Convert.ToDateTime(d.eventdatetime)),
                               id = d.id,
                               //fulljson = getEventDetails(d.eventURL),
                               //name = co.name,
                               //devicetxt = co.user.devices.First().UAmax,

                           };

            var num = days2go.Count();

            return Json(new { Days2Go = days2go, num = num }, JsonRequestBehavior.AllowGet);

        }

        private ActionResult getEventDetails(string eventID)
        {
            //try session token first
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

            else //not saving token
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

            var accessToken = Session["GoogleAPIToken"];
            //Request.Cookies["CalToken"].Value;
            var email = "miriam.orchid@gmail.com";
            var urlBuilder2 = new System.Text.StringBuilder();
            urlBuilder2.Append("https://");
            urlBuilder2.Append("www.googleapis.com");
            urlBuilder2.Append("/calendar/v3/calendars/" + email + "/events");
            urlBuilder2.Append("/" + eventID);
            //updatedMin=2013-03-28T12%3A00%3A00.000%2B00%3A00");
            // urlBuilder.Append("&access_token=4/ZsN6Wn19QrcPbk6WarRGEIXSHaKO.QubFbrJ1OpsSOl05ti8ZT3ZDPtonfAI");
            var url = urlBuilder2.ToString();

            var httpWebRequest = HttpWebRequest.Create(urlBuilder2.ToString())
                as HttpWebRequest;
            //httpWebRequest.ContentType = "application/json ; charset=UTF-8";
            httpWebRequest.CookieContainer = new CookieContainer();
            httpWebRequest.Headers["Authorization"] =
                string.Format("Bearer {0}", accessToken);
            //try
            //{

                var responsec = httpWebRequest.GetResponse();
                var outj = responsec.ReadReponse();
                var outj2 = outj;
                //string textout = responsec.ReadReponse();
                var jsonS = new JavaScriptSerializer();
                var textout = jsonS.DeserializeObject(outj2);
                return Json(textout);

            //}
            //catch
            //{
              //  return Json(new { type = "refresh" });
            //}


          //  return View();
        }

        private string formatDays2GoStrE(string datetime)
        {
            System.TimeSpan timeDifference = DateTime.UtcNow -
           new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long unixEpochTime = System.Convert.ToInt64(timeDifference.TotalSeconds);

            var dt = Convert.ToInt64(datetime);
            Int64 diff = dt - unixEpochTime;
            int days2go = Convert.ToInt32(diff / 86400);
            var time_txt = "";


            if (Convert.ToInt32(days2go) == 0)  //less than 1 day to go
            {
                var hoursago = Convert.ToInt32(diff / 3600);
                time_txt = " hours until ";

                if (Convert.ToInt32(hoursago) < 1)
                {
                    var minsago = Convert.ToInt32(diff / 60);
                    time_txt = " minutes until ";

                    if (Convert.ToInt32(minsago) < 60)
                    {
                        var secsago = diff; //Convert.ToInt32(diff / 86400);
                        time_txt = " seconds until ";
                    }

                }

            }
            else
            {

                if (Convert.ToInt32(days2go) == 1)
                {
                    //var days2 = Convert.ToInt32(diff / 24);
                    time_txt = " Day until ";
                }
                else
                {
                    time_txt = " Days until ";
                }
            }
            return time_txt;
        }


        private string formatDays2GoE(string datetime)
        {
            //var now = Convert.ToInt64(DateTime.UtcNow);
            System.TimeSpan timeDifference = DateTime.UtcNow -
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long unixEpochTime = System.Convert.ToInt64(timeDifference.TotalSeconds);

            var dt = Convert.ToInt64(datetime);
            Int64 diff = dt - unixEpochTime;
            int days2go = Convert.ToInt32(diff / 86400);
            var time_txt = "";

            if (Convert.ToInt32(days2go) == 0)  //less than 1 day to go
            {
                var hoursago = Convert.ToInt32(diff / 3600);
                time_txt = hoursago + " ";

                if (Convert.ToInt32(hoursago) < 1)
                {
                    var minsago = Convert.ToInt32(diff / 60);
                    time_txt = minsago + " ";

                    if (Convert.ToInt32(minsago) < 1)
                    {
                        var secsago = diff; //Convert.ToInt32(diff / 86400);
                        time_txt = secsago + " ";
                    }

                }

            }

            if (Convert.ToInt32(days2go) > 0)
            {
                //var days2 = Convert.ToInt32(diff / 24);

                time_txt = days2go + " ";
            }


            return time_txt;
            
        }

        private string formatDays2Go(DateTime datetime)
        {
            DateTime now = DateTime.Now;
            int days2go = (datetime - now).Days + 1;
            var time_txt = "";

            if (Convert.ToInt32(days2go) == 0)  //less than 1 day to go
            {
                var hoursago = (datetime - now).Hours;
                time_txt = hoursago + " ";

                if (Convert.ToInt32(hoursago) < 1)
                {
                    var minsago = (datetime - now).Minutes;
                    time_txt = minsago  + " ";

                    if (Convert.ToInt32(minsago) < 1)
                    {
                        var secsago = (datetime - now).Seconds;
                        time_txt = secsago + " ";
                    }

                }

            }

            if (Convert.ToInt32(days2go) > 0)
            {
                var days2 = (datetime - now).Days + 1;

                time_txt = days2 + " ";
            }


            return time_txt;
        }


        public ActionResult getArticles()
        {
            var articles = from co in db.articles
                           orderby co.datetime descending
                           select new
           {
               //ImageUrl = tweet.Entities.,
               
               heading = co.heading,
               datetime = String.Format("{0:d/M/yyyy HH:mm:ss}", co.datetime),
               image = co.image,
               id = co.id,
               NumComments = co.comments.Count,
               arttext = co.article1
              // comments = 


             };

            return Json(new { Articles = articles}, JsonRequestBehavior.AllowGet);

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
                return "none";
            }

        }

        public void saveG_refresh(string value)
        {
            Guid guid = checkGUID();
            var userid = dataRepository.getID(guid);
            dataRepository.saveG_refresh(value, userid);

        }

        public void saveT_accesstoken(string value, int userid)
        {
            dataRepository.saveT_accesstoken(value, userid);
          
        }

        public void saveT_oauthtoken(string value, int userid)
        {
            dataRepository.saveT_oauthtoken(value, userid);
        }

        public void saveT_twid(string value, int userid)
        {
            dataRepository.saveT_twtid(value, userid);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetSitesInRange(string bounds)
        {        
            string[] boundsbits = bounds.Split(',');
            var latS = boundsbits[0];
            var longW = boundsbits[1];
            var latN = boundsbits[2];
            var longE = boundsbits[3];
            //var ct = 0;
            var numusers = (from pl in db.users
                            select pl).Count();
            var data = from pl in db.users
                       where (Convert.ToDecimal(pl.lat) >= Convert.ToDecimal(latS) && Convert.ToDecimal(pl.lat) <= Convert.ToDecimal(latN))
                       where (Convert.ToDecimal(pl.lng) >= Convert.ToDecimal(longW) && Convert.ToDecimal(pl.lng) <= Convert.ToDecimal(longE))
                       where pl.location != null
                      // orderby pl.Name descending
                       select new
                       {
                           lat = Convert.ToString(pl.lat),
                           longval = Convert.ToString(pl.lng),
                           google = (from s in db.ggls where s.userid == pl.id select s.idlist).Distinct().OrderBy(loc => loc).Count().ToString(), 
                           twitter = (from s in db.twts where s.userid == pl.id select s.twtid).Distinct().OrderBy(loc => loc).Count().ToString(),
                           last = Convert.ToString((from u in db.users where u.id == pl.id select u.lastlogin).First()),
                           place = (from u in db.users where u.id == pl.id select u.location).First(),
                           UID = pl.id,
                       };

            var ct = data.Count();

            return Json(new { points = data, ct = ct }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getAgents()
        {
           // var uniqueColors =
            //   (from dbo in database.MainTable
             //   where dbo.Property == true
             //   select dbo.Color.Name).Distinct().OrderBy(name => name);

            var kindles = (from s in db.devices where s.UAmax.Contains("kindle") select s.user.id).Distinct().OrderBy(name => name).Count().ToString();
            var iOS = (from s in db.devices where s.UAmax.Contains("Mac") select s.user.id).Distinct().OrderBy(name => name).Count().ToString();
            var windows = (from s in db.devices where s.UAmax.Contains("Windows") select s.user.id).Distinct().OrderBy(name => name).Count().ToString();
            var android = (from s in db.devices where s.UAmax.Contains("Android") select s.user.id).Distinct().OrderBy(name => name).Count().ToString();
            var locations = (from s in db.users select s.location).Distinct().OrderBy(loc => loc).Count().ToString();
            var twtr_usrs = (from s in db.twts select s.twtid).Distinct().OrderBy(loc => loc).Count().ToString();
            var ggl_usrs = (from s in db.ggls select s.idlist).Distinct().OrderBy(loc => loc).Count().ToString();
            var total = (from s in db.devices select s.user.id).Distinct().OrderBy(name => name).Count().ToString();
                      //TimeStamp = formatTimeStamp(tweet.CreatedAt.ToUniversalTime()),                  
            return Json(new { kindles = kindles, iOS = iOS, windows = windows, android = android, total = total, locations = locations, twtr_usrs = twtr_usrs, ggl_usrs = ggl_usrs }, JsonRequestBehavior.AllowGet);
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
                dataRepository.getID(guid);
                return guid;
            }

        }

        public void GoogleRefresh()
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

            else //not saving token
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

            //return RedirectToAction("Index");

        }

        public JsonResult saveLocation(string lat, string lng, string loc)
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            int userid = dataRepository.getID(guid);
            dataRepository.saveLocation(lat, lng, userid, loc);
            //SetCookie("lat", lat);
            //SetCookie("long", lng);
            //save cookie
            //RedirectToAction("Index_T");
            return Json(new { loc = loc }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult saveNewuser(int msg, int eve, int wea, string uname)
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            int userid = dataRepository.getID(guid);
            user newUser = new user();
            Guid Newguid = Guid.NewGuid();
            newUser.msg = msg;
            newUser.evnt = eve;
            newUser.weather = wea;
            newUser.guid = Newguid;
            newUser.uname = uname;
            newUser.parentID = userid;
            newUser.lastlogin = DateTime.Now;
            newUser.status = 1;
            int newUserID = dataRepository.saveNewuser(newUser);

            return Json(new { newID = newUserID, newguid = Newguid }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult viewDevices()
        {

            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            int userid = dataRepository.getID(guid);

            var devices = from d in db.users
                          where d.parentID == userid
                          select d;

            return View("ViewDevices", devices);

       //         var tophtml = "<ul data-role=\"listview\" data-inset=\"true\">"
         //              listhtml = listhtml + "<li><a href=\"ViewADevice?UserID=" + item.id + "\"><h2>" + item.uname + "</h2><p>Enabled</p>" +
           //        "<p class=\"ui-li-aside\">Last seen <strong>" + item.last + "</strong> ago</p></a></li>";
                     //  listhtml = listhtml + "<li><a href=\"ref\">" + item.uname + "</a><span class=\"ui-li-count\">" + item.last + "</span></li>";
             //      });
               //    $("#deviceList").html(tophtml + listhtml + "</ul>").trigger('create');
       
            /*
            var user_d = from s in db.users 
                          where s.parentID == userid
                          select s;

            return this.Json(
                      new
                      {
                          devices = (from obj in db.users
                                     where obj.parentID == userid && obj.status == 1
                                     orderby obj.lastlogin descending
                                     select new
                          { id = obj.id, 
                            uname = obj.uname,
                            msg = obj.msg,
                            evnt = obj.evnt,
                            guid = obj.guid,
                            last = formatTimeStamp(obj.lastlogin)

                          })
                      }
                      , JsonRequestBehavior.AllowGet
                   );
             * */

            //return Json(new { devices = user_d }, JsonRequestBehavior.AllowGet);
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
                var dtweet = twitterCtx.NewDirectMessage(tname,msg);
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
            try
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
            catch
            {
                return RedirectToAction("SetTwitterID");
            }
        }

        public void deleteUser(int id, int status)
        {
            dataRepository.delUser(id, status);


        }

        public ActionResult DeleteCookies(string type)
        {
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            int userid = dataRepository.getID(guid);
            if (type == "Twitter")
            {
                credentials.AccessToken = null;
                credentials.ConsumerKey = null;
                credentials.ConsumerSecret = null;
                credentials.OAuthToken = null;
                credentials.UserId = null;
                dataRepository.del_twt(userid);
            }

            if (type == "Google")
            {
                dataRepository.del_ggl(userid);
                Session["GoogleAPIToken"] = "";
                //SetCookie("Granted", "False");
                DelCookie("IDList", "");
            }

            if (type == "weather")
            {
                DelCookie("lat", "");
                DelCookie("long", "");
                DelCookie("day0", "");
                DelCookie("w_data", "");
                dataRepository.clearWeather(userid);
                //cycle thru others
                //day0 t0 7, icon 0 to 7, h11 to 3

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

        public ActionResult GetStarted()
        {
            //only seen by parent device
            var usertype = "";
            try
            {
                int userid = 0;
                string guid_str = Request.Cookies["GUID"].Value;
                Guid guid = new Guid(guid_str);

                if (dataRepository.checkGUIDzc(guid) == 1)
                {
                    userid = dataRepository.getUserid(guid, "master");
                    usertype = "parent";
                }

                if (dataRepository.checkGUIDzc(guid) == 2)
                {
                    userid = dataRepository.getUserid(guid, "child");
                    usertype = "child";
                }

                try
                {
                    var granted = Request.Cookies["GrantedT"].Value;
                    string tname1 = dataRepository.getT_twtid(userid);
                    ViewData["twitter"] = "<a href=\"#\" onclick=\"Auth(0,'Twitter')\" class=\"ui-btn ui-btn-b ui-corner-all\">Uauthenticate</a><div>Twitter authenticated for <strong>" + tname1 + ".</strong></div>";

                }
                catch
                {


                    string tname = dataRepository.getT_twtid(userid);
                    
                   
                    if (tname == null)
                    {
                        ViewData["twitter"] = "<a href=\"#\" onclick=\"Auth(1,'Twitter')\" class=\"ui-btn ui-btn-b ui-corner-all\">Authenticate</a><div>Allows OK fridge to read your tweets.</div>";
                    }
                    else
                    {
                        ViewData["twitter"] = "<a href=\"#\" onclick=\"Auth(1,'Twitter')\" class=\"ui-btn ui-btn-b ui-corner-all\">Re-authenticate</a><div>Please re-authenticate <strong>" + tname + ".</strong></div>";
                        //"<div class=\"button-wrap\"><button onclick=\"Auth(0,'Twitter')\" class=\"ui-shadow ui-btn ui-corner-all\">Unauthenticate</button></div>";
                        //<div>Twitter authenticated for <strong>" + tname + "</strong></div>";
                        //"<div class=\"button-wrap\"><button class=\"ui-shadow ui-btn ui-corner-all\">Button</button></div>";
                        //
                    }

                    //var userid = dataRepository.getID(guid);
                    
                }
            }
            catch
            {
                ViewData["twitter"] = "<a href=\"#\" onclick=\"Auth(1,'Twitter')\" class=\"ui-btn ui-btn-b ui-corner-all\">Authenticate</a><div>Allows Fridge Door to read your tweets.</div>";
            }


            try
            {

                int userid = 0;
                string guid_str = Request.Cookies["GUID"].Value;
                Guid guid = new Guid(guid_str);

                if (dataRepository.checkGUIDzc(guid) == 1)
                {
                    userid = dataRepository.getUserid(guid, "master");
                }

                if (dataRepository.checkGUIDzc(guid) == 2)
                {
                    userid = dataRepository.getUserid(guid, "child");

                }


                string JsonIDs = dataRepository.getG_idlist(dataRepository.getID(guid));
                JObject o = JObject.Parse(JsonIDs);
                // JArray items = (JArray)o["items"];
                var names = Convert.ToString(o["Fullname"]);

                var count = Convert.ToString(o["Count"]);
                int idcount = Convert.ToInt32(count);
                //string name = (string)o["kind"];
                var ids = names.Replace("[", "").Replace("]", "").Replace("\"", "");

                ViewData["google"] = "<a href=\"#\" onclick=\"Auth(0,'Google')\" class=\"ui-btn ui-btn-b ui-corner-all\">Unauthenticate</button></a><div>Google calendar authenticated for <strong>" + ids + ".</strong></div>";
            }
            catch
            {
                ViewData["google"] = "<a href=\"#\" onclick=\"Auth(1,'Google')\" class=\"ui-btn ui-btn-b ui-corner-all\">Authenticate</a><div>Allows OK fridge to read your Google calendar.</div>";
                //<button onclick=\"Auth(1,'Google')\" class=\"ui-btn ui-btn-b ui-corner-all\">Authenticate</button><div>Allows Fridge Door to read your Google calendar</div>";
            }

            try
            {

                int userid = 0;
                string guid_str = Request.Cookies["GUID"].Value;
                Guid guid = new Guid(guid_str);

                userid = dataRepository.getUserid(guid, "master");  //own userid for weather

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

            //return View("GetStarted");
        }

        public ActionResult AddDevice()
        {

            return View();
        }

        public ActionResult Events()
        {
            //read events config
            return View();
        }

        public ActionResult EventsSetup()
        {

            return View();
        }

        public ActionResult MsgSetup()
        {
            try
            {
                string tweets = Request.Cookies["tweets"].Value;
            }
            catch
            {

            }
           ViewData["msgradio"] = "<div id=\"msgdiv\">Select Twitter message type</div><fieldset data-role=\"controlgroup\" data-mini=\"true\" name=\"tweettypesmenu\" id=\"tweettypesmenu\">" +
     "<input type=\"radio\" name=\"radio-3\" id=\"radio-3e\" value=\"all\"><label for=\"radio-3e\">All</label><input type=\"radio\" name=\"radio-3\" id=\"radio-3f\" value=\"dm\">" +
    "<label for=\"radio-3f\">Direct Messages</label><input type=\"radio\" name=\"radio-3\" id=\"radio-3a\" value=\"my\"><label for=\"radio-3a\">My Tweets</label>" +
     "<input type=\"radio\" name=\"radio-3\" id=\"radio-3b\" value=\"fol\"><label for=\"radio-3b\">Following</label><input type=\"radio\" name=\"radio-3\" id=\"radio-3c\" value=\"men\">" +
    "<label for=\"radio-3c\">Mentions</label><input type=\"radio\" name=\"radio-3\" id=\"radio-3d\" value=\"okf\"><label for=\"radio-3d\">@okfridge</label>" +  
    "</fieldset><a href=\"#\" class=\"ui-btn ui-btn-c\" onclick=\"setMessages()\">Submit</a>";


            return View();
        }

        public ActionResult ListDevices(string msg)
        {
            if (msg == "new") {
                ViewData["msgbar"] = "<div class=\"ui-body ui-body-b ui-corner-all\">New device added successfully</div>";
            }

            if (msg == "del")
            {
                ViewData["msgbar"] = "<div class=\"ui-body ui-body-b ui-corner-all\">Device removed successfully</div>";
            }

            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            int userid = dataRepository.getID(guid);

            var devices = from d in db.users
                          where (d.parentID == userid && d.status >= 0)
                          select d;

            return View("ViewDevices", devices);


//            return View("ViewDevices");
        }

        public ActionResult ViewADevice(int UserID)
        {
              var top_html = "";
           var main_html = "";
           var msg_html = "";
           var events_html = "";
           var radio_html = "";
           var url = "";
           var end_html = "</div>";
            var w_html = "";
            var chk0 = "";
            var chk1 = "";
        var item = (from u in db.users
                   where u.id == UserID
                   select u).First();

                         if (item.msg == 0) {
                           msg_html = "No messaging";
                       } else if (item.msg == 1) {
                           msg_html = "Messaging: View only";
                       } else if (item.msg == 2) {
                           msg_html = "Messaging: View and Send";
                       } else {
                           msg_html = "Messaging: Advanced";
                       }
                       events_html = "No Events";
                       if (item.status == 1)
                       {
                           chk0 = "value=\"on\" checked=\"checked\">";
                           chk1 = "value=\"off\">";
                       }
                       else
                       {
                           chk1 = "value=\"on\" checked=\"checked\">";
                           chk0 = "value=\"off\">";
                       }
                       w_html = "Weather for ...";
                       url = "<a href=\"http://localhost:5010/mobile/indexc?zcguid=" + item.guid + "\">Link</a>";

                        main_html = main_html + "<ul data-role=\"listview\" data-inset=\"true\"><li data-role=\"list-divider\">" + item.uname +"</li>" +
                        "<li><h2>" + msg_html + "</h2></li><li><h2>" + events_html + "</h2></li><li><h2>" + w_html + "</h2></li><li>" +
                        "<div class=\"ui-grid-a ui-responsive\"><div class=\"ui-block-a\"><div>" +
                        "<a href=\"#\" class=\"ui-shadow ui-btn ui-corner-all ui-btn-inline ui-mini\">Copy link to Clipboard</a></div>" +
                        "<div><fieldset data-role=\"controlgroup\" data-type=\"horizontal\" data-mini=\"true\">" +

                        "<input onclick=\"deleteUser(" + item.id + ",1) \" type=\"radio\" name=\"radio-device-name-" + item.id + "\" id=\"radio-device-id-e" + item.id + "\" " + chk0 + "" +
                        "<label for=\"radio-device-id-e" + item.id + "\">Enabled</label>" +
                        "<input onclick=\"deleteUser(" + item.id + ",0) \" type=\"radio\" name=\"radio-device-name-" + item.id + "\" id=\"radio-device-id-d" + item.id + "\" " + chk1 + "" +
                        "<label for=\"radio-device-id-d" + item.id + "\">Disabled</label>" +
                        "</fieldset></div><a href=\"#\" class=\"ui-shadow ui-btn ui-corner-all ui-btn-inline ui-mini\" onclick=\"deleteUser(" + item.id + ",-1)\">Remove Device</a></div>" +
                        "<div class=\"ui-block-b\"><div id=\"chart-div" + item.id + "\"></div></div></div></li></ul>";


                //       main_html = main_html + "<div class=\"ui-corner-all custom-corners\"><div class=\"ui-bar ui-bar-a\"><h2>" + item.uname + "</h2></div><div class=\"ui-body ui-body-a\">" +
                //      "<ul data-role=\"listview\"><li>" + msg_html + "</li><li>" + events_html + "</li><li>" + w_html + "</li><li>Link: " + url + "</li><li><div class=\"ui-grid-a ui-responsive\">" +
                //      "<div class=\"ui-block-a\"><fieldset data-role=\"controlgroup\" data-type=\"horizontal\" data-mini=\"true\">" +
                //      "<input type=\"radio\" name=\"radio-device-name-" + item.id + "\" id=\"radio-device-id-e" + item.id + "\" value=\"on\" checked=\"checked\">" +
                //      "<label for=\"radio-device-id-e" + item.id + "\">Enabled</label>" +
                //      "<input type=\"radio\" name=\"radio-device-name-" + item.id + "\" id=\"radio-device-id-d" + item.id + "\" value=\"off\">" +
                //      "<label for=\"radio-device-id-d" + item.id + "\">Disabled</label>" +
                //      "</fieldset>" +
                //      "<div><a href=\"#\" class=\"ui-btn ui-mini\" onclick=\"deleteUser(" + item.id + ")\">Delete Device</a></div></div>" +
                 //     "<div class=\"ui-block-b\" style=\"text-align:center\" ><div id=\"chart-div" + item.id + "\"></div></div></div>";

            var html = "<div>" + main_html + end_html;
            ViewData["device"] = html;
            ViewData["deviceID"] = item.id;
            ViewData["deviceGUID"] = item.guid;
            return View();
        }

        public ActionResult SavedUser()
        {

            return View("SavedUser");
        }

        public ActionResult Messages()
        {
            var token1 = Session["GoogleAPIToken"];
            ViewData["token"] = token1;

            ViewData["uname"] = "Fridge    Last Updated: " + DateTime.Now;

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

            var latestid_out = "";

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
            try
            {
                var tweettypes = Request.Cookies["tweets"].Value;

                var tweetsout = (from tweet in twitterCtx.Status
                                 where tweet.Type == StatusType.User
                                 && tweet.Count == 5
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
                                     EntityUrl = GetTweetUrlEntities(tweet),
                                     saveBanner = dataRepository.saveBanner(userid, tweet.StatusID, tweettypes),
                                     doBanner = dataRepository.checkBanner(userid, tweet.StatusID),
                                 });

                if (tweettypes == "fol")
                {
                    tweetsout = (from tweet in twitterCtx.Status
                                 where tweet.Type == StatusType.Home
                                 && tweet.Count == 10
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
                                     EntityUrl = GetTweetUrlEntities(tweet),
                                     saveBanner = dataRepository.saveBanner(userid, tweet.StatusID, tweettypes),
                                     doBanner = dataRepository.checkBanner(userid, tweet.StatusID),
                                 });
                }

                if (tweettypes == "dm")
                {
                    tweetsout = (from tweet in twitterCtx.DirectMessage
                                 where tweet.Type == DirectMessageType.SentTo &&
                                   tweet.Count == 10
                                 orderby tweet.CreatedAt descending
                                 //&& tweet.Count == getnum
                                 // && tweet.SinceID == 397389362088132608
                                 select new TweetViewModel
                                 {
                                     ScreenName = tweet.SenderScreenName,
                                     TimeStamp = formatTimeStamp(tweet.CreatedAt.ToUniversalTime()),
                                     //Convert.ToString(tweet.CreatedAt.ToUniversalTime()),
                                     Tweet = tweet.Text,
                                     BannerText = "hi",
                                     //BannerTime = GetBannerTime(tweet.
                                     ImageUrl = tweet.Sender.ProfileImageUrl,
                                     //SinceID = tweet.SinceID,
                                     //Convert.ToString(tweet.Entities.MediaEntities.Count),
                                     //MediaUrl = GetTweetMediaUrl(tweet),
                                     //EntityUrl = GetTweetUrlEntities(tweet),
                                     saveBanner = dataRepository.saveBanner(userid, tweet.IDString, tweettypes),
                                     doBanner = dataRepository.checkBanner(userid, tweet.IDString),

                                 });
                }

                return View("Messages", tweetsout);
            }
            catch
            {

            }
            return RedirectToAction("MsgSetup");
        }


        public ActionResult Bday()
        {

            return View("Bday");
        }
	
	 public ActionResult TestView()
	{
	
	            return View("TestView");
        }

        public ActionResult JsonTweetStream(string timenow, int getnum, string tweettypes)
        {
            //radio butoon choice for tweet type: my, folow, okf, all
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

            Console.WriteLine("\nStreamed Content: \n");
            int count = 0;

            var newstream = "";

            (from strm in twitterCtx.Streaming
             where strm.Type == StreamingType.Filter && strm.Track == "twitter"
             select strm)
            .StreamingCallback(strm =>
            {


                if (strm.Status == TwitterErrorStatus.RequestProcessingException)
                {
                    Console.WriteLine(strm.Error.ToString());
                    return;
                }

                Console.WriteLine(strm.Content + "\n");
                newstream = newstream + strm.Content + "\n";

                if (count++ >= 10)
                {
                    strm.CloseStream();
                }
            })
            .SingleOrDefault();

            //newstream

            var screenName = "okfridge";

            var okfridge =
                (from tweet in twitterCtx.Status
                 where tweet.Type == StatusType.User
                       && tweet.ScreenName == screenName
                       && tweet.Count == getnum


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
                     EntityUrl = GetTweetUrlEntities(tweet),
                     doBanner = dataRepository.checkBanner(userid, tweet.StatusID),
                 });



            var mytweets =
                (from tweet in twitterCtx.Status
                 where tweet.Type == StatusType.User
                 && tweet.Count == getnum
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
                     EntityUrl = GetTweetUrlEntities(tweet),
                     doBanner = dataRepository.checkBanner(userid, tweet.StatusID),
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

            var bannerType = "";
            //if ((mytweets.First().BannerText.Length > 1)
            var BannerID = "";

            var topname = "";


            return Json(new { mytweets = newstream}, JsonRequestBehavior.AllowGet);
            //return Json("Index", friendTweets);

        }


        public ActionResult JsonTweets(string latestID, int getnum, string tweettypes)
        {
            //radio butoon choice for tweet type: my, folow, okf, all
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

            var latestid_out = "";

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
             && tweet.Count == getnum
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
                 EntityUrl = GetTweetUrlEntities(tweet),
                 doBanner = dataRepository.checkBanner(userid, tweet.StatusID),
             });

            var screenName = "okfridge";

            var okfridge =
                (from tweet in twitterCtx.Status
                where tweet.Type == StatusType.User
                      && tweet.ScreenName == screenName
                      && tweet.Count == getnum

          
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
                 EntityUrl = GetTweetUrlEntities(tweet),
                 doBanner = dataRepository.checkBanner(userid, tweet.StatusID),
             });


            var home =
            (from tweet in twitterCtx.Status
             where tweet.Type == StatusType.Home
             && tweet.Count == getnum
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
                 EntityUrl = GetTweetUrlEntities(tweet),
                 doBanner = dataRepository.checkBanner(userid, tweet.StatusID),
             });

            string DMsinceID = latestID;//"601471370199998464";
                            //610759388379410433
            var dm_new = 6;
                 //(from tweet in twitterCtx.DirectMessage
                  //   where tweet.Type == DirectMessageType.SentTo 
                       
                    //   && Convert.ToInt64(tweet.IDString) > Convert.ToInt64(DMsinceID)
                      //         select tweet).Count();

            var dm = (from tweet in twitterCtx.DirectMessage
                     where tweet.Type == DirectMessageType.SentTo &&
                       tweet.Count == getnum
                       orderby tweet.CreatedAt descending
                     //&& tweet.Count == getnum
                     // && tweet.SinceID == 397389362088132608
                     select new TweetViewModel
                     {
                         //ImageUrl = tweet.Entities.,
                         //ScreenName = tweet.SenderID,
                         TimeStamp = formatTimeStamp(tweet.CreatedAt.ToUniversalTime()),
                         //Convert.ToString(tweet.CreatedAt.ToUniversalTime()),
                         Tweet = tweet.Text,
                         //BannerText = GetBannerText(tweet),
                         //BannerTime = GetBannerTime(tweet),
                         ID = tweet.IDString,
                         //ImageUrl = tweet.User.ProfileImageUrl,
                         //SinceID = tweet.SinceID,
                         //Convert.ToString(tweet.Entities.MediaEntities.Count),
                         //MediaUrl = GetTweetMediaUrl(tweet),
                         //EntityUrl = GetTweetUrlEntities(tweet),
                         //saveLatestID = dataRepository.saveLatestTID(userid, tweet.IDString),
            
                     });

            dataRepository.saveLatestTID(userid, dm.Last().ID);
            latestid_out = dm.First().ID;

            var mytweets =
                (from tweet in twitterCtx.Status
                 where tweet.Type == StatusType.User
                 && tweet.Count == getnum
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
                     EntityUrl = GetTweetUrlEntities(tweet),
                     doBanner = dataRepository.checkBanner(userid, tweet.StatusID),
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
            
            
            //var latesttime = mytweets.First().TimeStamp;
            //var topBanner = GetBannerText(friendTweets.First())
           
            var bannerType = "";
            //if ((mytweets.First().BannerText.Length > 1)
            var BannerID = "";
            
            var topname = "";
 
                     
            return Json(new { mytweets = mytweets, dm = dm, dm_new = dm_new, okfridge = okfridge, home = home, getmore = getnum, topname = topname, mentions = mentions, latestid = latestid_out, bannerType = bannerType, twitterID = tname, BannerID = BannerID}, JsonRequestBehavior.AllowGet);
            //return Json("Index", friendTweets);

        }

        public ActionResult GetBanner(string ID, string invoke, string type)
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

            if (type == "home")
            {
                var friendTweets =
                    (from tweet in twitterCtx.Status
                     where tweet.Type == StatusType.Home
                     && tweet.StatusID == ID
                     && tweet.Count == 1
                     select new TweetViewModel
                     {
                         TwitterID = tweet.User.Name,
                         ScreenName = tweet.StatusID,
                         BannerText = GetBannerText(tweet),
                         BannerTime = GetBannerTime(tweet),
                     });

                var oauthToken = auth.Credentials.OAuthToken;
                var oauthAccessT = auth.Credentials.AccessToken;
                var userd = auth.Credentials.ScreenName + " " + auth.Credentials.UserId;
                ViewData["authdeets"] = oauthAccessT;
                //var latestid = friendTweets.First().ID;
                //var banner = friendTweets.First().BannerText; 
                int banchk = dataRepository.checkBanner(Convert.ToInt32(userid), ID);
                if (banchk == 0 || invoke == "click")
                {
                    dataRepository.saveBanner(Convert.ToInt32(userid), ID, friendTweets.First().BannerText);
                    return Json(new { doBanner = "true", bannerDeets = friendTweets }, JsonRequestBehavior.AllowGet);
                    //return friendtweets and extract text in javascript
                }
                else
                {
                    return Json(new { doBanner = "false" }, JsonRequestBehavior.AllowGet);
                }

            }

            if (type == "my")
            {
                var friendTweets =

                    (from tweet in twitterCtx.Status
                     where tweet.Type == StatusType.User
                     && tweet.StatusID == ID
  //                   && tweet.Count == 1
                     select new TweetViewModel
                     {
                         TwitterID = tweet.User.Name,
                         ScreenName = tweet.StatusID,
                         BannerText = GetBannerText(tweet),
                         BannerTime = GetBannerTime(tweet),
                     });

                var oauthToken = auth.Credentials.OAuthToken;
                var oauthAccessT = auth.Credentials.AccessToken;
                var userd = auth.Credentials.ScreenName + " " + auth.Credentials.UserId;
                ViewData["authdeets"] = oauthAccessT;
                //var latestid = friendTweets.First().ID;
                //
                
                var banner = friendTweets.First().BannerText; 
                int banchk = dataRepository.checkBanner(Convert.ToInt32(userid), ID);
                if (banchk == 0 || invoke == "click")
                {
                    dataRepository.saveBanner(Convert.ToInt32(userid), ID, friendTweets.First().BannerText);
                    return Json(new { doBanner = "true", bannerDeets = friendTweets }, JsonRequestBehavior.AllowGet);
                    //return friendtweets and extract text in javascript
                }
                else
                {
                    return Json(new { doBanner = "false" }, JsonRequestBehavior.AllowGet);
                }

            }

            if (type == "mentions")
            {
                var friendTweets =
                    (from tweet in twitterCtx.Status
                     where tweet.Type == StatusType.Mentions
                     && tweet.StatusID == ID
                     && tweet.Count == 1
                     select new TweetViewModel
                     {
                         TwitterID = tweet.User.Name,
                         ScreenName = tweet.StatusID,
                         BannerText = GetBannerText(tweet),
                         BannerTime = GetBannerTime(tweet),
                     });

                var oauthToken = auth.Credentials.OAuthToken;
                var oauthAccessT = auth.Credentials.AccessToken;
                var userd = auth.Credentials.ScreenName + " " + auth.Credentials.UserId;
                ViewData["authdeets"] = oauthAccessT;
                //var latestid = friendTweets.First().ID;
                //var banner = friendTweets.First().BannerText; 
                int banchk = dataRepository.checkBanner(Convert.ToInt32(userid), ID);
                if (banchk == 0 || invoke == "click")
                {
                    dataRepository.saveBanner(Convert.ToInt32(userid), ID, friendTweets.First().BannerText);
                    return Json(new { doBanner = "true", bannerDeets = friendTweets }, JsonRequestBehavior.AllowGet);
                    //return friendtweets and extract text in javascript
                }
                else
                {
                    return Json(new { doBanner = "false" }, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                //okf
                var screenName = "okfridge";

                var okfridge =
                    (from tweet in twitterCtx.Status
                     where tweet.Type == StatusType.User
                           && tweet.ScreenName == screenName
                           && tweet.StatusID == ID
                            //&& tweet.Count == 1
                     select new TweetViewModel
                     {
                         TwitterID = tweet.User.Name,
                         ScreenName = tweet.StatusID,
                         BannerText = GetBannerText(tweet),
                         BannerTime = GetBannerTime(tweet),

                     });
                var oauthToken = auth.Credentials.OAuthToken;
                var oauthAccessT = auth.Credentials.AccessToken;
                var userd = auth.Credentials.ScreenName + " " + auth.Credentials.UserId;
                ViewData["authdeets"] = oauthAccessT;
                //var latestid = friendTweets.First().ID;
                var banner = okfridge.First().BannerText; 
                int banchk = dataRepository.checkBanner(Convert.ToInt32(userid), ID);
                if (banchk == 0 || invoke == "click")
                {
                    dataRepository.saveBanner(Convert.ToInt32(userid), ID, okfridge.First().BannerText);
                    return Json(new { doBanner = "true", bannerDeets = okfridge }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { doBanner = "false" }, JsonRequestBehavior.AllowGet);
                }
            }
            
        }

        public ActionResult GetTweet(string ID, string type)
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

            if (type == "mentions")
            {
                var friendTweets =
                    (from tweet in twitterCtx.Status
                     where tweet.Type == StatusType.Mentions
                     && tweet.StatusID == ID
                     && tweet.Count == 1
                     select new TweetViewModel
                     {
                         TwitterID = tweet.User.Name,
                         ScreenName = tweet.StatusID,
                         TimeStamp = formatTimeStamp(tweet.CreatedAt.ToUniversalTime()),
                         Tweet = tweet.Text,
                         ImageUrl = tweet.User.ProfileImageUrl,
                         MediaUrl = GetTweetMediaUrl(tweet),
                         EntityUrl = GetTweetUrlEntities(tweet),
                     });

                var oauthToken = auth.Credentials.OAuthToken;
                var oauthAccessT = auth.Credentials.AccessToken;
                var userd = auth.Credentials.ScreenName + " " + auth.Credentials.UserId;
                ViewData["authdeets"] = oauthAccessT;
                //var latestid = friendTweets.First().ID;
                //var banner = friendTweets.First().BannerText; 
                return Json(new { tweetDeets = friendTweets }, JsonRequestBehavior.AllowGet);
                
            }
            else if (type == "my")
            {

                var friendTweets =
                    (from tweet in twitterCtx.Status
                     where (tweet.Type == StatusType.User)
                     && tweet.StatusID == ID
                     //&& tweet.Count == 1
                     select new TweetViewModel
                     {
                         TwitterID = tweet.User.Name,
                         ScreenName = tweet.StatusID,
                         TimeStamp = formatTimeStamp(tweet.CreatedAt.ToUniversalTime()),
                         Tweet = tweet.Text,
                         ImageUrl = tweet.User.ProfileImageUrl,
                         MediaUrl = GetTweetMediaUrl(tweet),
                         EntityUrl = GetTweetUrlEntities(tweet),
                     });
                var oauthToken = auth.Credentials.OAuthToken;
                var oauthAccessT = auth.Credentials.AccessToken;
                var userd = auth.Credentials.ScreenName + " " + auth.Credentials.UserId;
                ViewData["authdeets"] = oauthAccessT;

                return Json(new { tweetDeets = friendTweets }, JsonRequestBehavior.AllowGet);

            }

            else if (type == "home")
            {

                var friendTweets =
                    (from tweet in twitterCtx.Status
                     where (tweet.Type == StatusType.Home)
                     && tweet.StatusID == ID
                     //&& tweet.Count == 1
                     select new TweetViewModel
                     {
                         TwitterID = tweet.User.Name,
                         ScreenName = tweet.StatusID,
                         TimeStamp = formatTimeStamp(tweet.CreatedAt.ToUniversalTime()),
                         Tweet = tweet.Text,
                         ImageUrl = tweet.User.ProfileImageUrl,
                         MediaUrl = GetTweetMediaUrl(tweet),
                         EntityUrl = GetTweetUrlEntities(tweet),                
                     });
                var oauthToken = auth.Credentials.OAuthToken;
                var oauthAccessT = auth.Credentials.AccessToken;
                var userd = auth.Credentials.ScreenName + " " + auth.Credentials.UserId;
                ViewData["authdeets"] = oauthAccessT;

                return Json(new { tweetDeets = friendTweets }, JsonRequestBehavior.AllowGet);

            }

            else
            {
                //okf
                var screenName = "okfridge";

                var okfridge =
                    (from tweet in twitterCtx.Status
                     where tweet.Type == StatusType.User
                           && tweet.ScreenName == screenName
                           && tweet.StatusID == ID
                         //&& tweet.Count == 1
                           
                     select new TweetViewModel
                     {
                         TwitterID = tweet.User.Name,
                         ScreenName = tweet.StatusID,
                         TimeStamp = formatTimeStamp(tweet.CreatedAt.ToUniversalTime()),
                         Tweet = tweet.Text,
                         ImageUrl = tweet.User.ProfileImageUrl,
                         MediaUrl = GetTweetMediaUrl(tweet),
                         EntityUrl = GetTweetUrlEntities(tweet),
                     });
                var oauthToken = auth.Credentials.OAuthToken;
                var oauthAccessT = auth.Credentials.AccessToken;
                var userd = auth.Credentials.ScreenName + " " + auth.Credentials.UserId;
                ViewData["authdeets"] = oauthAccessT;
                //var tweetch = okfridge.First().Tweet;
                return Json(new { tweetDeets = okfridge }, JsonRequestBehavior.AllowGet);

            }
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
            var banner = status.Text;
            //var bantxt = getBetween(tweet_txt, "#banner");
            var strStart = GetBannerTimeStr(banner);
            int timeframe = Convert.ToInt32(strStart);
            if (timeframe > 0)
            {
                var timetxt = GetBannerTimeFromStr(banner);
                //is a number, remove  
                int Start, End, end2;
                Start = banner.IndexOf(timetxt, 0) + timetxt.Length;
                End = banner.Length;
                end2 = End - Start - 1;
                //var banneronly = banner.Substring(Start + 1, End - (Start - 5));
                var banneronly = banner.Substring(Start + 1, end2);
                return banneronly;
            }
            else
            {
                //no time specified, do not remove anything
                var bantxt = getBetween(banner, "#okbnnr");

                return bantxt;
            }
         
            
        }
        //#banner
        //#okbnnr
        private string GetBannerTimeStr(String tweet_txt)
        {
            //var tweet_txt = status.Text;
            int tfstart = tweet_txt.IndexOf("#okbnnr", 0) + 8;
            if (tfstart >= 8)
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

                        return null;

                    }
                    //return Convert.ToString(timeval + timeframe);

                }
                catch
                {

                    return null;
                }
            }
            else
            {

                return null;

            }

            //return "10000";
        }

        private string GetBannerTimeFromStr(String tweet_txt)
        {
            //var tweet_txt = status.Text;
            int tfstart = tweet_txt.IndexOf("#okbnnr", 0) + 8;
            if (tfstart >= 8)
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
                    return Convert.ToString(timeval + timeframe);

                    //return Convert.ToString(timeval + timeframe);

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

  

        private string GetBannerTime(Status status)
        {
            var tweet_txt = status.Text;
            int tfstart = tweet_txt.IndexOf("#okbnnr", 0) + 8;
            if (tfstart >= 8)
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

        private string GetBannerTimeStr2(String tweet_txt)
        {
            //var tweet_txt = status.Text;
            int tfstart = tweet_txt.IndexOf("#okbnnr", 0) + 8;
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
                    return Convert.ToString(timeval + timeframe);

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
            //getBetween(tweet_txt, "#banner");
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

        public ActionResult SendTweet()
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
                string status = "hihi " + DateTime.Now;
                // var tweetnew = twitterCtx.UpdateStatus(status);
                var dtweet = twitterCtx.NewDirectMessage(tname,msg);
                var oauthToken = auth.Credentials.OAuthToken;
                var oauthAccessT = auth.Credentials.AccessToken;
                var userd = auth.Credentials.ScreenName + " " + auth.Credentials.UserId;
                //http://localhost:5010/?oauth_token=9IWia8yWenYytqosbErCRno7KcJPr55fMXHvqJkoY&oauth_verifier=g6pbTya6OOcsH2O0f3PuzQKUtCQBz1lQBz0BmnixHU
                ViewData["authdeets"] = oauthAccessT;
                //Auth: oauthtoken=1317302059-F57J7rhJw18BYymjoZ5nJGqwhKd0nqax3jaItN5 id=FletcherFridge 1317302059 oathaccesstoken= v3g3lcENHnDPNNYTpSLLZZtZmCJ43bnvohLlDnNg7w
                //+ save id first time.
                //return View("IndexTest", friendTweets);
                return Json(new { sent = "done" }, JsonRequestBehavior.AllowGet);
          

            }
            catch
            {
                return Json(new { sent = "failed" }, JsonRequestBehavior.AllowGet);
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
            var userid = 0;
            
            string guid_str = Request.Cookies["GUID"].Value;
            Guid guid = new Guid(guid_str);
            userid = dataRepository.getID(guid);
           

            //have userid
            saveT_accesstoken(accesstoken,userid);
            saveT_oauthtoken(oauthtoken,userid);
            saveT_twid(twitterID,userid);

            //SetCookie("oauth_accessToken", accesstoken);
            //SetCookie("oauth_oauthToken", oauthtoken);
            SetCookie("GrantedT", "True");
           // SetCookie("tweets", "dm");

           // return RedirectToAction("AuthTwitter");
            return RedirectToAction("GetStarted");


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
