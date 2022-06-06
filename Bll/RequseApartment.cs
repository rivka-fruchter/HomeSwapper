
using Dto;
namespace Bll
{
    //מחלקת עזר שמכילה את כל הפרטים של משתמש
    public class RequseApartment
    {
        // דירה
        public apartmentDto apartment { get; set; }
        // מערך הפרמטרים שבדירה
        public int[] parameterArr { get; set; }
        //משפחה
        public familyDto family { get; set; }
        //אילוצים של משפחה
        public familyConstDto familyConst { get; set; }
        //פרמטרים של משפחה
        public int[] familyParameter { get; set; }
        //משתמש
        public userDto user { get; set; }
        public RequseApartment()
        {

        }
    }
}
