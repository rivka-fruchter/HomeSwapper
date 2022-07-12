
using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
namespace Bll
{
    //מחלקת גרף
    public class Graph
    {
        //מקור הגרף
        public source s { get; set; }
        //יעד הגרף
        public target t { get; set; }
         //רשימת צמתים
        public List<vertex> vertices { get; set; }
        //רשימת קשתות
        public List<edge> edges { get; set; }
        public Graph()
        {
            //אתחול
            vertices = new List<vertex>();
            edges = new List<edge>();
            s = new source();
            t = new target();
        }
        //כאן נמצאות כל הפונקציות שקשורות לבנית הגרף

        //פונקציה שבונה את הגרף
        public Graph buildGraph(List<apartVertex> listA, List<familyVertex> listF, double min)
        {
            //משתנה מסוג גרף שיכיל את הגרף הבנוי
            Graph g;
            //סכום ההתאמה בין משפחה לדירה
            double val1;
            double val2;
            //עבור כל משפחה
            for (int i = 0; i < listF.Count; i++)
            {
                //נבדקת ההתאמה מול כל דירה ומחושב ציון התאמה
                for (int j = i + 1; j < listA.Count; j++)
                {
                    //רק אם זה לא הדירה המקורית שלך תבדוק אם יכולה להיות התאמה
                    if (listF[i].f.apartmentCode != listA[j].a.apartcode)
                    {
                        //חישוב התאמה מצד אחד
                        val1 = scoreCalculation(listF[i], listA[j]);
                        //חישוב התאמה מצד שני
                        val2 = scoreCalculation(listF[j], listA[i]);
                        // אם ערך ההתאמה עובר את הסף המינמלי העכשוי
                        if (val1 > min && val2 > min)
                        {
                            //חיבור צד אחד
                            //חיבור קשת בין משפחה לדירה
                            listF[i].precent = val1 / Constants.DEFINE25;
                            edge e = new edge();
                            vertex vFrom=listF[i];
                            vertex vTo= listA[j];                           
                            e.from = vFrom;
                            e.to = vTo;
                            //הוספת הדירה לרשימת הדירות האפשריות של משפחה 
                            listF[i].edgeLst.Add(e);
                            //הוספת המשפחה לרשימת המשפחות האפשריות של דירה 
                            listA[j].edgeLst.Add(e);
                            //חיבור צד שני
                            //חיבור קשת בין משפחה של דירה לדירה של משפחה
                            listF[j].precent = val2 / Constants.DEFINE25;
                            edge e1 = new edge();
                            vertex vFrom1 = listF[j]; ;
                            vertex vTo1= listA[i]; ;
                            e1.from = vFrom1;
                            e1.to = vTo1;
                            //הוספת הדירה לרשימת הדירות האפשריות של משפחה 
                            listF[j].edgeLst.Add(e1);
                            //הוספת המשפחה לרשימת המשפחות האפשריות של דירה 
                            listA[i].edgeLst.Add(e1);
                        }
                    }
                }
            }
            //שליחה לפונקצית אתחול הגרף
            g = initialization(listA, listF);
            //חיבור המקור והיעד לגרף
            addScoreAndTarget(g);
            return g;
        }
        //פונקציה שמאתחלת את הגרף
        public Graph initialization(List<apartVertex> listA, List<familyVertex> listF)
        {
            //הגרף החדש
            Graph myGraph = new Graph();
            //מעבר על הדירות
            foreach (apartVertex item in listA)
            {
                //מוסיפה לגרף לרשימת הקשתות
                myGraph.edges.AddRange(item.edgeLst);
                //מוסיפה לרשימת הצמתים של הגרף את הצומת
                myGraph.vertices.Add(item);
            }
            //מעבר על משפחות
            foreach (familyVertex item in listF)
            {
                myGraph.vertices.Add(item);
            }
            return myGraph;
        }
        //פונקציה שעוברת על רשימת הצמתים בגרף ומוסיפה אותם לקודקוד מקור ויעד

        public void addScoreAndTarget(Graph g)
        {
            //הגדרת מקור ויעד בגרף
            g.s = new source();
            g.t = new target();
            foreach (vertex item in g.vertices)
            {
                //חיבור המשפחות למקור
                if (item.GetType().Equals(typeof(familyVertex)))
                {
                    //יצירת קשת חדשה שתחבר בין מקור למשפחה
                    edge e = new edge();
                    e.from = g.s;
                    e.to = item;
                    //הוספת הקשת לרשימת הקשתות של המקור
                    g.s.edgeLst.Add(e);
                    //הוספת הקשת לרשימת הקשתות של משפחה
                    item.edgeLst.Add(e);
                    //הוספת הקשת לרשימת הקשתות של הגרף
                    g.edges.Add(e);

                }
                //חיבור הדירות ליעד
                else if (item.GetType().Equals(typeof(apartVertex)))
                {
                    //יצירת קשת חדשה שתחבר בין דירה ליעד
                    edge e = new edge();
                    e.from = item;
                    e.to = g.t;
                    //הוספת הקשת לרשימת הקשתות של היעד
                    g.t.edgeLst.Add(e);
                    //הוספת הקשת לרשימת קשתות של דירה
                    item.edgeLst.Add(e);
                    //הוספת הקשת לרשימת הקשתות של הגרף
                    g.edges.Add(e);
                }
            }
            //הוספת המקור והיעד לרשימת הצמתים של הגרף
            g.vertices.Add(g.s);
            g.vertices.Add(g.t);
        }

