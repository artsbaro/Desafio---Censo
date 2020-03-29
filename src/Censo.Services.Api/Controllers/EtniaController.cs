using System;
using System.Collections.Generic;
using Censo.Services.Api.Errors;
using Censo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Censo.Application.Dtos.Etnia;

namespace Censo.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EtniaController : ControllerBase
    {
        private readonly IEtniaService _service;

        public EtniaController(IEtniaService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Create([FromBody] EtniaInsertDto item)
        {
            try
            {
                var id = _service.Create(item);
                return CreatedAtAction(nameof(Find), new { id }, item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Update([FromBody] EtniaDto item)
        {
            try
            {
                _service.Update(item);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new Error(ex));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //[HttpDelete("{id}")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(500)]
        //public IActionResult Remove(Guid id)
        //{
        //    try
        //    {
        //        _service.Remove(id);
        //        return Ok();
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return NotFound(new Error(ex));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EtniaDto>), 200)]
        [ProducesResponseType(500)]
        public IActionResult Find()
        {
            try
            {
                var result = _service.List();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EtniaDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        public IActionResult Find(byte id)
        {
            try
            {
                return Ok(_service.FindById(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(new Error(ex));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}