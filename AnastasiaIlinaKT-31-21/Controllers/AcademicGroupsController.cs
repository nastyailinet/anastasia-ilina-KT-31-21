using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnastasiaIlinaKT_31_21.Database;
using AnastasiaIlinaKT_31_21.Models;
using AnastasiaIlinaKT_31_21.Interfaces.AcademicGroupsInterfaces;
using AnastasiaIlinaKT_31_21.Filters.AcademicGroupFilters;

namespace AnastasiaIlinaKT_31_21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicGroupsController : ControllerBase
    {
        private readonly ILogger<AcademicGroupsController> _logger;
        private readonly IAcademicGroupService _academicGroupService;

        private readonly StudentDbContext _context;

        public AcademicGroupsController(ILogger<AcademicGroupsController> logger, IAcademicGroupService academicGroupService    )
        {
            _logger = logger;
            _academicGroupService = academicGroupService;
        }

        [HttpPost(Name = "GetGroupFiltered")]

        public async Task<IActionResult> GetGroupAsynс(AcGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var groups = await _academicGroupService.GetGroupAsynс(filter, cancellationToken);

            return Ok(groups);
        }

       
    }
}
