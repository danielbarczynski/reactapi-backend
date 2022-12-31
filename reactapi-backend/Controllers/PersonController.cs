using Microsoft.AspNetCore.Mvc;

namespace reactapi_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _context;
        public PersonController(PersonContext context)
        {
            _context = context;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            var persons = _context.Persons;
            return Ok(persons);
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = _context.Persons.FirstOrDefault(x => x.Id == id);
            return Ok(person);
        }

        // POST api/<PersonController>
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return Ok(person);
        }

        // PATCH api/<PersonController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Person person)
        {
            var updatedPerson = _context.Persons.Find(id);
            updatedPerson.Name = person.Name;
            updatedPerson.Age = person.Age;
            _context.SaveChanges();
            return Ok(updatedPerson);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var person = _context.Persons.Find(id);
            _context.Persons.Remove(person);
            _context.SaveChanges();
            return Ok(person);
        }
    }
}
