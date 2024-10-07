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

            var avgMark = await marks.Where(m => m.Student.Group.Chars == filter.Chars &&
                                                 m.Student.Group.Number == filter.Number &&
                                                 m.Student.Group.Year == filter.Year &&
                                                 m.Discipline.DisciplineName == filter.DisciplineName)
                                            .AverageAsync(m => m.MarkValue, cancellationToken);
                               
                                

            return avgMark;
        }
    }
}
