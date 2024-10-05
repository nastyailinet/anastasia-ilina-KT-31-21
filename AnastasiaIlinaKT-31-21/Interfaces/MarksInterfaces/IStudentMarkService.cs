using AnastasiaIlinaKT_31_21.Database;
using AnastasiaIlinaKT_31_21.Filters.MarkFilters;
using AnastasiaIlinaKT_31_21.Models;
using Microsoft.EntityFrameworkCore;


namespace AnastasiaIlinaKT_31_21.Interfaces.MarksInterfaces
{
    public interface IStudentMarkService
    {
        public Task<int?> GetStudentMarkAsync(StudentMarkFilter filter, CancellationToken cancellationToken = default);
    }

    public class StudentMarkService : IStudentMarkService
    {
        private readonly StudentDbContext _dbContext;

        public StudentMarkService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int?> GetStudentMarkAsync(StudentMarkFilter filter, CancellationToken cancellationToken = default)
        {
            var marks = _dbContext.Set<Mark>().AsQueryable();

            var students = _dbContext.Set<Student>().AsQueryable();

            var disciplines = _dbContext.Set<Discipline>().AsQueryable();

            var studentMarkQuery = from m in marks
                              join s in students on m.StudentId equals s.StudentId
                              join d in disciplines on m.DisciplineId equals d.DisciplineId
                              where filter.LastName == s.LastName 
                                 && filter.FirstName == s.FirstName 
                                 && filter.MiddleName == s.MiddleName
                                 && filter.DisciplineName == d.DisciplineName 
                                 && filter.MarkDate == m.MarkDate
                              select m.MarkValue;

            var studentMark = await studentMarkQuery.FirstOrDefaultAsync(cancellationToken);

            return studentMark;
        }
    }
}
