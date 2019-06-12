using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceManagement.Data.Repositories;
using ConferenceManagement.Web.Mappers;
using ConferenceManagement.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManagement.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceController : BaseApiController
    {
        private readonly IConferenceRepository _conferenceRepository;

        public ConferenceController(IConferenceRepository conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        [HttpGet]
        public IEnumerable<ConferenceViewModel> Get()
        {
            return _conferenceRepository.Get().Select(s => s.ToViewModel());
        }

        [HttpGet("{id}", Name = "Get")]
        public ConferenceViewModel Get(int id)
        {
            return _conferenceRepository.GetBy(id).ToViewModel();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ConferenceViewModel value)
        {
            if (ModelState.IsValid)
            {
                var newId = _conferenceRepository.Add(value.ToModel());
                return Ok(newId);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ConferenceViewModel value)
        {
            if (ModelState.IsValid)
            {
                _conferenceRepository.Update(value.ToModel());
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _conferenceRepository.Delete(id);
            return Ok();
        }
    }
}
