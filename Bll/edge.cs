
namespace Bll
{
    //מחלקת קשת בגרף
    public class edge
    {
        //מאיפה הקשת יוצאת
        public vertex from { get; set; }
        //לאן היא מגיעה
        public vertex to { get; set; }
        public edge()
        {
            //אתחול
            from = null;
            to = null;
        }
        
    }
}
