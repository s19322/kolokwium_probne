using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using kolokwium_probne.Context;
using kolokwium_probne.Models;
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

            var idKlient = _dbcontext.BakeryClient.Where(e => e.nazwisko == Clientname).Select(e => e.IdKlient);

            if (idKlient.Count() == 0)
            {
                return BadRequest("Klient " + Clientname + " nie zlozyl zadnego zamowienia");
            }

                var listofALLOrders = from orders in _dbcontext.BakeryOrders
                                      join prod_or in _dbcontext.BakeryProduct_Order
                                      on orders.IdZamowienie equals prod_or.IdZamowienie
                                      join prod in _dbcontext.BakeryProduct
                                      on prod_or.IdWyrobCukierniczy equals prod.IdWyrobCukierniczy
                                      where orders.IdKlient == idKlient.First()
                                      select new Zamowienie_WyrobCukierniczy
                                      {
                                          IdZamowienie = orders.IdZamowienie,
                                          IdWyrobCukierniczy = prod.IdWyrobCukierniczy,
                                          Ilosc = prod_or.Ilosc,
                                          Uwagi = orders.Uwagi,
                                          zamowienie = new Zamowienie
                                          {
                                              IdZamowienie = orders.IdZamowienie,
                                              DataPrzyjecia = orders.DataPrzyjecia,
                                              DataRealizacji = orders.DataRealizacji,
                                              Uwagi = orders.Uwagi,
                                          },
                                          wyrob = new WyrobCukierniczy
                                          {
                                              IdWyrobCukierniczy = prod.IdWyrobCukierniczy,
                                              CenaZaSztuke = prod.CenaZaSztuke,
                                              typ = prod.typ,
                                              Nazwa = prod.Nazwa,
                                          }
                                      };

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
                       select new Zamowienie_WyrobCukierniczy
                       {
                           IdZamowienie = orders.IdZamowienie,
                           IdWyrobCukierniczy = prod.IdWyrobCukierniczy,
                           Ilosc = prod_or.Ilosc,
                           Uwagi = orders.Uwagi,
                           zamowienie = new Zamowienie
                           {
                               IdZamowienie = orders.IdZamowienie,
                               DataPrzyjecia = orders.DataPrzyjecia,
                               DataRealizacji = orders.DataRealizacji,
                               Uwagi = orders.Uwagi,
                           },
                           wyrob = new WyrobCukierniczy
                           {
                               IdWyrobCukierniczy = prod.IdWyrobCukierniczy,
                               CenaZaSztuke = prod.CenaZaSztuke,
                               typ = prod.typ,
                               Nazwa = prod.Nazwa,
                           }
                       };

            if (listofOrders.Count() == 0)
            {
                return BadRequest("Brak zamowien w bazie");
            }

            return Ok(listofOrders.ToList());
        }
}
}