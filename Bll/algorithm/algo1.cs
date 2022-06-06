using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
namespace Bll.algorithm
{
    public class algo1
    {
        //פונקצית bfs למציאת מסלול ממקור ליעד
        public (List<edge>, List<edge>, Graph) bfs(Graph myGraph)
        {
            //צומת המקור של הגרף
            vertex sourceV = myGraph.s;
            //צומת היעד של הגרף
            vertex targetV = myGraph.t;
            vertex v;
            //התור
            Queue<vertex> vertexQ = new Queue<vertex>();
            //אתחול
            foreach (vertex item in myGraph.vertices)
            {
                //אם הצומת היא לא צומת מקור
                if (item.GetType().Equals(typeof(source)))
                    item.dist = 0;
                else
                {
                    item.statusColor = Constants.DEFINEWHITE;
                    item.dist = -1;
                }
                item.prevVertex = new vertex();
            }
            //הכנסת המקור לראש התור
            vertexQ.Enqueue(sourceV);
            sourceV.statusColor = Constants.DEFINEGRAY;
            //כל עוד התור לא ריק
            while (vertexQ.Count != 0)
            {
                v = vertexQ.Peek();
                foreach (edge item in v.edgeLst)
                {
                    //אם אתה קשת יוצאת מהצומת ולא נכנסת 
                    //וכן בדיקה אם הצומת לא שובצה כבר   
                    //אם זה קשת שעדין לא בקרתי בה
                    if (item.from == v && !item.from.isEmbedded && !item.to.isEmbedded && item.to.statusColor == Constants.DEFINEWHITE)
                    {
                        item.to.statusColor = Constants.DEFINEGRAY;//משנה לאפור לסמן שבקרתי
                        item.to.dist = v.dist + 1;//מעלה את המרחק למרחק של אבא שלו +1
                        item.to.prevVertex = v;//הקודם הוא אבא שלו
                        vertexQ.Enqueue(item.to);//הכנסה לתור                        
                    }
                }
                v.statusColor = Constants.DEFINEBLACK;//גמרתי לטפל מסומן כשחור
                vertexQ.Dequeue();//הוצאה מהתור
            }
            //אם לא נמצאה דרך מהמקור ליעד
            if (targetV.dist == -1)
                return (null, null, myGraph);
            //רשימת קשתות שמהוות את המסלול מהמקור יעד
            List<edge> elst = new List<edge>();
            //מתחילה מהיעד
            vertex v1 = targetV.prevVertex;
            edge e = new edge();
            e.to = targetV;
            e.from = v1;
            elst.Add(e);
            //כל עוד לא הגעיתי למקור אני ממשיכה במסלול
            while (!v1.GetType().Equals(typeof(source)))
            {
                //סימון הצומת כשובצה
                changeIsEmbedded(v1, myGraph);
                //יצירת קשת חדשה
                edge e1 = new edge();
                e1.to = v1;
                e1.from = v1.prevVertex;
                elst.Add(e1);
                v1 = v1.prevVertex;
            }
            //הבאת המסלול ההפוך
            List<edge> elstOposit;
            (elstOposit, myGraph) = findOpositPath(elst, myGraph);
            return (elst, elstOposit, myGraph);
        }

        //פןנקציה שמקבלת מסלול של קשתות ממשפחה לדירה ומוצאת את המסלול מהדירה של המשפחה שלמשפחה של הדירה
        public (List<edge>, Graph) findOpositPath(List<edge> elst, Graph myGraph)
        {
            edge e = new edge();
            List<edge> lst = new List<edge>();
            foreach (edge item in elst)
            {
                if (item.from.GetType().Equals(typeof(familyVertex)) && item.to.GetType().Equals(typeof(apartVertex)))
                {
                    e = findEdge1(item, myGraph);
                }
            }
            foreach (edge item in elst)
            {
                // או יעד אם אתה מקור
                if (item.from.GetType().Equals(typeof(source)) || item.to.GetType().Equals(typeof(target)))
                {
                    lst.Add(findEdge(item, myGraph));
                }
                else
                {
                    //סימון כשובץ
                    changeIsEmbedded(e.to, myGraph);
                    changeIsEmbedded(e.from, myGraph);
                    lst.Add(e);
                }
            }
            return (lst, myGraph);
        }
        //מציאת קשת בודדת בגרף 
        public edge findEdge(edge e, Graph myGraph)
        {
            foreach (edge item in myGraph.edges.Where(item => item.to == e.to && item.from == e.from))
                return item;
            return null;
        }

