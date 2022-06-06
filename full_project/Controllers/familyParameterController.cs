using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bll;
namespace full_project.Controllers
{
    //קונטרולר של פרמטרים למשפחה
    public class familyParameterController : ApiController
    {
        // GET: api/familyParameter
        //קבלת כל פרמטרים של משפחה
        public object Get()
        {
            var res = db.getAllFamilyParameter();
            return res.Data;
        }

        // GET: api/familyParameter/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/familyParameter
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/familyParameter/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/familyParameter/5
        public void Delete(int id)
        {
        }
    }
}
