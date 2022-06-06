using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bll;
namespace full_project.Controllers
{
    //קונטרולר של אילוצי משפחה
    public class familyConstraintController : ApiController
    {
        // GET: api/familyConstraint
        //קבלת כל האילוצים
        public object Get()
        {
            var res = db.getAllFamilyConst();
            return res.Data;
        }

        // GET: api/familyConstraint/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/familyConstraint
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/familyConstraint/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/familyConstraint/5
        public void Delete(int id)
        {
        }
    }
}
