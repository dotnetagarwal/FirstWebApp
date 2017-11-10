using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using First_API_App.Models;

namespace First_API_App.Controllers
{
    public class EntityController : ApiController
    {
        private static Dictionary<int, School > mockData = new Dictionary<int, School>();
        static EntityController()
        {
            mockData.Add(0, new School { ID = 0, Owner = "ANO", Description = "SD_School" });
            mockData.Add(1, new School { ID = 1, Owner = "SHI", Description = "Ran_School" });
        }

        // GET api/Entity1
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public IEnumerable<School> Get(string owner)
        {
            return mockData.Values.Where(m => m.Owner == owner || owner == "SD_School");
        }

        // GET: api/Entity1/5
        public School GetById(int id)
        {
            return mockData.Values.Where(m => m.ID == id).First();
        }

        // POST api/Entity
        public void Post(School school)
        {
            school.ID = mockData.Count > 0 ? mockData.Keys.Max() + 1 : 1;
            mockData.Add(school.ID, school);
        }

        // PUT api/<controller>/5
        public void Put(School todo)
        {
        
            School school = mockData.Values.First(a => (a.Owner == todo.Owner) && a.ID == todo.ID);
            if (todo != null && school != null)
            {
                school.Description = todo.Description;
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            School todo = mockData.Values.First( a=> a.ID == id);
            if (todo != null)
            {
                mockData.Remove(todo.ID);
            }
        }
    }
}