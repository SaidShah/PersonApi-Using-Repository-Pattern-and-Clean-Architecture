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

        public PersonController(IRepositoryReadConductor<Person> repositoryReadConductor)
        {
            _repositoryReadConductor = repositoryReadConductor;
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
    }
}