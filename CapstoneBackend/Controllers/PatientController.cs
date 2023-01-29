using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CapstoneBackend.Services;
using CapstoneBackend.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapstoneBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly PatientService _patientService;

        public PatientController(PatientService patientService) =>
            _patientService = patientService;

        [HttpGet]
        public async Task<List<Patient>> Get() =>
            await _patientService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get(string id)
        {
            var patient = await _patientService.GetAsync(id);

            if (patient is null)
            {
                return NotFound();
            }

            return patient;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Patient newPatient)
        {
            await _patientService.CreateAsync(newPatient);

            return CreatedAtAction(nameof(Get), new { id = newPatient.Id }, newPatient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Patient updatedPatient)
        {
            var patient = await _patientService.GetAsync(id);

            if (patient is null)
            {
                return NotFound();
            }

            updatedPatient.Id = patient.Id;

            await _patientService.UpdateAsync(id, updatedPatient);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var patient = await _patientService.GetAsync(id);

            if (patient is null)
            {
                return NotFound();
            }

            await _patientService.RemoveAsync(id);

            return NoContent();
        }
    }
}

