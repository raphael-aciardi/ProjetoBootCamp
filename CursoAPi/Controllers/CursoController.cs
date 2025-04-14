using AutoMapper;
using CursoAPi.Data;
using CursoAPi.Data.Dtos.Curso;
using CursoAPi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CursoAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly CursoContext _context;
        private readonly IMapper _mapper;

        public CursoController(CursoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddCurso([FromBody] CreateCursoDto cursoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var curso = _mapper.Map<Curso>(cursoDto);

            _context.Cursos.Add(curso);
            _context.SaveChanges();

            var readCursoDto = _mapper.Map<ReadCursoDto>(curso);
            return CreatedAtAction(nameof(GetCursoById), new { id = curso.Id }, readCursoDto);
        }

        [HttpGet]
        [Route("RecuperaCursos")]
        public ActionResult<IEnumerable<ReadCursoDto>> GetCursos()
        {
            var cursos = _context.Cursos.ToList();

            if (cursos == null || cursos.Count == 0)
                return NotFound("Nenhum curso encontrado.");

            return Ok(_mapper.Map<List<ReadCursoDto>>(cursos));
        }

        [HttpGet("{id}")]
        public IActionResult GetCursoById(int id)
        {
            var curso = _context.Cursos.FirstOrDefault(c => c.Id == id);

            if (curso == null)
                return NotFound("Id incorreto");

            var cursoDto = _mapper.Map<ReadCursoDto>(curso);
            return Ok(cursoDto);
        }
    }
}
