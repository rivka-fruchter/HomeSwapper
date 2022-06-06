using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Bll;
using Dto;
namespace full_project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //קונטרולר כניסה
    public class signInController : ApiController
    {
        // GET: api/signIn
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/signIn/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/signIn
        //בדיקת תקינות סיסמא ושם משתמש
        public int Post(userDto value)
        {
            if (value.userName == null&&value.userPassword==null)
                return 0;
            return db.checkUser(value);
        }

        // PUT: api/signIn/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/signIn/5
        public void Delete(int id)
        {
        }
    }
}
