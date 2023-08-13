﻿using Application.DTOs;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly IEducationService _educationService;
        public EducationsController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _educationService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                // To Do: log the exceptions
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                var result = await _educationService.GetById(id);
                if (result is null) return StatusCode(StatusCodes.Status204NoContent);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EducationDTO model)
        {
            try
            {
                if (model is null || !ModelState.IsValid) return BadRequest(ModelState);

                await _educationService.Add(model);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] EducationDTO model)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
