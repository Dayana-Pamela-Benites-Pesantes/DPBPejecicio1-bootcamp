using Bootcamp.Queries.Person;
using Bootcamp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonQueries _personQueries;
        public PruebaController(IPersonRepository personRepository, IPersonQueries personQueries)
        {
            _personRepository = personRepository;
            _personQueries = personQueries;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _personQueries.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _personQueries.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Model.Person person)
        {
            var result = await _personRepository.Create(person);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Model.Person person)
        {
            var result = await _personRepository.Update(person);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _personRepository.Delete(id);
            return Ok(result);
        }
    }

}
