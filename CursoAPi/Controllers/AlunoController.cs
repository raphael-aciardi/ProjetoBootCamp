using AutoMapper;
using CursoAPi.Data;
using CursoAPi.Data.Dtos.Aluno;
using CursoAPi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly CursoContext _context;
        private readonly IMapper _mapper;

        // O CursoContext e o IMapper serão injetados automaticamente
        public AlunoController(CursoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] CreateAlunoDto alunoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Aluno aluno = _mapper.Map<Aluno>(alunoDto);

            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            return CreatedAtAction(nameof(AddStudent), aluno);
        }

        [HttpGet]
        [Route("RecuperaAlunos")]
        public ActionResult<IEnumerable<ReadAlunoDto>> GetStudents()
        {
            var alunos = _context.Alunos.ToList();

            if (alunos == null || alunos.Count == 0)
                return NotFound("Nenhum aluno encontrado.");

            return Ok(_mapper.Map<List<ReadAlunoDto>>(alunos));
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentsById(int id)
        {
            var student = _context.Alunos
                .FirstOrDefault(student => student.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            var studentDto = _mapper.Map<ReadAlunoDto>(student);
            return Ok(studentDto);
        }
    }
}
