using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
       // public IEnumerable<string> Get()
       // {
       //     return new string[] { "value1", "value2" };
       // }

        // GET: api/Employee/5
       // public IEnumerable<Employee> Get(int id)
       // {
       //     return "value";
      //  }

        public IEnumerable<Employee> Get()
        {
            using (DotNetAppSqlDb_dbEntities entities = new DotNetAppSqlDb_dbEntities())
            {
                return entities.Employees.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (DotNetAppSqlDb_dbEntities entities = new DotNetAppSqlDb_dbEntities())
            {
                return entities.Employees.FirstOrDefault(e => e.EmployeeId == id);
            }
        }
        // POST: api/Employee
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
           // using (DotNetAppSqlDb_dbEntities entities = new DotNetAppSqlDb_dbEntities())
           // {
           //     Employee emp = new Employee();
           //     emp.EmployeeId = id;
           //     entities.Employees.Add(emp);
           //     entities.SaveChanges();
          //  }
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            using (DotNetAppSqlDb_dbEntities entities = new DotNetAppSqlDb_dbEntities())
            {
                Employee emp = entities.Employees.Find(id);
                entities.Employees.Remove(emp);
                entities.SaveChanges();
            }
        }
    }
}
