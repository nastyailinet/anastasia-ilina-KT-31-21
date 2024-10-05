using AnastasiaIlinaKT_31_21.Database;
using AnastasiaIlinaKT_31_21.Filters.MarkFilters;
using AnastasiaIlinaKT_31_21.Models;
using Microsoft.EntityFrameworkCore;



namespace AnastasiaIlinaKT_31_21.Interfaces.MarksInterfaces
{
    public interface IAvgGroupMarkService
    {
        public Task<double> GetAvgGroupMarkAsync(AvgGroupMarkByDisciplineFilter filter, CancellationToken cancellationToken);
    }

    public class AvgGroupMarkService : IAvgGroupMarkService
    {
        private readonly StudentDbContext _dbContext;
        
        public AvgGroupMarkService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<double> GetAvgGroupMarkAsync(AvgGroupMarkByDisciplineFilter filter, CancellationToken cancellationToken = default)
        {
            var marks = _dbContext.Set<Mark>().AsQueryable();

            var students = _dbContext.Set<Student>().AsQueryable();

            var groups = _dbContext.Set<AcademicGroup>().AsQueryable();

            var disciplines = _dbContext.Set<Discipline>().AsQueryable();

            var filteredMarks = from m in marks
                                join s in students on m.StudentId equals s.StudentId
                                join g in groups on s.GroupId equals g.GroupId
                                join d in disciplines on m.DisciplineId equals d.DisciplineId
                                where filter.Chars == g.Chars && filter.Number == g.Number && filter.Year == g.Year && filter.DisciplineName == d.DisciplineName
                                select m.MarkValue;
            
            var avgMark = await filteredMarks.AverageAsync(cancellationToken);

            return avgMark;
        }
    }
}
