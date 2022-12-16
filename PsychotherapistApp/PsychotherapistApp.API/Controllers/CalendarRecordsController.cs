using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PsychotherapistApp.API.Models;
using PsychotherapistApp.Data.Interfaces;
using PsychotherapistApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychotherapistApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarRecordsController : ControllerBase
    {
        private readonly ICalendarRecordRepository _calendarRecordRepository;
        private readonly IMapper _mapper;

        public CalendarRecordsController(ICalendarRecordRepository calendarRecordRepository, IMapper mapper)
        {
            _calendarRecordRepository = calendarRecordRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_calendarRecordRepository.GetAll().ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var record = _calendarRecordRepository.GetById(id);

            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }

        [HttpPost]
        public IActionResult Add(CalendarRecordDTO calendarRecord)
        {
            var result = _calendarRecordRepository.Add(_mapper.Map<CalendarRecord>(calendarRecord));

            return CreatedAtAction(nameof(Add), JsonConvert.SerializeObject(result));
        }

        [HttpPut]
        public IActionResult Update(CalendarRecordDTO calendarRecord)
        {
            if (_calendarRecordRepository.GetById(calendarRecord.Id) == null)
            {
                return NotFound();
            }

            var result = _calendarRecordRepository.Update(_mapper.Map<CalendarRecord>(calendarRecord));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_calendarRecordRepository.GetById(id) == null)
            {
                return NotFound();
            }

            _calendarRecordRepository.DeleteById(id);

            return NoContent();
        }
    }
}
