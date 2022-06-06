using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bll;
using System.Web.Http.Cors;

namespace full_project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //קןנטרולר של ערים
    public class cityController : ApiController
    {
        // GET: api/city
        //קבלת כל הערים
        public object Get()
        {
            var res = db.getAllCity();
            return res.Data;
        }

        // GET: api/city/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/city
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/city/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/city/5
        public void Delete(int id)
        {
        }
    }
}
