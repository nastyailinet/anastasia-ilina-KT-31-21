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
            var avgMark = await marks
                                    .Where(m => m.MarkDate.Year == filter.Year)                                      
                                    .AverageAsync(m => m.MarkValue, cancellationToken); 

            return avgMark;
            
        }
    }
}
