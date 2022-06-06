using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Bll.algorithm;
using Bll;
namespace full_project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //קונטרולר ראשי ממנו מופעל אלגוריתם השיבוץ
    public class mainController : ApiController
    {
        algo1 algo = new algo1();
        // GET: api/main
        //מכאן אני מפעילה את האלגוריתם
        public RequestResult Get()
        {
            //
            List<int> notCorss = algo.mainFunction();
            
            //שליחת מייל למשפחות שהשתבצו
            List<EzerPlacment> emailCross = (List<EzerPlacment>)db.getLastPlacment().Data;
            foreach (var item in emailCross)
            {
                string m = string.Format("שלום משפחת {0} החלפתם דירה עם משפחת {1} בכתובת {2} תבלו ותהנו!!!!", item.familyName, item.switchWith, item.familyAdress);
                sendEmail e = new sendEmail(item.familyEmail, m);
                e.send();
            }
            if(notCorss==null)
                return new RequestResult() { Data = 'a', Status = true };
            List<string[]> emailNotCross = db.getAllEmail(notCorss);

            //שליחת מילים למי שלא השתבץ
            foreach (var item in emailNotCross)
            {
                string m = string.Format("שלום משפחת {0} לצערנו לא נמצאה דירה עבורכם, אולי בשיבוץ הבא......", item[1]);
                sendEmail e = new sendEmail(item[0], m);
                e.send();
            }
            return new RequestResult() { Data = 'a', Status = true };
        }

        // GET: api/main/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/main
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/main/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/main/5
        public void Delete(int id)
        {
        }
    }
}
