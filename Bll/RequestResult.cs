using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    [Serializable]
    //מחלקת עזר שמחזירה תשובה בקונטרולרים
    public class RequestResult
    {
        public Object Data { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
