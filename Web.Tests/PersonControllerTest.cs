using Microsoft.EntityFrameworkCore;
using Web.Controllers;
using Web.Data;
using Web.Models;
using Xunit;

namespace Web.Tests
{
    public class PersonControllerTest
    {
        private readonly PersonController _personController;
        public PersonControllerTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
            optionsBuilder.UseInMemoryDatabase("TestDatabase");
            var apiContext = new ApiContext(optionsBuilder.Options);
            _personController = new PersonController(apiContext);
        }

        [Fact]
        public void Insert_person_sucess()
        {
            var person = new PersonModel
            {
                Email = "mauriciobastiani@outlook.com",
                Name = "Maurício",
                Phone = "123456"
            };

            var result = _personController.Post(person);
            Assert.True(result.Id > 0);
        }
    }
}