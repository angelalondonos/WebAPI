using APIAXMStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace APIAXMStore.Controllers
{
    public class StoreController : ApiController
    {
        // POST api/<controller>
        public bool Post([FromBody] Store store)
        {
            return Store.Registrar(store);
        }
    }
}