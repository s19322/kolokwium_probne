using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium_probne.Context;
using kolokwium_probne.Models;
using kolokwium_probne.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium_probne.Controllers
{
    [Route("api/bakery")]
    [ApiController]
    public class BakeryController : ControllerBase
    {
        public BakeryContext _dbcontext;
       
        public BakeryController(BakeryContext context)
        {
            _dbcontext = context;

        }
        // GET: api/Bakery
        [HttpGet("orders/{Clientname}")]
        public IActionResult GetOrders(String Clientname)
        {

            var idKlient = _dbcontext.BakeryClient.Where(e => e.nazwisko == Clientname).Select(e=>e.IdKlient);

            var listofALLOrders = from orders in _dbcontext.BakeryOrders
                                  join prod_or in _dbcontext.BakeryProduct_Order
                                  on orders.IdZamowienie equals prod_or.IdZamowienie
                                  join prod in _dbcontext.BakeryProduct
                                  on prod_or.IdWyrobCukierniczy equals prod.IdWyrobCukierniczy
                                  where orders.IdKlient == idKlient.First()
                                  select new { prod_or} ;

            return Ok(listofALLOrders.ToList());
        }

        [HttpGet("orders")]
        public IActionResult GetOrders()
        {
           
                var listofOrders = from orders in _dbcontext.BakeryOrders
                                   join prod_or in _dbcontext.BakeryProduct_Order
                                   on orders.IdZamowienie equals prod_or.IdZamowienie
                                   join prod in _dbcontext.BakeryProduct
                                   on prod_or.IdWyrobCukierniczy equals prod.IdWyrobCukierniczy
                                   select new { prod_or };

                return Ok(listofOrders.ToList());

        }

        // GET: api/Bakery/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bakery
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        
        // PUT: api/Bakery/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
