using Microsoft.AspNetCore.Mvc;
using TaskProjects.Commons.Dto;
using TaskProjects.Interfaces.Application;

namespace TaskProjects.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("{projectId}")]
        public IActionResult Get(string projectId)
        {
            var project = _projectService.Get(projectId);
            return Ok(project);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var projects = _projectService.GetAll();
            return Ok(projects);
        }

        [HttpPost]
        public IActionResult Insert(ProjectDto projectDto)
        {
            var insertProject = _projectService.Insert(projectDto);
            return Ok(insertProject);
        }

        [HttpPut]
        public IActionResult Update(ProjectDto projectDto)
        {
            var insertProject = _projectService.Update(projectDto);
            return Ok(insertProject);
        }

        [HttpGet("GetAllPagination/{pageNumber}/{pageSize}/{userCreate}")]
        public IActionResult GetAllWithPagination(int pageNumber, int pageSize, string userCreate)
        {
            var result = _projectService.GetAllWithPagination(pageNumber, pageSize, userCreate);
            return Ok(result);
        }

        [HttpDelete("{projectId}")]
        public IActionResult Delete(string projectId)
        {
            var insertProject = _projectService.Delete(projectId);
            return Ok(insertProject);
        }
    }
}