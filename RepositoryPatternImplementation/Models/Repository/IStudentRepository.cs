namespace RepositoryPatternImplementation.Models.Repository
{
    public interface IStudentRepository
    {
        Task Add(Student student);
        Task<IEnumerable<Student>> GetAll();
        Task<Student> Get(int StudentRoll);
        Task Edit(int StudentRollNumber, Student student);
        Task Delete(int StudentRoll);

    }
}
