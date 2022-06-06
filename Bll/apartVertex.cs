
using System.Collections.Generic;
using Dto;
namespace Bll
{   //צומת בגרף מסוג דירה
    public class apartVertex:vertex
    {
        //פרטי דירה
        public apartmentDto a { get; set; }
        //פרמטרים שנמצאים בדירה
        public List<parInApartDto> parmeterApart { get; set; }
        public apartVertex()
        {
            //אתחול רשימת הפרמטרים של הדירה
            parmeterApart = new List<parInApartDto>();
        }
    }
}
