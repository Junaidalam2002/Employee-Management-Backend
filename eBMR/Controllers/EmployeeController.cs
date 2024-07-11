using DataEntity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using Repository.IRepository;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace eBMR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _repository;
        private readonly IMultiEmployee _multiEmployee;

        public EmployeeController(IEmployee repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var obj = await _repository.GetAll();
            return Ok(obj);
        }

        [HttpGet("{empId}")]
        public async Task<IActionResult> GetById(string empId)
        {
            var obj = await _repository.GetById(empId);
            return Ok(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Post(tblEmployee tblEmployee)
        {
            await _repository.Add(tblEmployee);
            return Ok(tblEmployee);
        }
        [HttpPut]
        public async Task<IActionResult> Put(string empId, [FromBody] tblEmployee tblEmployee)
        {
            var obj = _repository.Update(tblEmployee);
            return Ok(tblEmployee);
        }
        [HttpPost]
        [Route("AddAll")]
        public async Task<IActionResult> AddAll(List<tblEmployee> model)
        {
            var obj = await _multiEmployee.AddAll(model);
            return Ok(obj);
        }
        //[HttpOptions]
        //public async Task<IActionResult> GetFalse()
        //{
        //    var obj = await _repository.LastInactive();
        //    return Ok(obj);
        //}
    }
}