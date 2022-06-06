using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bll.algorithm;
using Bll;
using Dto;
using Dal;
namespace full_project.Controllers
{
    //קונטרולר ששימש רק בזמן פיתוח להרצה ודיבוג
    public class debudController : ApiController
    {
        algo1 algo = new algo1();
        Graph g = new Graph();
        List<edge> e = new List<edge>();
        List<edge> e1 = new List<edge>();
        swapEntities e3 = new swapEntities();
        List<apartVertex> av = new List<apartVertex>();
        List<familyVertex> fv = new List<familyVertex>();
        List<apartmentDto> adto = new List<apartmentDto>();
        List<parInApartDto> apdto = new List<parInApartDto>();
        List<familyDto> fdto = new List<familyDto>();
        List<familyConstDto> fcdto = new List<familyConstDto>();
        List<familyParmeterDto> fpdto = new List<familyParmeterDto>();
        // GET: api/debud

        public void Get()
        {
            
            algo.mainFunction();

        }

        // GET: api/debud/5
        public void Get(int id)
        {
           
        }

        // POST: api/debud
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/debud/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/debud/5
        public void Delete(int id)
        {
        }
    }
}
