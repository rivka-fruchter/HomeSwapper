
using System.Collections.Generic;

namespace Bll
{//מחלקת צומת בגרף
    public class vertex
    {  //האם שובץ?
        public bool isEmbedded { get; set; }
        //רשימת קשתות מחוברת אל הצומת
        public List<edge> edgeLst { get; set; }
        //קשור לפונקציה bfs
        //(סטטוס (צבע
        public string statusColor { get; set; }
        //מרחק
        public int dist { get; set; }
        //הקודם
        public vertex prevVertex { get; set; }
               
        public vertex()
        {
            //אתחול
            edgeLst = new List<edge>();
            isEmbedded = false;         
        }      
    }
}
