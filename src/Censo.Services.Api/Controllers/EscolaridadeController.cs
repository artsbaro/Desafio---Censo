﻿using System;
using System.Collections.Generic;
using Censo.Services.Api.Errors;
using Censo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Censo.Application.Dtos.Escolaridade;

namespace Censo.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EscolaridadeController : ControllerBase
    {
        private readonly IEscolaridadeService _service;

        public EscolaridadeController(IEscolaridadeService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Create([FromBody] EscolaridadeInsertDto item)
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
        public IActionResult Update([FromBody] EscolaridadeDto item)
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
        [ProducesResponseType(typeof(IEnumerable<EscolaridadeDto>), 200)]
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
        [ProducesResponseType(typeof(EscolaridadeDto), 200)]
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