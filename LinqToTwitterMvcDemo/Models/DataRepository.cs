using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using LinqToTwitterMvcDemo.Models;
using System.IO;


namespace LinqToTwitterMvcDemo.Models
{
    public class DataRepository
    {
        private fddbDataContext db = new fddbDataContext();

        public int checkUserTwt(int userid)
        {
            var user = (from u in db.twts
                        where (u.userid == userid && u.status > 0)
                     select u).Count();
            return user;
        }

        public string getLatLng(int userid)
        {
            var user = from u in db.users
                        where (u.id == userid)
                        select u;
            var latlng = user.First().lat + "," + user.First().lng;
            return latlng;
        }

        public string getLocation(int userid)
        {
            var user = from u in db.users
                       where (u.id == userid)
                       select u;
            var loc = user.First().location;
            return loc;
        }


        public int checkUserGgl(int userid)
        {
            var user = (from u in db.ggls
                        where (u.userid == userid && u.status > 0)
                        select u).Count();
            return user;
        }

        public void saveG_refresh(string value, int userid)
        {
            if (checkUserGgl(userid) == 0)
            {
                ggl g = new ggl();
                g.refreshtoken = value;
                g.userid = userid;
                g.status = 1;
                db.ggls.InsertOnSubmit(g);
                db.SubmitChanges();
            }
            else
            {
                var g = db.ggls
                  .Where(u => u.userid == userid && u.status > 0)
                    .First();

                g.refreshtoken = value;
                db.SubmitChanges();
            }
        }

        public void saveG_idlist(string value, int userid)
        {
            if (checkUserGgl(userid) == 0)
            {
                ggl g = new ggl();
                g.idlist = value;
                g.userid = userid;
                g.status = 1;
                db.ggls.InsertOnSubmit(g);
                db.SubmitChanges();
            }
            else
            {
                var g = db.ggls
                  .Where(u => u.userid == userid && u.status > 0)
                  .First();

                g.idlist = value;
                db.SubmitChanges();
            }

        }

      

        public void saveUseragent(string useragent, int userid, string UAmax)
        {

            device d = new device();
            d.userid = userid;
            d.useragent = useragent;
            d.lastlogin = DateTime.Now;
            d.UAmax = UAmax;
            db.devices.InsertOnSubmit(d);
            db.SubmitChanges();

        }

        public void saveLocation(string lat, string lng, int userid, string location)
        {

            var users = db.users
                  .Where(u => u.id == userid)
                  .First();

            users.lat = lat;
            users.lng = lng;
            users.location = location;
           // db.users.InsertOnSubmit(users);
            db.SubmitChanges();

        }

        public void saveT_accesstoken(string value, int userid)
        {
            if (checkUserTwt(userid) == 0)
            {
                twt t = new twt();
                t.accesstoken = value;
                t.userid = userid;
                t.status = 1;
                db.twts.InsertOnSubmit(t);
                db.SubmitChanges();
            }
            else
            {
                var t = db.twts
                  .Where(u => u.userid == userid && u.status > 0)
                    .First();

                t.accesstoken = value;
                db.SubmitChanges();
            }

        }

        public void saveT_oauthtoken(string value, int userid)
        {
            if (checkUserTwt(userid) == 0)
            {
                twt t = new twt();
                t.oauthtoken = value;
                t.userid = userid;
                t.status = 1;
                db.twts.InsertOnSubmit(t);
                db.SubmitChanges();
            }
            else
            {
                var t = db.twts
                  .Where(u => u.userid == userid && u.status > 0)
                    .First();

                t.oauthtoken = value;
                db.SubmitChanges();
            }

        }

        public void del_twt(int userid)
        {
            var t = db.twts
                 .Where(u => u.userid == userid && u.status == 1)
                 .First();

            t.status = 0;
            db.SubmitChanges();
            
        }

        public void del_ggl(int userid)
        {
            var t = db.ggls
                 .Where(u => u.userid == userid && u.status == 1)
                 .First();

            t.status = 0;
            db.SubmitChanges();

        }

        public void saveT_twtid(string value, int userid)
        {
            if (checkUserTwt(userid) == 0)
            {
                twt t = new twt();
                t.twtid = value;
                t.userid = userid;
                t.status = 1;
                db.twts.InsertOnSubmit(t);
                db.SubmitChanges();
            }
            else
            {
                var t = db.twts
                  .Where(u => u.userid == userid && u.status > 0)
                    .First();

                t.twtid = value;
                db.SubmitChanges();
            }

        }

        public void updateUser(int userID)
        {

            //var user = db.Users
              //  .Where(u => u.UserID == userID)
            //    .First();

            //user.Timestamp = DateTime.Now;
            //db.SubmitChanges();

        }

        public void MovePlace(string latval, string longval, int PID)
        {
           // var place = db.places
          //      .Where(p => p.PID == PID)
         //       .First();

           // place.LatVal = Convert.ToDecimal(latval);
           // place.LongVal = Convert.ToDecimal(longval);
           // db.SubmitChanges();

        }


        public string getT_accesstoken(int userid)
        {
            var item = (from u in db.twts
                        where (u.userid == userid && u.status > 0)
                          select u).First();

            return item.accesstoken;
        }

        public string getT_oauthtoken(int userid)
        {
            var item = (from u in db.twts
                        where (u.userid == userid && u.status > 0)
                        select u).First();

            return item.oauthtoken;
        }

        public string getT_twtid(int userid)
        {
            try
            {
                var item = (from u in db.twts
                            where (u.userid == userid && u.status > 0)
                            select u).First();

                return item.twtid;
            }
            catch
            {
                return null;
            }
        }

        public string getG_idlist(int userid)
        {
            var item = (from u in db.ggls
                        where (u.userid == userid && u.status > 0)
                        select u).First();

            return item.idlist;
        }

        public string getG_refreshtoken(int userid)
        {
            var item = (from u in db.ggls
                        where (u.userid == userid && u.status > 0)
                        select u).First();

            return item.refreshtoken;
        }

        public int getID(Guid guid)
        {
            try {
                var userID = (from u in db.users
                         where (u.guid == guid)
                         select u).First().id;

                return userID;

            } 
            catch
            {
                user user = new user();
                user.guid = guid;
                user.lastlogin = DateTime.Now;
                db.users.InsertOnSubmit(user);
                db.SubmitChanges();
                return user.id;
            }
               
           

           

        }

      
    }
}