        //פונקציה שמקבלת דירה ומשפחה ומחשבת ניקוד ההתאמה בינהם
        public double scoreCalculation(familyVertex fam, apartVertex apart)
        {
            double value = 0;
            List<familyParmeterDto> famParmeter;
            List<parInApartDto> apartParmeter;
            //אם העיר זהה
            if (fam.familyConst.cityCode == apart.a.cityCode)
                value += Constants.DEFINE4;
            //אם האזור זהה
            if (cityToArea((int)fam.familyConst.cityCode) == cityToArea((int)apart.a.cityCode))
                value += Constants.DEFINE6;
            //מספר מיטות גם אם הם בהפרש של אחד 
            if (fam.familyConst.numBeds - apart.a.numBeds == 1 || fam.familyConst.numBeds - apart.a.numBeds == -1 || fam.familyConst.numBeds - apart.a.numBeds == 0)
                value += Constants.DEFINE6;
            //מספר חדרים גם אם הם בהפרש של אחד
            if (fam.familyConst.numRooms - apart.a.numRooms == -1 || fam.familyConst.numRooms - apart.a.numRooms == 1 || fam.familyConst.numRooms - apart.a.numRooms == 0)
                value += Constants.DEFINE3;
            //תאריך התחלה 
            //חישוב מספר הימים שבין שני התאריכים
            TimeSpan ts = (TimeSpan)(fam.familyConst.startDate - apart.a.startDate);
            if (ts.Days > -2 && ts.Days < 2)
                value += Constants.DEFINE2;
            //תאריך סיום
            //חישוב מספר הימים שבין שני התאריכים
            TimeSpan ts1 = (TimeSpan)(fam.familyConst.endDate - apart.a.endDate);
            if (ts1.Days > -2 && ts1.Days < 2)
                value += Constants.DEFINE2;
            //חישוב הפרמטרים 
            //רשימת הפרמטרים של משפחה
            famParmeter = fam.familyParameter;
            //רשימת פרמטרים שיש בדירה
            apartParmeter = apart.parmeterApart;
            //הוספת הערך שחוזר מהשוואת רשימות הפרמטרים
            value += comperParameters(famParmeter, apartParmeter);
            return value;
        }

        //פונקציה שמשווה בין פרמטרים של דירה לפרמטרים של משפחה
        public double comperParameters(List<familyParmeterDto> fp, List<parInApartDto> ap)
        {
            double sum = 0;
            foreach (familyParmeterDto item1 in fp)
            {
                foreach (var _ in ap.Where(item2 => item1.parameterCode == item2.codeParameter).Select(
                //מחפש את קוד הפרמטר הספציפי ברשימת הפרמטרים השניה
                item2 => new { }))
                {
                    switch (item1.parameterCode)
                    {
                        //בריכה?
                        case 1:
                            sum += Constants.DEFINE0_5;
                            break;
                        //מרפסת?
                        case 2:
                            sum += Constants.DEFINE1;
                            break;
                        //עיר חוף?
                        case 3:
                            sum += Constants.DEFINE0_5;
                            break;
                    }
                }
            }
            return sum;
        }
        //פונקציה שמקבלת מספר עיר ומחזירה את מספר האזור בה העיר נמצאת
        public int cityToArea(int city)
        {
            List<cityDto> clst = (List<cityDto>)db.getAllCity().Data;
            foreach (cityDto c in clst)
                if (c.cityCode == city)
                {
                    return (int)c.area;
                }

            return -1;
        }

        //בנית רשימת צמתי דירה
        public List<apartVertex> GetApartVertexLst()
        {
            List<apartVertex> apartmentLst = new List<apartVertex>();
            //רשימת פרמטרים בדירה
            List<parInApartDto> parametersInApart;
            parametersInApart = (List<parInApartDto>)db.getAllApartParameter().Data;
            //רשימת דירות
            List<apartmentDto> apartment;
            apartment = (List<apartmentDto>)db.getAllApartment().Data;
            foreach (apartmentDto item in apartment)
            {
                apartVertex apartVertex = new apartVertex();
                foreach (parInApartDto item1 in parametersInApart)
                {//מציאת רשימת הפרמטרים שמתאימה לדירה
                    if (item.apartcode == item1.codeApart)
                    {
                        apartVertex.parmeterApart.Add(item1);
                    }
                }
                apartVertex.a = item;
                apartmentLst.Add(apartVertex);
            }
            return apartmentLst;
        }

        //בנית רשימת צמתי משפחה
        public List<familyVertex> GetFamilyVertexLst()
        {
            //רשימת צמתי משפחה
            List<familyVertex> familyVertexLst = new List<familyVertex>();
            //רשימת משפחות
            List<familyDto> family = (List<familyDto>)db.getAllFamily().Data;
            //רשימת אילוצים
            List<familyConstDto> familyConstraint = (List<familyConstDto>)db.getAllFamilyConst().Data;
            //רשימת פרמטרים
            List<familyParmeterDto> familyParameter = (List<familyParmeterDto>)db.getAllFamilyParameter().Data;
            familyConstDto fc = new familyConstDto();
            familyParmeterDto fp = new familyParmeterDto();
            foreach (familyDto item in family)
            {
                //הוספה לצומת משפחה
                familyVertex fv = new familyVertex();
                fv.familyConst = null;
                //חיפוש הרשימת האילוצים של משפחה
                foreach (familyConstDto item1 in familyConstraint.Where(item1 => item.familyCode == item1.familyCode))
                    fv.familyConst = item1;
                //חיפוש רשימת פרמטרים של משפחה
                fv.familyParameter.AddRange(familyParameter.Where(item2 => fv.familyConst.constCode == item2.constCode));
                fv.f = item;
                familyVertexLst.Add(fv);
            }

            return familyVertexLst;
        }

    }

}
