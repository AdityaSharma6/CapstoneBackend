﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using capstone2022_backend.Services;
using capstone2022_backend.Models;

namespace capstone2022_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        private readonly DoctorService _doctorService;

        public DoctorController(DoctorService doctorService) =>
            _doctorService = doctorService;

        [HttpGet]
        public async Task<List<Doctor>> Get() =>
            await _doctorService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> Get(string id)
        {
            var doctor = await _doctorService.GetAsync(id);

            if (doctor is null)
            {
                return NotFound();
            }

            return doctor;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Doctor newDoctor)
        {
            await _doctorService.CreateAsync(newDoctor);

            return CreatedAtAction(nameof(Get), new { id = newDoctor.Id }, newDoctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Doctor updatedDoctor)
        {
            var doctor = await _doctorService.GetAsync(id);

            if (doctor is null)
            {
                return NotFound();
            }

            updatedDoctor.Id = doctor.Id;

            await _doctorService.UpdateAsync(id, updatedDoctor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var doctor = await _doctorService.GetAsync(id);

            if (doctor is null)
            {
                return NotFound();
            }

            await _doctorService.RemoveAsync(id);

            return NoContent();
        }
    }
}

