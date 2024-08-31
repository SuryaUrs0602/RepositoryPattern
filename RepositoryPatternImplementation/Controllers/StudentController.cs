using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternImplementation.Models;
using RepositoryPatternImplementation.Models.Repository;

namespace RepositoryPatternImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentrepository;

        public StudentController(IStudentRepository studentrepository)
        {
            _studentrepository = studentrepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllStudents()
        {
            var students = await _studentrepository.GetAll();
            return Ok(students);
        }

        [HttpGet("{StudentRollNumber}")]
        public async Task<ActionResult> GetStudentByRollNumber(int StudentRollNumber)
        {
            var student = await _studentrepository.Get(StudentRollNumber);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent(Student student)
        {
            await _studentrepository.Add(student);
            return Created();
        }

        [HttpDelete("{StudentRollNumber}")]
        public async Task<ActionResult> DeleteStudent(int StudentRollNumber)
        {
            await _studentrepository.Delete(StudentRollNumber);

            return NoContent();
        }

        [HttpPut("{StudentRollNumber}")]
        public async Task<ActionResult> UpdateStudent(int StudentRollNumber, Student student)
        {
            await _studentrepository.Edit(StudentRollNumber, student);
            return NoContent();
        }
    }
}
