using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Bll;
namespace full_project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class parameterController : ApiController
    {
        // GET: api/parameter
        public object Get()
        {
            var res = db.getAllparameter();
            return res.Data;
        }

        // GET: api/parameter/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/parameter
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/parameter/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/parameter/5
        public void Delete(int id)
        {
        }
    }
}
