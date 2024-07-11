using DataEntity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.Repository;

namespace eBMR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignation _repository;

        public DesignationController(IDesignation repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var department = await _repository.GetAll();
            return Ok(department);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var designation = await _repository.GetById(id);
            if (designation == null)
            {
                return NotFound();
            }
            return Ok(designation);
        }
        [HttpPost]
        public async Task<IActionResult> Post(tblDesignation tblDesignation)
        {
            await _repository.Add(tblDesignation);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(tblDesignation designation)
        {
            var obj = _repository.Update(designation);
            return Ok(obj);
        }
    }
}