        //מציאת קשת בודדת בגרף אבל הפוכה
        public edge findEdge1(edge e, Graph myGraph)
        {
            edge temp = new edge();
            familyVertex f = (familyVertex)e.from;
            apartVertex a = (apartVertex)e.to;
            vertex v = findFamily(a, myGraph);
            vertex v1 = findApartment(f, myGraph);
            foreach (edge item in myGraph.edges.Where(item => item.from == v && item.to == v1))
                return item;
            return null;
        }

        //פונקציה שמסמן על צמתים שהם שובצו
        public void changeIsEmbedded(vertex v, Graph myGraph)
        {
            //תחפש צומת בגרף שהיא צומת המשפחה שלך ותשנה אותה לנכון   
            foreach (vertex item in myGraph.vertices.Where(item => item == v))
            {
                item.isEmbedded = true;
            }
        }

        //פונקצית הפיכת קשתות בגרף
        public void reverseVertex(List<edge> lstEdges, Graph g)
        {
            vertex temp;
            //על כל קשת במסלול שהתקבל עוברים ומוצאים אותו בגרף והופכים את הקשת
            foreach (edge item1 in lstEdges)
            {
                foreach (edge item2 in g.edges)
                {
                    if (item1.from.Equals(item2.from) && item1.to.Equals(item2.to))
                    {
                        //הפיכת הקשתות בגרף
                        temp = item2.from;
                        item2.from = item2.to;
                        item2.to = temp;
                    }
                }
            }
        }

        //פונקציה שמוצאת את הזוגות המשובצים
        public bool findPairs(Graph myGraph)
        {
            int count = 0;
            foreach (vertex item1 in myGraph.vertices)
            {
                //אם אתה דירה
                //ויש לךצומת שמחוברת אליך והיא משפחה
                //זה אומר שנמצא התאמה למשפחה
                if (item1.GetType().Equals(typeof(apartVertex)) && item1.isEmbedded == true)
                {
                    foreach (var item2 in item1.edgeLst.Where(item2 => item2.to.GetType().Equals(typeof(familyVertex)) && item1.isEmbedded == true))
                    {
                        //הכנסה לטבלת השיבוץ הסופי
                        //יצירת צומת דירה והכנסת הדירה לשיבוץ
                        apartVertex apartmentV = (apartVertex)item1;
                        //יצירת צומת משפחה והכנסת המשפחה לשיבוץ
                        familyVertex familyV = (familyVertex)item2.to;
                        //שליחה לפונקציה שמוסיפה את הזוג לטבלת השיבוץ
                        db.addPlacment(apartmentV.a.apartcode, familyV.f.familyCode, (DateTime)apartmentV.a.startDate, (DateTime)apartmentV.a.endDate, familyV.precent);
                        count++;
                    }
                }
            }
            //אם מספר השיבוצים כפול 2 ועוד מקור ויעד שווה למספר הצמתים כולם השתבצו
            if ((count * 2) + 2 == myGraph.vertices.Count())
                return true;
            return false;
        }

        //מציאת צומת משפחה בגרף עבור דירה
        public vertex findFamily(apartVertex a, Graph myGraph)
        {
            foreach (vertex item in myGraph.vertices)
            {
                if (item.GetType().Equals(typeof(familyVertex)))
                {
                    familyVertex v = (familyVertex)item;
                    if (v.f.apartmentCode == a.a.apartcode)
                        return item;
                }
            }
            return null;
        }

        //מציאת צומת דירה בגרף עבור משפחה
        public vertex findApartment(familyVertex f, Graph myGraph)
        {
            foreach (vertex item in myGraph.vertices)
            {
                if (item.GetType().Equals(typeof(apartVertex)))
                {
                    apartVertex a = (apartVertex)item;
                    if (f.f.apartmentCode == a.a.apartcode)
                        return item;
                }
            }
            return null;
        }

