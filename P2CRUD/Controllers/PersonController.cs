using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P2CRUD.Models;

namespace P2CRUD.Controllers
{
    public class PersonController : Controller
    {

        private readonly MyDbContext myDb;

        public PersonController(MyDbContext myDb)
        {
            this.myDb = myDb;
        }
        

        public IActionResult Index()
        {
            return View();
        }
      
        [HttpGet]
        public IActionResult Get()
        {
            var person = myDb.Person.ToList();
            return Json(person);
        }

        [HttpPost]
        public IActionResult Post(Person person)
        {
            myDb.Person.Add(person);
            myDb.SaveChanges();
            return Ok("Ya we no hay");
        }

        [HttpPut]
        public IActionResult Put(Person person)
        {
            myDb.Entry(person).State = EntityState.Modified;
            myDb.SaveChanges();
            return Ok();

        }

        [HttpDelete]
        public IActionResult Delete(Person person)
        {
            myDb.Entry(person).State = EntityState.Deleted;
            myDb.SaveChanges();
            return Ok();

        }
    }

}
