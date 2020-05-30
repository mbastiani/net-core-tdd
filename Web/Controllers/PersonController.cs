using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApiContext _apiContext;

        public PersonController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public PersonModel Post(PersonModel person)
        {
            _apiContext.Persons.Add(person);
            _apiContext.SaveChanges();
            return person;
        }

        [HttpPut]
        public PersonModel Put(PersonModel person)
        {
            _apiContext.Persons.Update(person);
            _apiContext.SaveChanges();
            return person;
        }

        public PersonModel Get(long id)
        {
            return _apiContext.Persons.Find(id);
        }

        public List<PersonModel> GetAll()
        {
            return _apiContext.Persons.ToList();
        }
    }
}