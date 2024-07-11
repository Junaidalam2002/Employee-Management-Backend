using DataEntity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;

namespace eBMR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _repository;

        public DepartmentController(IDepartment repository)
        {
            _repository = repository;
        }
        
        
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var department = await _repository.GetAll();
            return Ok(department);
        }

        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var department = await _repository.GetById(id);
            return Ok(department);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Post(tblDepartment tblDepartment)
        {
            var department = await _repository.Add(tblDepartment);
            return Ok(department);
        }
        
        
        [HttpPut("{id}")]
        public Task Put(tblDepartment department)
        {
            var dpr = _repository.Update(department);
            return dpr;
        }
    }
}