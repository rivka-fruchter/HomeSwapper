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
    //
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class apartmentController : ApiController
    {
        // GET: api/apartment
        //קבלת כל הדירות
        public object Get()
        {
            var res = db.getAllApartment();
            return res.Data;
        }

        // GET: api/apartment/5
        //לכאן מגיע קוד משפחה של המשתמש
        //מחזיר את כל הפרטים של משתמש דירה ומשפחה
        public RequseApartment Get(int id)
        {
            return db.getAll(id);
        }

        // POST: api/apartment הוספה
        [HttpPost]
        public int Post(RequseApartment o)
        {
            //אם הגיע לפה זה אומר שהוא משתמש חדש
            //הדירה
            apartmentDto apartment = o.apartment;
            //מערך הפרמטרים של הדירה
            int[] parameteArr = o.parameterArr;
            //משפחה
            familyDto family = o.family;
            //אילוצי משפחה
            familyConstDto familyConst = o.familyConst;
            //מערך פרמטרים של משפחה
            int[] familParameterArr = o.familyParameter;
            //הוספת הדירה למסד וקבלת קוד הדירה שנמצא במסד
            int apartCode;
            apartCode = db.AddApartment(apartment); ;
            //פרמטרים שמשפחה רוצה
            //הוספת המשפחה למסד
            family.apartmentCode = apartCode;
            int familyCode = db.AddFamily(family);
            familyConst.familyCode = familyCode;
            int constCode = db.AddFamilyConst(familyConst);
            //הוספת המשתמש לטבלת המשתמשים
            o.user.apartmentCode = apartCode;
            o.user.familyCode = familyCode;
            db.addUser(o.user);
            //הוספת הפרמטרים לדירה 
            db.AddParametrApartment(parameteArr, apartCode);
            //הוספת פרמטרים למשפחה
            db.AddFamilyParameter(familParameterArr, constCode);
            return apartCode;
        }
        //עדכון
        // PUT: api/apartment/5
        public void Put(int id, RequseApartment value)
        {
            db.updateApartment(value.apartment);
            db.updateParameterApart(value.parameterArr, value.apartment.apartcode);
        }

        // DELETE: api/apartment/5
        public void Delete(int code)
        {
            var x = code;
        }
        [HttpPost]
        [Route("api/apartment/deleteA")]
        public void deleteA([FromBody] d d1)
        {
            var x = d1.code;
            //לקבל מחלקה

        }
    }
}
public class d
{
    public int code { get; set; }
    public d()
    {

    }
}