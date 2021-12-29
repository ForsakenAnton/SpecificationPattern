using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        public readonly IGenericRepository<Developer> _repository;

        public object DevelopersWithPersonalProjectsSpecification { get; private set; }

        public DevelopersController(IGenericRepository<Developer> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Developer>>> GetAll()
        {
            IEnumerable<Developer> developers = await _repository.GetAllAsync();
            return Ok(developers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> GetById(int id)
        {
            Developer developer = await _repository.GetByIdAsync(id);
            if(developer is null)
            {
                return NotFound();
            }

            return Ok(developer);
        }

        [HttpGet("includePersonalProjectsSpecify")]
        //public async Task<ActionResult<IEnumerable<Developer>>> GetAllWithPersonalProjects()
        public IActionResult GetAllWithPersonalProjects()
        {
            var specification = new DevelopersWithPersonalProjectsSpecification();
            IEnumerable<Developer> developers = _repository.FindWithSpecificationPattern(specification);

            return Ok(developers);
        }

        [HttpGet("includeStagingPersonalProjectsSpecify")]
        //public async Task<ActionResult<IEnumerable<Developer>>> GetAllWithPersonalProjects()
        public IActionResult GetAllWithStagingPersonalProjects()
        {
            var specification = new DevelopersWithStagingPersonalProjectsSpecification();
            IEnumerable<Developer> developers = _repository.FindWithSpecificationPattern(specification);

            return Ok(developers);
        }



        [HttpPost]
        public async Task<ActionResult<Developer>> CreateDeveloper(Developer developer)
        {
            if (developer is null)
            {
                return BadRequest();
            }
            Developer createdDeveloper = await _repository.AddAsync(developer);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdDeveloper.Id },
                createdDeveloper);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Developer>> UpdateDeveloper(int id, Developer developer)
        {
            if (id != developer.Id)
            {
                return BadRequest();
            }

            try
            {
                Developer updatedDeveloper = await _repository.UpdateAsync(developer);
                return updatedDeveloper;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeveloperExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Developer>> DeleteDeveloper(int id)
        {
            Developer developerToDelete = await _repository.GetByIdAsync(id);
            //Developer developerToDelete = _repository
            //    .FindWithSpecificationPattern(new OneDeveloperWithPersonalProjectsSpecification(id))
            //    .FirstOrDefault();

            if (developerToDelete is null)
            {
                return NotFound($"Developer with Id = { id } not found");
            }

            return await _repository.RemoveAsync(id);
            //return await _repository.RemoveAsync(developerToDelete);
        }





        private bool DeveloperExists(int id)
        {
            return _repository.GetAllAsync().Result.Any(e => e.Id == id);
        }
    }
}
