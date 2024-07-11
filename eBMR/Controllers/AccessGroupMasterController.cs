using DataEntity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;

namespace eBMR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessGroupMasterController : ControllerBase
    {
        private readonly IAccessGroupMaster _repository;

        public AccessGroupMasterController(IAccessGroupMaster repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var accessGroupMasters = await _repository.GetAll();
            return Ok(accessGroupMasters);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var accessGroupMasters = await _repository.GetById(id);
            return Ok(accessGroupMasters);
        }

        [HttpPost]
        public async Task<IActionResult> Post(tblAccessGroupMaster tblAccessGroupMaster)
        {
            var accessGroupMasters = await _repository.Add(tblAccessGroupMaster);
            return Ok(accessGroupMasters);
        }

        [HttpPut]
        public async Task<IActionResult> Put(tblAccessGroupMaster tblAccessGroupMaster)
        {
            var accessGroupMaster = _repository.Update(tblAccessGroupMaster);
            return Ok(accessGroupMaster);
        }
    }
}
