
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace RepositoryPatternImplementation.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task Add(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int StudentRoll)
        {
            var student = await _context.Students.FirstOrDefaultAsync(e => e.StudentRollNumber == StudentRoll);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Student> Get(int StudentRoll)
        {
            return await _context.Students.FirstOrDefaultAsync(e => e.StudentRollNumber == StudentRoll); 
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task Edit(int StudentRollNumber, Student student)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(e => e.StudentRollNumber == StudentRollNumber);
            
            existingStudent.StudentName = student.StudentName;
            existingStudent.CollegeName = student.CollegeName;
            existingStudent.StudentCity = student.StudentCity;

            _context.Entry(existingStudent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
