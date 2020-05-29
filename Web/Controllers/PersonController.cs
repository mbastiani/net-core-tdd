using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    }
}
