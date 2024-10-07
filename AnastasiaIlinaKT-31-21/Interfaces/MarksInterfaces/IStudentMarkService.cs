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

            var studentMark = await marks
                                        .Where(m => m.Student.LastName == filter.LastName &&
                                               m.Student.FirstName == filter.FirstName &&
                                               m.Student.MiddleName == filter.MiddleName &&
                                               m.Discipline.DisciplineName == filter.DisciplineName &&
                                               m.MarkDate == filter.MarkDate)
                                        .Select(m => (int?)m.MarkValue) 
                                        .FirstOrDefaultAsync(cancellationToken);

            return studentMark;
        }
    }
}
