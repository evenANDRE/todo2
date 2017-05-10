using todo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace todo2.Controllers
{
    public class PersonsController : ApiController
    {

        //henter alle personer 
        //default route api/persons
        public IEnumerable<Person> GetAllPersons()
        {
            MyMySql sql = new MyMySql();
            return sql.SelectAllPersons();
        }

        //henter en person basert på id til den personen
        //default route api/persons/{id}
        public IHttpActionResult GetPerson(int id) //vet ikke om eg trenger denne metoden enda
        {
            MyMySql sql = new MyMySql();
            Person person = sql.SelectPersonFromId(id); // ta bort i prod.
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }


        //registrer ny person og returnerer id fra DB og returnerer
        [Route("person/register")]
        [HttpPost]
        public IHttpActionResult InsertPerson(Person p)
        {            
            MyMySql sql = new MyMySql();
            long retur = sql.InsertPerson(p);
            
            if (retur == 0)
            {
                return NotFound();
            }
            return Ok(retur.ToString());
        }

        
    }
}
