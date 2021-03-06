using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using PersonApi.Dtos;
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
        private IMapper _mapper;

        public PersonController(IRepositoryReadConductor<Person> repositoryReadConductor, IRepositoryCreateConductor<Person> repositoryCreateConductor, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryReadConductor = repositoryReadConductor;
            _repositoryCreateConductor = repositoryCreateConductor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allUsers = _repositoryReadConductor.FindAll();
            var result = _mapper.Map<IEnumerable<PersonDto>>(allUsers.ResultObject.Where(e => e.DeletedOn == null));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var result = _repositoryReadConductor.FindById(id);
            var dto = _mapper.Map<PersonDto>(result.ResultObject);
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Create(PersonDto obj)
        {
            var person = _mapper.Map<Person>(obj);
            person.CreatedOn = DateTimeOffset.Now;
            var result = _repositoryCreateConductor.Create(person);
            if (result.HasErrors)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<PersonDto>(person));
        }
    }
}