
using System.Web.Http;
using System.Web.Http.Cors;

using Bll;
namespace full_project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //קונטרולר של משתמש
    public class userController : ApiController
    {
        // GET: api/user
        //קבלת כל המשתמשים
        public object Get()
        {
            var res = db.getAllUser();
            return res.Data;
        }

        // GET: api/user/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/user
        //משמש בתור מחיקת משתמש
        public int Post(deleteUser u)
        {
           return db.deleteUser(u.familyCode);
        }

        // PUT: api/user/5
        public void Put(int value)
        {
        }

        // DELETE: api/user/5
        public void Delete()
        {

        }
    }
}
public class deleteUser
{
    public int familyCode { get; set; }
    public deleteUser()
    {

    }
}