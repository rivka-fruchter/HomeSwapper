using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Dto;
using Bll;
namespace full_project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class detailsController : ApiController
    {
        // GET: api/details
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET: api/details/5
        //כאן מגיע משתמש משובץ שרוצה לדעת את כל הפרטים על הדירה שלו
        public details Get(int id)
        {
            details d = new details();
            d.apart = db.getApartment(id);
            d.param = db.findApartParameter(id);
            return d;
        }

        // POST: api/details
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/details/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/details/5
        public void Delete(int id)
        {
        }
    }
}
public class details
{
    public apartmentDto apart { get; set; }
    public List<string> param { get; set; }
}