        //פונקציה שעוברת על הגרף ומחזירה רשימת משפחות  שלא השתבצו
        public List<familyVertex> familyNotCross(Graph myGraph)
        {
            List<familyVertex> familyVertive = new List<familyVertex>();
            foreach (vertex item in myGraph.vertices)
            {
                if (item.GetType().Equals(typeof(familyVertex)) && item.isEmbedded == false)
                {
                    familyVertive.Add((familyVertex)item);
                }
            }
            return familyVertive;
        }

        //פונקציה שעוברת על הגרף ומחזירה רשימת דירות שלא השתבצו
        public List<apartVertex> apartmentNotCross(Graph myGraph)
        {
            List<apartVertex> apartVertice = new List<apartVertex>();
            foreach (vertex item in myGraph.vertices)
            {
                if (item.GetType().Equals(typeof(apartVertex)) && item.isEmbedded == false)
                    apartVertice.Add((apartVertex)item);
            }
            return apartVertice;
        }

        //פורד פלקרסון
        public Graph fordFalkerson(List<apartVertex> apartmentLst, List<familyVertex> familyLst, int min)
        {
            //הגרף שנוצר
            Graph newGraph = new Graph();
            //מסלול אפשרי בגרף
            List<edge> path1;
            List<edge> path2;
            //בנית הגרף
            newGraph = newGraph.buildGraph(apartmentLst, familyLst, min);
            //מציאת מסלול אפשרי
            (path1, path2, newGraph) = bfs(newGraph);
            while (path1 != null)
            {
                //הפיכת קשתות
                reverseVertex(path1, newGraph);
                reverseVertex(path2, newGraph);
                (path1, path2, newGraph) = bfs(newGraph);
            }
            return newGraph;
        }

        //פונקציה ראשית
        public List<int> mainFunction()
        {
            Graph myGraph = new Graph();
            //האם כל הזוגות השתבצו
            bool isEmbedded;
            //קבלת רשימת צמתי משפחה
            List<familyVertex> familyLst = myGraph.GetFamilyVertexLst();
            //קבלת רשימת צמתי דירה
            List<apartVertex> apartmentLst = myGraph.GetApartVertexLst();
            int saf = Constants.DEFINESAF;
            //הפעלת הפורד פעם ראשונה
            //v^3
            myGraph = fordFalkerson(apartmentLst, familyLst, saf);
            //מציאת הזוגות שהשתבצו
            //v*e
            isEmbedded = findPairs(myGraph);
            if (isEmbedded)
                return null;
            //אם לא כל המשפחות השתבצו
            for (int i = saf; i >= 17; i--)
            {
                //רשימת של משפחות שלא השתבצו
                familyLst = familyNotCross(myGraph);
                //רשימה של דירות שלא השתבצו
                apartmentLst = apartmentNotCross(myGraph);
                //אם אין דירות/משפחות שלא השתבצו עוצר
                if (familyLst.Count == 0)
                    return null;
                //הפעלה נוספת של פורד
                myGraph = fordFalkerson(apartmentLst, familyLst, i);
                //מציאת הזוגות שהשתבצו
                isEmbedded = findPairs(myGraph);
                //אם כולם השתבצו
                if (isEmbedded)
                    return null;
            }
            //פעם נוספת בשביל הפעם האחרונה שלא מעדכן את רשימת המשפחות שלא השתבצו
            familyLst = familyNotCross(myGraph);
            //בונה רשימה של משפחות שלא התקבלו הרשימה מכילה את הקודים של המשפחות
            List<int> familyNotCorssCode = new List<int>();
            foreach (familyVertex item in familyLst)
            {
                familyNotCorssCode.Add(item.f.familyCode);
            }
            return familyNotCorssCode;
        }



        //פונקציה שעוברת על רשימת משפחות ומחפשת את המשפחה של קוד הדירה שהתקבלה
        public familyVertex findFamilyInList(int code, List<familyVertex> listF)
        {
            foreach (familyVertex item in listF.Where(item => item.f.apartmentCode == code))
                return item;
            return null;
        }

        //פונקציה שעוברת על רשימת דירות ומחפשת את הדירה בעלת קוד דירה שהתקבל
        public apartVertex findApartmentInList(int code, List<apartVertex> listA)
        {
            foreach (apartVertex item in listA.Where(item => item.a.apartcode == code))
                return item;
            return null;
        }

    }
}
