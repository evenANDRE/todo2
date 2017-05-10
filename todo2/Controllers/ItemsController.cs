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
    public class ItemsController : ApiController
    {

        //henter alle todo oppgaver til en person basert på id
        [Route("items/{personId}")]
        [HttpGet]
        public IEnumerable<Item> GetAllItems(int personId)
        {
            MyMySql sql = new MyMySql();
            List<Item> it = sql.SelectAllItemsFromPerson(personId);    

            return it;
        }   
        
        //setter inn ny todo oppgave i DB
        [Route("person/item")]
        [HttpPost]
        public void InsertItem(Item i)
        {
            MyMySql sql = new MyMySql();
            sql.InsertItem(i);
        }
    }
}
