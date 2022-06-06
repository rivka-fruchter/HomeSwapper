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
    //קונטרולר השיבוץ
    public class placmentController : ApiController
    {
        // GET: api/placment
        //קבלת כל השיבוצים האחרונים
        public List<EzerPlacment> Get()
        {
            var res = db.getLastPlacment();
            //אם אין לו שיבוצים אחרונים
            if (res == null)
                return null;
            return (List<EzerPlacment>)res.Data;
        }

        // GET: api/placment/5
        //קבלת שיבוץ אחרון למשפחה בודדת
        public List<EzerPlacment> Get(int id)
        {
            var res = db.getLastPlacmentUser(id);
            //אם אין לו שיבוצים אחרונים
            if (res == null)
                return null;
            return (List<EzerPlacment>)res.Data;
        }

        // POST: api/placment
        //ריקון טבלת השיבוץ
        public void Post()
        {
            db.deletePlacment();
        }

        // PUT: api/placment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/placment/5
        public void Delete(int id)
        {
        }
    }
}
