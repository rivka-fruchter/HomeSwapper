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
    //קונטרולר של משפחה
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class familyController : ApiController
    {
        // GET: api/family
        //קבלת כל המשפחות
        public object Get()
        {
             var res = db.getAllFamily();
            return res.Data;
        }

        // GET: api/family/5
        //לכאן מגיע קוד משפחה של המשתמש
        //קבלת כל פרטים של המשפחה כמו דירה וזה
        public RequseApartment Get(int id)
        {
            return db.getAll(id);
        }

        // POST: api/family
        public void Post([FromBody]string value)
        {
        }
        //עדכון משפחה וכל מה שקשור אליה
        // PUT: api/family/5
        public void Put(int id, [FromBody]RequseApartment value)
        {
            db.updateFamily(value.family.familyCode, value.family);
            db.updateFamilyConst(value.family.familyCode, value.familyConst);
            db.updateParameterFamily(value.familyParameter, value.familyConst.constCode);
        }

        // DELETE: api/family/5
        public void Delete(int id)
        {
        }
    }
}
