using AnastasiaIlinaKT_31_21.Database;
using AnastasiaIlinaKT_31_21.Filters.MarkFilters;
using AnastasiaIlinaKT_31_21.Models;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaIlinaKT_31_21.Interfaces.MarksInterfaces
{
    public interface IAvgYearMarkService
    {
        public Task<double> GerAvgMarkByYearAsync(AvgMarkByYearFilter filter, CancellationToken cancellationToken);
    }

    public class AvgYearMarkService : IAvgYearMarkService
    {
        private readonly StudentDbContext _dbContext; 

        public AvgYearMarkService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }   

        public async Task<double> GerAvgMarkByYearAsync(AvgMarkByYearFilter filter, CancellationToken cancellationToken)
        {
            var marks = _dbContext.Set<Mark>().AsQueryable();

            var disciplines = _dbContext.Set<Discipline>().AsQueryable();

            var filteredMarks = from m in marks
                                join d in disciplines on m.DisciplineId equals d.DisciplineId
                                where filter.DisciplineName == d.DisciplineName
                                   && filter.Year == m.MarkDate.Year
                                select m.MarkValue;

            var avgMark = await filteredMarks.AverageAsync(cancellationToken);

            return avgMark; 
        }
    }
}
