
namespace Bll
{
    //מחלקת עזר עבור שמירת נתוני השיבוץ
    public class EzerPlacment
    {
        //שם משפחה 
        public string familyName { get; set; }
        //קוד דירת הנופש שהיא קבלה
        public int apartmentCode { get; set; }
        //כתובת הדירה שהיא קבלה
        public string familyAdress { get; set; }
        //מייל המשפחה
        public string familyEmail { get; set; }
        //מחליפה עם משפחת:
        public string switchWith { get; set; }
        //תאריך התחלה
        public string startDate { get; set; }
        //תאריך סיום
        public string endDate { get; set; }
        //אחוז ההתאמה בין המשפחות
        public double precentP { get; set; }
    }
}
