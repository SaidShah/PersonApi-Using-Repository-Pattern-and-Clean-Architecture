using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PersonApi.Interfaces;
using PersonApi.Models;

namespace PersonApi.Controllers
{
    [Route("api/persons")]
    [ApiController]
    public class PersonController : Controller
    {
        private IRepositoryReadConductor<Person> _repositoryReadConductor;
        private IRepositoryCreateConductor<Person> _repositoryCreateConductor;

        public PersonController(IRepositoryReadConductor<Person> repositoryReadConductor, IRepositoryCreateConductor<Person> repositoryCreateConductor)
        {
            _repositoryReadConductor = repositoryReadConductor;
            _repositoryCreateConductor = repositoryCreateConductor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allUsers = _repositoryReadConductor.FindAll();
            return Ok(allUsers);
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var result = _repositoryReadConductor.FindById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Person obj)
        {
            var person = new Person{
                FirstName = "John",
                LastName = "Smith",
                Gender = "Male",
                IsSmart = true,
                CreatedOn = DateTimeOffset.Now.AddHours(-3)
            };
            
            var result = _repositoryCreateConductor.Create(person);
            if (result.HasErrors)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}