using ElectroLabBusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ElectroLabModels.Models;
using ElectroLabModels.SystemModels;

namespace ElectroLabAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/courses?searchTerm=arduino&limit=10
        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetCourses([FromQuery] string? searchTerm = null, [FromQuery] int limit = 12)
        {
            var result = await _courseService.GetCoursesAsync(searchTerm, limit);
            return Ok(result);
        }

        // GET: api/courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseDetails(int id)
        {
            var course = await _courseService.GetCourseDetailsAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }
    }
}

