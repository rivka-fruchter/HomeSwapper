
using System.Web.Http;
using Bll;
namespace full_project.Controllers
{
    //קונטרולר של פרמטרים
    public class apartParameterController : ApiController
    {
        // GET: api/apartParameter
        //קבלת כל הפרמטרים
        public object Get()
        {
            var res = db.getAllApartParameter();
            return res.Data;
        }

        // GET: api/apartParameter/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/apartParameter
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/apartParameter/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/apartParameter/5
        public void Delete(int id)
        {
        }
    }
}
