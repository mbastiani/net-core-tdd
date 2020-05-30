using Microsoft.EntityFrameworkCore;
using Web.Controllers;
using Web.Data;
using Web.Models;
using Xunit;

namespace Web.Tests {
    public class PersonControllerTest {
        private readonly ApiContext _apiContext;
        private readonly PersonController _personController;

        public PersonControllerTest() {
            var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
            optionsBuilder.UseInMemoryDatabase("TestDatabase");
            _apiContext = new ApiContext(optionsBuilder.Options);
            _personController = new PersonController(_apiContext);
        }

        [Fact]
        public void Insert_person_sucess() {
            var person = new PersonModel {
                Email = "email@outlook.com",
                Name = "Test Person Insert",
                Phone = "123456"
            };

            var result = _personController.Post(person);
            Assert.True(result.Id > 0);

            var personInserted = _apiContext.Persons.Find(result.Id);
            Assert.NotNull(personInserted);
        }

        [Fact]
        public void Update_person_sucess() {
            var person = new PersonModel {
                Email = "email@outlook.com",
                Name = "Test Person Update",
                Phone = "123456"
            };

            _apiContext.Persons.Add(person);
            _apiContext.SaveChanges();

            person.Name = "Test Person Update 2";

            var result = _personController.Put(person);
            Assert.NotNull(result);

            var personUpdated = _apiContext.Persons.Find(person.Id);
            Assert.Equal("Test Person Update 2", personUpdated.Name);
        }

        [Fact]
        public void Get_person_sucess() {
            var person = new PersonModel {
                Email = "email@outlook.com",
                Name = "Test Person Get",
                Phone = "123456"
            };

            _apiContext.Persons.Add(person);
            _apiContext.SaveChanges();

            var personGet = _personController.Get(person.Id);
            Assert.NotNull(personGet);
        }

        [Fact]
        public void Get_all_person_sucess() {
            _apiContext.Persons.RemoveRange(_apiContext.Persons);

            const int count = 10;
            for (int i = 0; i < count; i++) {
                _apiContext.Persons.Add(new PersonModel {
                    Name = $"Person Get All {i}"
                });
            }
            _apiContext.SaveChanges();

            var persons = _personController.GetAll();
            Assert.Equal(count, persons.Count);
        }
    }
}