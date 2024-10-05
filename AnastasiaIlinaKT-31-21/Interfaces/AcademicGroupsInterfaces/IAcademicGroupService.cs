using AnastasiaIlinaKT_31_21.Database;
using AnastasiaIlinaKT_31_21.Filters.AcademicGroupFilters;
using AnastasiaIlinaKT_31_21.Models;
using Microsoft.EntityFrameworkCore;


namespace AnastasiaIlinaKT_31_21.Interfaces.AcademicGroupsInterfaces
{
    public interface IAcademicGroupService
    {
        public Task<AcademicGroup[]> GetGroupAsynс(AcGroupFilter filter, CancellationToken cancellationToken);
    }

    public class AcademicGroupService : IAcademicGroupService
    {
        private readonly StudentDbContext _dbContext;

        public AcademicGroupService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<AcademicGroup[]> GetGroupAsynс(AcGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Set<AcademicGroup>().AsQueryable();

            if (filter.IsDeleted.HasValue)
            {
                query = query.Where(g => g.IsDeleted == filter.IsDeleted);
            }

            if(!string.IsNullOrEmpty(filter.Chars))
            {
                query = query.Where(g => g.Chars == filter.Chars);
            }

            if(filter.Year.HasValue)
            {
                query = query.Where(g => g.Year == filter.Year);
            }

            return await query.ToArrayAsync(cancellationToken);
        }
    }
}
