using System;
using capstone2022_backend.Models;
using capstone2022_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace capstone2022_backend.Controllers
{
	public class DiagnosticsController
	{
        [ApiController]
        [Route("api/[controller]")]
        public class DiagnosticController : Controller
        {
            private readonly DiagnosticsService _diagnosticService;

            public DiagnosticController(DiagnosticsService diagnosticService) =>
                _diagnosticService = diagnosticService;

            [HttpGet]
            public async Task<List<Diagnostics>> Get() =>
                await _diagnosticService.GetAsync();

            [HttpGet("{id}")]
            public async Task<ActionResult<Diagnostics>> Get(string id)
            {
                var diagnostic = await _diagnosticService.GetAsync(id);

                if (diagnostic is null)
                {
                    return NotFound();
                }

                return diagnostic;
            }

            [HttpPost]
            public async Task<IActionResult> Post(Diagnostics newDiagnostic)
            {
                await _diagnosticService.CreateAsync(newDiagnostic);

                return CreatedAtAction(nameof(Get), new { id = newDiagnostic.Id }, newDiagnostic);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(string id, Diagnostics updatedDiagnostic)
            {
                var diagnostic = await _diagnosticService.GetAsync(id);

                if (diagnostic is null)
                {
                    return NotFound();
                }

                updatedDiagnostic.Id = diagnostic.Id;

                await _diagnosticService.UpdateAsync(id, updatedDiagnostic);

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(string id)
            {
                var diagnostic = await _diagnosticService.GetAsync(id);

                if (diagnostic is null)
                {
                    return NotFound();
                }

                await _diagnosticService.RemoveAsync(id);

                return NoContent();
            }
        }
    }
}

