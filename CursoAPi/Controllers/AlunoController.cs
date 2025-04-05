using AutoMapper;
using CursoAPi.Data;
using CursoAPi.Data.Dtos.Aluno;
using CursoAPi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly CursoContext _context;
        private readonly IMapper _mapper;

        public AlunoController(CursoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] CreateAlunoDto alunoDto)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
   
                Aluno aluno = _mapper.Map<Aluno>(alunoDto);

        
                await _context.Alunos.AddAsync(aluno);
                await _context.SaveChangesAsync();

                ReadAlunoDto readDto = _mapper.Map<ReadAlunoDto>(aluno);

             
                return CreatedAtAction(
                    nameof(GetStudentById),               
                    new { id = aluno.Id },               
                    readDto                               
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        [HttpGet]
        [Route("RecuperaAlunos")]
        public async Task<ActionResult<IEnumerable<ReadAlunoDto>>> GetStudents()
        {

            var alunos = await _context.Alunos.AsNoTracking().ToListAsync();

  
            if (alunos.Count == 0)
                return NotFound("Nenhum aluno encontrado.");

            var alunosDto = _mapper.Map<List<ReadAlunoDto>>(alunos);

            return Ok(alunosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id) 
        { 

            var student = await _context.Alunos.AsNoTracking()
                .FirstOrDefaultAsync(student => student.Id == id);

            if (student == null)
            {

                return NotFound($"Aluno com ID {id} não encontrado.");
            }

            var studentDto = _mapper.Map<ReadAlunoDto>(student);
            return Ok(studentDto);
        }

    }
}
