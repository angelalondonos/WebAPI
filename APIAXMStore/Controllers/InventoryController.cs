using APIAXMStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIAXMStore.Controllers
{
    public class InventoryController : ApiController
    {
     
        // POST api/<controller>
        public bool Post([FromBody] Inventory inventory)
        {
            return Inventory.Registrar(inventory);
        }

        // PUT api/<controller>/

        [Route("api/store_product")]
        public bool Put([FromBody] Inventory inventory)
        {
            return Inventory.Modificar(inventory);
        }

        [Route("api/inventory/validate")]
        public List<Respuesta> Post([FromBody] List<Inventory> list_inventory)
        {
            return Inventory.Validar(list_inventory);
        }

    }


}