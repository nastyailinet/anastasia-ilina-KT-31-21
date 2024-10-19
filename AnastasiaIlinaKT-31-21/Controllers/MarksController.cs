using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnastasiaIlinaKT_31_21.Database;
using AnastasiaIlinaKT_31_21.Models;
using AnastasiaIlinaKT_31_21.Filters.MarkFilters;
using AnastasiaIlinaKT_31_21.Interfaces.MarksInterfaces;

namespace AnastasiaIlinaKT_31_21.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly ILogger<MarksController> _logger;
        private readonly IAvgGroupMarkService _avgGrMarkService;
        private readonly IStudentMarkService _studentMarkService;
        private readonly IAvgYearMarkService _avgYearMarkService;


        private readonly StudentDbContext _context;

        public MarksController(ILogger<MarksController> logger, IAvgGroupMarkService avgGrMarkService, IStudentMarkService studentMarkService, IAvgYearMarkService avgYearMarkService)
        {
            _logger = logger;
            _avgGrMarkService = avgGrMarkService;
            _studentMarkService = studentMarkService;
            _avgYearMarkService = avgYearMarkService;
        }        

        // POST: api/Marks
        [HttpPost(Name = "average-grade/group")]
        public async Task<IActionResult> GetAvgGroupMarkAsync(AvgGroupMarkByDisciplineFilter filter, CancellationToken cancellationToken)
        {
            var avgMark = await _avgGrMarkService.GetAvgGroupMarkAsync(filter, cancellationToken);

            return Ok(avgMark);
        }

        [HttpPost(Name = "student/grade")]
        public async Task<IActionResult> GetMarkForStudentAsync(StudentMarkFilter filter, CancellationToken cancellationToken)
        {
            var mark = await _studentMarkService.GetStudentMarkAsync(filter, cancellationToken);

            return Ok(mark);
        }

        [HttpPost(Name = "average-grade/year")]
        public async Task<IActionResult> GetAvgMarkByYearAsync(AvgMarkByYearFilter filter, CancellationToken cancellationToken)
        {
            var mark = await _avgYearMarkService.GerAvgMarkByYearAsync(filter, cancellationToken);

            return Ok(mark);
        }
    }
}
