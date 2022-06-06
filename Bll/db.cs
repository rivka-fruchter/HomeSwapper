using System;
using System.Collections.Generic;
using System.Linq;
using Dal;
using Dto;
namespace Bll
{
    public static class db
    //מחלקה לשליפת נתונים מהמסד נתונים 
    {
        //שליפת כל הערים
        public static RequestResult getAllCity()
        {
            using (swapEntities db1 = new swapEntities())
            {
                List<cityDto> cityLst = new List<cityDto>();
                foreach (var item in db1.city_)
                {
                    cityLst.Add(cityDto.DalToDto(item));
                }
                return new RequestResult() { Data = cityLst, Message = "success", Status = true };
            }

        }
        //שליפת כל הפרמטרים 
        public static RequestResult getAllparameter()
        {
            using (swapEntities db1 = new swapEntities())
            {
                List<parameterDto> parameterLst = new List<parameterDto>();
                foreach (var item in db1.parameter)
                {
                    parameterLst.Add(parameterDto.DalToDto(item));
                }
                return new RequestResult() { Data = parameterLst, Message = "success", Status = true };
            }
        }
        //שליפת כל האילוצים למשפחה
        public static RequestResult getAllFamilyConst()
        {
            using (swapEntities db1 = new swapEntities())
            {
                List<familyConstDto> familyConstLst = new List<familyConstDto>();
                foreach (var item in db1.familyConstraint)
                {
                    familyConstLst.Add(familyConstDto.DalToDto(item));
                }
                return new RequestResult() { Data = familyConstLst, Message = "success", Status = true };
            }
        }
        //שליפת פרמטרים למשפחה
        public static RequestResult getAllFamilyParameter()
        {
            using (swapEntities db1 = new swapEntities())
            {
                List<familyParmeterDto> familyParmeterLst = new List<familyParmeterDto>();
                foreach (var item in db1.familyParameters)
                {
                    familyParmeterLst.Add(familyParmeterDto.DalToDto(item));
                }
                return new RequestResult() { Data = familyParmeterLst, Message = "success", Status = true };
            }
        }
        //שליפת פרמטרים שיש בדירה
        public static RequestResult getAllApartParameter()
        {
            using (swapEntities db1 = new swapEntities())
            {
                List<parInApartDto> apartParameterLst = new List<parInApartDto>();
                foreach (var item in db1.parametersInApart)
                {
                    apartParameterLst.Add(parInApartDto.DalToDto(item));
                }
                return new RequestResult() { Data = apartParameterLst, Message = "success", Status = true };
            }
        }
        //שליפת כל הדירות
        public static RequestResult getAllApartment()
        {
            using (swapEntities db1 = new swapEntities())
            {
                List<apartmentDto> apartmentLst = new List<apartmentDto>();
                foreach (var item in db1.apartment)
                {
                    apartmentLst.Add(apartmentDto.DalToDto(item));
                }
                return new RequestResult() { Data = apartmentLst, Message = "success", Status = true };
            }
        }
        //שליפת כל המשפחות
        public static RequestResult getAllFamily()
        {
            using (swapEntities db1 = new swapEntities())
            {
                List<familyDto> familyLst = new List<familyDto>();
                foreach (var item in db1.Familiy)
                {
                    familyLst.Add(familyDto.DalToDto(item));
                }
                return new RequestResult() { Data = familyLst, Message = "success", Status = true };
            }
        }
        //שליפת כל המשתמשים
        public static RequestResult getAllUser()
        {
            using (swapEntities db1 = new swapEntities())
            {
                List<userDto> lstUser = new List<userDto>();
                foreach (var item in db1.userDetails)
                {
                    lstUser.Add(userDto.DalToDto(item));
                }
                return new RequestResult() { Data = lstUser, Message = "success", Status = true };
            }
        }
        //קבלת כל הפרטים של משתמש
        //מקבל קוד משפחה
        public static RequseApartment getAll(int id)
        {
            RequseApartment all = new RequseApartment();
            all.family = getFamily(id);
            all.apartment = getApartment((int)all.family.apartmentCode);
            all.familyConst = getFamilyConst(id);
            return all;
        }
        //פונקציה שמקבלת רשימת משפחות ומחזירה רשימות מיילים שלהם
        //וכן את שם המשפחה שהמייל שלה
        public static List<string[]> getAllEmail(List<int> familyLst)
        {
            List<string[]> emails = new List<string[]>();
            //עבור כל משפחה יוצר מערך שמכיל את המייל שלה ואת שם המשפחה שלה
            foreach (var item in familyLst)
            {
                string[] temp = new string[2];
                temp[0] = getEmail(item).e;
                temp[1] = getEmail(item).n;
                if (temp[0] != null)
                    emails.Add(temp);
            }
            return emails;
        }
        //פונקציה שמקבלת קוד משפחה ומחזירה את המייל שלה ואת שם המשפחה
        public static (string e, string n) getEmail(int familyCode)
        {
            using (swapEntities db1 = new swapEntities())
            {
                foreach (var item in db1.Familiy.Where(item => item.familyCode == familyCode))
                    return (item.email, item.familyName);
                return (null, null);
            }
        }
        //קבלת קוד משפחה והחזרת משפחה
        public static familyDto getFamily(int code)
        {
            using (swapEntities db1 = new swapEntities())
            {
                foreach (var item in db1.Familiy.Where(item => item.familyCode == code))
                    return familyDto.DalToDto(item);
                return null;
            }
        }
        //קבלת קוד משפחה והחזרת אילוצי המשפחה
        public static familyConstDto getFamilyConst(int code)
        {
            using (swapEntities db1 = new swapEntities())
            {
                foreach (var item in db1.familyConstraint.Where(item => item.familyCode == code))
                    return familyConstDto.DalToDto(item);
                return null;
            }
        }

        //קבלת קוד עיר והחזרת עיר
        public static string getCity(int code)
        {
            using (swapEntities db1 = new swapEntities())
            {
                foreach (var item in db1.city_.Where(item => item.cityCode == code))
                    return item.cityName;
                return null;
            }
        }
        //קבלת קוד דירה והחזרת הדירה
        public static apartmentDto getApartment(int code)
        {
            using (swapEntities db1 = new swapEntities())
            {
                foreach (var item in db1.apartment.Where(item => item.apartcode == code))
                    return apartmentDto.DalToDto(item);
                return null;
            }
        }
        //קבלת קוד דירה והחזרת משפחה הדירה
        public static string getFamilyApartment(int code)
        {
            using (swapEntities db1 = new swapEntities())
            {
                foreach (var item in db1.Familiy.Where(item => item.apartmentCode == code))
                    return item.familyName;
                return null;
            }
        }
        // צפייה בתוצאות שיבוץ אחרונות
        public static RequestResult getLastPlacment()
        {
            using (swapEntities db1 = new swapEntities())
            {
                List<EzerPlacment> arr = new List<EzerPlacment>();
                //מעבר על טבלת השיבוצים במסד והכנת מערך לצורך שליחה לריאקט
                foreach (var item in db1.apartmentPlacement)
                {
                    EzerPlacment e = new EzerPlacment();
                    familyDto f = getFamily(item.familyCode);
                    e.familyName = f.familyName;
                    e.familyEmail = f.email;
                    apartmentDto a = getApartment(item.apartmentCode);
                    e.apartmentCode = item.apartmentCode;
                    e.familyAdress = a.Street + " " + getCity((int)a.cityCode);
                    e.switchWith = getFamilyApartment(item.apartmentCode);
                    DateTime d1 = (DateTime)item.startDate;
                    DateTime d2 = (DateTime)item.endDate;
                    e.startDate = d1.ToShortDateString();
                    e.endDate = d2.ToShortDateString();
                    e.precentP = (double)item.Precent;
                    arr.Add(e);
                }
                return new RequestResult() { Data = arr, Status = true, Message = "" };
            }
        }
        //צפייה בתוצאות שיבוץ אחרונות עבור משתמש אחד
        public static RequestResult getLastPlacmentUser(int id)
        {
            using (swapEntities db1 = new swapEntities())
            {
                List<EzerPlacment> arr = new List<EzerPlacment>();
                bool isexist = false;
                foreach (var item in db1.apartmentPlacement.Where(item => item.familyCode == id))
                {
                    isexist = true;
                    EzerPlacment e = new EzerPlacment();
                    familyDto f = getFamily(item.familyCode);
                    e.familyName = f.familyName;
                    e.apartmentCode = item.apartmentCode;
                    apartmentDto a = getApartment(item.apartmentCode);
                    e.familyAdress = a.Street + " " + getCity((int)a.cityCode);
                    e.switchWith = getFamilyApartment(item.apartmentCode);
                    DateTime d1 = (DateTime)item.startDate;
                    DateTime d2 = (DateTime)item.endDate;
                    e.startDate = d1.ToShortDateString();
                    e.endDate = d2.ToShortDateString();
                    e.precentP = (double)item.Precent;
                    arr.Add(e);
                }
                //אם אין לו שיבוצים אחרונים
                if (!isexist)
                    return null;
                return new RequestResult() { Data = arr, Status = true, Message = "" };
            }
        }
        //קבלת מערך פרמטרים והוספת הפרמטרים לדירה בעלת הקוד שהתקבל
        public static void AddParametrApartment(int[] arr, int code)
        {
            using (swapEntities db1 = new swapEntities())
            {
                parInApartDto parameter;
                //הוספת פרמטרים לדירה
                for (int i = 0; i < arr.Length; i++)
                {
                    parameter = new parInApartDto() { codeApart = code, codeParameter = arr[i] };
                    db1.parametersInApart.Add(parameter.DtoToDal());
                }
                db1.SaveChanges();
            }
        }
        //הוספת רק דירה והחזרת קוד הדירה
        public static int AddApartment(apartmentDto a)
        {
            using (swapEntities db1 = new swapEntities())
            {
                //הוספת דירה
                db1.apartment.Add(a.DtoToDal());
                db1.SaveChanges();
                //מחזירה את הקוד של הדירה על מנת שאוכל להוסיף את הפרמטרים של הדירה
                apartment apa = db1.apartment.ToList().Last();
                return apa.apartcode;
            }
        }
        //הוספת משתמש לטבלת המשתמשים
        public static void addUser(userDto u)
        {
            using (swapEntities db1 = new swapEntities())
            {
                db1.userDetails.Add(u.DtoToDal());
                db1.SaveChanges();
            }
        }
        //הוספת פרמטרים למשפחה
        public static void AddFamilyParameter(int[] arr, int constCode)
        {
            using (swapEntities db1 = new swapEntities())
            {
                familyParmeterDto familyParameter;
                for (int i = 0; i < arr.Length; i++)
                {
                    familyParameter = new familyParmeterDto() { constCode = constCode, parameterCode = arr[i] };
                    db1.familyParameters.Add(familyParameter.DtoToDal());
                }
                db1.SaveChanges();
            }
        }
        //הוספת אילוצים למשפחה והחזרת קוד האילוץ
        public static int AddFamilyConst(familyConstDto fc)
        {
            using (swapEntities db1 = new swapEntities())
            {
                db1.familyConstraint.Add(fc.DtoToDal());
                db1.SaveChanges();
                familyConstraint f = db1.familyConstraint.ToList().Last();
                return f.constCode;
            }
        }
        //הוספת משפחה בלבד והחזרת קוד משפחה
        public static int AddFamily(familyDto f)//,familyParmeterDto fparameter, familyConstDto fconst)
        {
            using (swapEntities db1 = new swapEntities())
            {
                //הוספת פרטי המשפחה
                db1.Familiy.Add(f.DtoToDal());
                db1.SaveChanges();
                Familiy f1 = db1.Familiy.ToList().Last();
                return f1.familyCode;
            }
        }

        //פונקציה שמוסיפה לטבלת השיבוץ זוג נוסף
        public static void addPlacment(int apartmentCode, int familyCode, DateTime sdate, DateTime edate, double p)
        {
            using (swapEntities db1 = new swapEntities())
            {
                aprtPlacmentDto apartPlac = new aprtPlacmentDto();
                apartPlac.apartmentCode = apartmentCode;
                apartPlac.familyCode = familyCode;
                apartPlac.startDate = sdate;
                apartPlac.endDate = edate;
                apartPlac.Precent = p;
                db1.apartmentPlacement.Add(apartPlac.DtoToDal());
                db1.SaveChanges();
            }
        }
        //עדכון פרמטרים לדירה
        public static void updateParameterApart(int[] arr, int code)
        {
            using (swapEntities db1 = new swapEntities())
            {
                //מקבל מערך פרמטרים להוספה וקוד דירה
                bool flag;
                //אם קוד הפרמטר אינו קיים לפני העדכון מוסיפים אותו
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!isExistParameter(arr[i], code))
                        db1.parametersInApart.Add(new parametersInApart() { codeApart = code, codeParameter = arr[i] });
                }
                //הוספת פרמטרים לדירה
                foreach (var item in db1.parametersInApart)
                {
                    flag = false;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (item.codeApart == code && arr[i] == item.codeParameter)
                            flag = true;
                    }
                    //אם לפני העדכון הפרמטר היה אבל עכשיו לא צריך למחוק אותו
                    if (flag == false && item.codeApart == code)
                        db1.parametersInApart.Remove(item);
                }
                db1.SaveChanges();
            }
        }
        //עדכון דירה
        public static void updateApartment(apartmentDto apartment)
        {
            using (swapEntities db1 = new swapEntities())
            {
                foreach (var item in db1.apartment.Where(item => item.apartcode == apartment.apartcode))
                {
                    item.cityCode = apartment.cityCode;
                    item.Street = apartment.Street;
                    item.numBeds = (int)apartment.numBeds;
                    item.numRooms = (int)apartment.numRooms;
                    item.startDate = apartment.startDate;
                    item.endDate = apartment.endDate;
                }

                db1.SaveChanges();
            }
        }
        //עדכון משפחה
        public static void updateFamily(int familyCode, familyDto family)
        {
            using (swapEntities db1 = new swapEntities())
            {
                foreach (var item in db1.Familiy.Where(item => item.familyCode == familyCode))
                {
                    item.familyName = family.familyName;
                    item.phone = family.phone;
                    item.email = family.email;
                }

                db1.SaveChanges();
            }
        }
        //עדכון אילוצי משפחה
        public static void updateFamilyConst(int familyCode, familyConstDto familyConst)
        {
            using (swapEntities db1 = new swapEntities())
            {
                foreach (var item in db1.familyConstraint.Where(item => item.familyCode == familyCode))
                {
                    item.numBeds = (int)familyConst.numBeds;
                    item.numRooms = (int)familyConst.numRooms;
                    item.startDate = familyConst.startDate;
                    item.endDate = familyConst.endDate;
                    item.cityCode = (int)familyConst.cityCode;
                }

                db1.SaveChanges();
            }
        }
        //מקבל קוד אילוץ של משפחה
        //עדכון פרמטרים למשפחה
        public static void updateParameterFamily(int[] arr, int code)
        {
            using (swapEntities db1 = new swapEntities())
            {
                bool flag;
                //אם הפרמטר כבר לא היה קודם
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!isExistParameterFamily(arr[i], code))
                        db1.familyParameters.Add(new familyParameters() { constCode = code, parameterCode = arr[i] });
                }
                //עכשיו עוברים על כל מה שיש ובודקים אם הוא מופיע ברשימת פרמטרים החדשה אם לא מוחקים אותו
                foreach (var item in db1.familyParameters)
                {
                    flag = false;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (item.constCode == code && arr[i] == item.parameterCode)
                            flag = true;
                    }
                    //אם לפני העדכון הפרמטר היה אבל עכשיו לא צריך למחוק אותו
                    if (flag == false && item.constCode == code)
                        db1.familyParameters.Remove(item);
                }

                db1.SaveChanges();
            }
        }
        //קבלת פרמטר וקוד דירה והחזרה האם קיים הפרמטר בדירה הנוכחית
        public static bool isExistParameter(int param, int aprat)
        {
            using (swapEntities db1 = new swapEntities())
            {
                foreach (var item in db1.parametersInApart)
                {
                    if (item.codeApart == aprat && item.codeParameter == param)
                        return true;
                }
                return false;
            }
        }
        //קבלת פרמטר וקוד אילוץ משפחה והחזרה האם קיים הפרמטר בקוד אילוץ המשפחהs
        public static bool isExistParameterFamily(int param, int constCode)
        {
            using (swapEntities db1 = new swapEntities())
            {
                foreach (var item in db1.familyParameters)
                {
                    if (item.constCode == constCode && item.parameterCode == param)
                        return true;
                }
                return false;
            }
        }
        //פונקציה שמחזירה האם הסיסמא הזו קיימת כבר במאגר 
        //בשביל משתמש חדש שנרשם ורוצה לעשות סיסמא
        public static bool checkUserId(string password)
        {
            using (swapEntities db1 = new swapEntities())
            {
                foreach (var item in db1.userDetails)
                {
                    if (item.userPassword.Equals(password))
                        return true;
                }
                return false;
            }
        }
        //פונקציה שמחזירה קוד משפחה אם המשתמש הזו קיים
        //ואחרת 0
        public static int checkUser(userDto u)
        {
            using (swapEntities db1 = new swapEntities())
            {
                if (u.userPassword.Equals("100"))
                    return -1;
                foreach (var item in db1.userDetails)
                {
                    if (item.userPassword == u.userPassword && item.userName == u.userName)
                        return (int)item.familyCode;
                }
                return 0;
            }
        }
        public static int deleteUser(int familyCode)
        {
            using (swapEntities db1 = new swapEntities())
            {
                int apartCode = 0;
                int constCode = 0;
                //בדיקה האם שובץ כבר
                foreach (var item in db1.apartmentPlacement.Where(item => item.familyCode == familyCode))
                {
                    return 0;
                }
                //מחיקה מטבלת משתמשים
                foreach (var item in db1.userDetails.Where(item => familyCode == item.familyCode))
                {
                    apartCode = (int)item.apartmentCode;
                    db1.userDetails.Remove(item);
                }
                foreach (var item in db1.familyConstraint.Where(item => item.familyCode == familyCode))
                    constCode = item.constCode;
                //מחיקת פרמטרים לדירה
                foreach (var item in db1.parametersInApart.Where(item => item.codeApart == apartCode))
                    db1.parametersInApart.Remove(item);
                //מחיקת פרמטרים למשפחה
                foreach (var item in db1.familyParameters.Where(item => item.constCode == constCode))
                    db1.familyParameters.Remove(item);
                //מחיקת אילוצי משפחה
                foreach (var item in db1.familyConstraint.Where(item => item.familyCode == familyCode))
                    db1.familyConstraint.Remove(item);
                //מחירת משפחה
                foreach (var item in db1.Familiy.Where(item => item.familyCode == familyCode))
                    db1.Familiy.Remove(item);
                //מחיקת דירה
                foreach (var item in db1.apartment.Where(item => item.apartcode == apartCode))
                    db1.apartment.Remove(item);
                db1.SaveChanges();
                return 1;
            }
        }
        //ריקון טבלת השיבוץ
        public static void deletePlacment()
        {
            using (swapEntities db1 = new swapEntities())
            {
                db1.apartmentPlacement.RemoveRange(db1.apartmentPlacement);
                db1.SaveChanges();
            }
        }
        //פונקציה שמקבלת קוד דירה ומחזירה את רשימת הפרמטרים שלה
        public static List<string> findApartParameter(int code)
        {
            using (swapEntities db1 = new swapEntities())
            {
                List<string> arr = new List<string>();
                foreach (var item in db1.parametersInApart.Where(item => item.codeApart == code))
                    arr.AddRange(db1.parameter.Where(item1 => item.codeParameter == item1.codeParameter).Select(item1 => item1.descrip));
                return arr;
            }            
        }     
    }

}
