using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
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
            using (WebAPI1_dbEntities entities = new WebAPI1_dbEntities())
            {
    
                return entities.Employees.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (WebAPI1_dbEntities entities = new WebAPI1_dbEntities())
            {
                return entities.Employees.FirstOrDefault(e => e.EmployeeID == id);
            }
        }
        // POST: api/Employee
        public void Post(int id, Employee e)
        {
            using (WebAPI1_dbEntities entities = new WebAPI1_dbEntities())
            {
                Employee emp = entities.Employees.Find(id);
                emp.EmployeeID = e.EmployeeID;
                emp.FirstName = e.FirstName;
                emp.Adress = e.Adress;
                emp.LastName = e.LastName;
                emp.Phone = e.Phone;
                entities.SaveChanges();
            }
        }

        // PUT: api/Employee/5
        public void Put(Employee e)
        {
            using (WebAPI1_dbEntities entities = new WebAPI1_dbEntities())
            {
                Employee emp = new Employee();
                emp.EmployeeID = e.EmployeeID;
                emp.FirstName = e.FirstName;
                emp.Adress = e.Adress;
                emp.LastName = e.LastName;
                emp.Phone = e.Phone;
                entities.Employees.Add(emp);
                entities.SaveChanges();
            }
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            using (WebAPI1_dbEntities entities = new WebAPI1_dbEntities())
            {
                Employee emp = entities.Employees.Find(id);
                entities.Employees.Remove(emp);
                entities.SaveChanges();
            }
        }
    }
}
