using System.Collections.Generic;
using Dto;
namespace Bll
{
    //צומת מסוג משפחה
    public class familyVertex:vertex
    {
        //פרטי משפחה
        public familyDto f { get; set; }
        //נתונים בסיסים שהיא רוצה בדירה
        public familyConstDto familyConst { get; set; }
        //פרמטרים שהמשפחה רוצה 
        public List<familyParmeterDto> familyParameter { get; set; }     
        //אחוזי ההתאמה לדירה
        public double precent { get; set; }
        public familyVertex()
        {
            //אתחול
            familyParameter = new List<familyParmeterDto>();
        }
    }
}
