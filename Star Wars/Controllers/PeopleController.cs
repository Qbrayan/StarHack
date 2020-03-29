using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarWars.Interfaces;
using StarWars.Models;

namespace StarWars.Controllers
{

    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        // GET: People
        public IActionResult Index()
        {
            
            return View();
        }

        // GET: People/Details/s5
        public async Task <IActionResult> Favourite()
        {
            var fav = await _peopleService.GetAsync();
            return View(fav);
        }


        #region API CALLS

        [HttpGet("/People/Select")]
        public async Task<IActionResult> GetAll()
        {
            dynamic json;
            using (var httpClient = new HttpClient())
            {
                string apiResponse = await httpClient.GetStringAsync("https://swapi.co/api/people");
                json = JsonConvert.DeserializeObject(apiResponse);
                json = json["results"];

            }
           // System.IO.File.WriteAllText(@"C:\Users\Brian\Pictures\people.json", JsonConvert.SerializeObject(json));
            return Json(new {data=json });
        }

        [HttpGet("/People/Details")]
        public async Task<IActionResult> Details( string id)
        {
             Person people = new Person();
            using (var httpClient = new HttpClient())
            {
                string apiResponse = await httpClient.GetStringAsync("https://swapi.co/api/people/" + id);

                people = JsonConvert.DeserializeObject<Person>(apiResponse);               
            }
            return View(people);

        }


        #endregion



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Details(Person p)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var val = await _peopleService.InsertAsync(p);

            if (val == 0)
            {
                var msg = "swal('" + "ERROR" + "', '" + "Character is already in favourite list" + "','" + "error" + "')" + "";
                TempData["notification"] = msg;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Favourite");
            }
        }



        // POST: People/Delete/5
        public async Task <IActionResult> Delete(int id)
        {

            var value = await _peopleService.DeleteAsync(id);
            return RedirectToAction("Favourite");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}