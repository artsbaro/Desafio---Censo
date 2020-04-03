using System;
using System.Collections.Generic;
using Censo.Services.Api.Errors;
using Censo.Application.Interfaces;
using Censo.Domain.Filters;
using Microsoft.AspNetCore.Mvc;
using Censo.Application.Dtos.Pessoa;

namespace Censo.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PessoaController : ControllerBase

    {
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService receitaService)
        {
            _service = receitaService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public IActionResult Create([FromBody] PessoaInsertDto item)
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
        [ProducesResponseType(500)]
        public IActionResult Update([FromBody] PessoaUpdateDto item)
        {
            try
            {
                _service.Update(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Remove(Guid id)
        {
            try
            {
                _service.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<PessoaDto>), 200)]
        [ProducesResponseType(500)]
        public IActionResult Find([FromQuery] string nome, 
                                  [FromQuery] string sobreNome,
                                  [FromQuery] string regiao,
                                  [FromQuery] string nomeDaMae,
                                  [FromQuery] string nomeDoPai,
                                  [FromQuery] byte? generoId,
                                  [FromQuery] byte? escolaridadeId,
                                  [FromQuery] byte? etniaId)
        {
            var filter = new PessoaFilter { 
                Nome = nome,
                SobreNome = sobreNome,
                Regiao = regiao,
                NomeDaMae = nomeDaMae,
                NomeDoPai = nomeDoPai,
                EscolaridadeId  =escolaridadeId,
                EtniaId = etniaId,
                GeneroId = generoId
            };

            try
            {
                var result = _service.List(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PessoaDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        public IActionResult Find(Guid id)
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

        [HttpGet("GetPercent/{regiao}/{nome}")]
        [ProducesResponseType(typeof(IEnumerable<PessoaDto>), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetPercent(string regiao, string nome)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(regiao))
                    return BadRequest(regiao);

                if (string.IsNullOrWhiteSpace(nome))
                    return BadRequest(nome);

                var result = _service.GetPercentPersonWhitNameByRegion(regiao, nome);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}