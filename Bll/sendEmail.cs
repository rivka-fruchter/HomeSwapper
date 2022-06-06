using System;
using System.Net.Mail;
namespace Bll
{//מחלקה שמטפלת בשליחת מיילים
    public class sendEmail
    {
        public MailMessage mail { get; set; }
        public SmtpClient smtp { get; set; }
        //למי לשלוח
        public string mailTo { get; set; }
        //תוכן ההודעה ב- HTML
        public string mailBody { get; set; }

        public sendEmail(string mailTo, string mailBody)
        {
            mail = new MailMessage();
            // Smtp יצירת אוביקט 
            smtp = new SmtpClient();
            //הגדרת השרת של גוגל
            smtp.Host = "smtp.gmail.com";
            //הגדרת פרטי הכניסה לחשבון גימייל
            smtp.Credentials = new System.Net.NetworkCredential(
        "Gila05485@gmail.com", "0548516017");
            //אפשור SSL (חובה(
            smtp.EnableSsl = true;
            //למי לשלוח (יש אפשרות להוסיף כמה נמענים) 
            mail.To.Add(mailTo);
            //כתובת מייל לשלוח ממנה
            mail.From = new MailAddress("Gila05485@gmail.com");
            // נושא ההודעה
            mail.Subject = "הודעה ממערכת sawp home";
            //תוכן ההודעה ב- HTML
            mail.Body = mailBody;
            //הגדרת תוכן ההודעה ל - HTML 
            mail.IsBodyHtml = false;
        }
        public void send()
        {
            try
            {
                //שליחת ההודעה
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
            }
        }

    }
}
