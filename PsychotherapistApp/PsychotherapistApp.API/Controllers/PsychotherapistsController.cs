using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PsychotherapistApp.API.Models;
using PsychotherapistApp.Data.Interfaces;
using PsychotherapistApp.Data.Models;
using System.Linq;

namespace PsychotherapistApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PsychotherapistsController : ControllerBase
    { 
        private readonly IPsychotherapistRepository _psychotherapistRepository;
        private readonly IMapper _mapper;

        public PsychotherapistsController(IPsychotherapistRepository psychotherapistRepository, IMapper mapper)
        {
            _psychotherapistRepository = psychotherapistRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_psychotherapistRepository.GetAll().ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var record = _psychotherapistRepository.GetById(id);

            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }

        [HttpPost]
        public IActionResult Add(PsychotherapistDTO psychotherapist)
        {
            var result = _psychotherapistRepository.Add(_mapper.Map<Psychotherapist>(psychotherapist));

            return CreatedAtAction(nameof(Add), JsonConvert.SerializeObject(result));
        }

        [HttpPut]
        public IActionResult Update(PsychotherapistDTO psychotherapist)
        {
            if (_psychotherapistRepository.GetById(psychotherapist.Id) == null)
            {
                return NotFound();
            }

            var result = _psychotherapistRepository.Update(_mapper.Map<Psychotherapist>(psychotherapist));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_psychotherapistRepository.GetById(id) == null)
            {
                return NotFound();
            }

            _psychotherapistRepository.DeleteById(id);

            return NoContent();
        }
    }
}
