using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskProjects.Commons.Dto;
using TaskProjects.Commons.Response;
using TaskProjects.Domain.Entities;
using TaskProjects.Interfaces.Application;
using TaskProjects.Interfaces.Persistence;

namespace TaskProjects.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repoProject;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(IProjectRepository repoProject,
                              IMapper mapper,
                              IMediator mediator,
                              ILogger<ProjectService> logger)
        {
            _repoProject = repoProject;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        #region Synchronous Methods
        public Response<bool> Insert(ProjectDto entity)
        {
            Response<bool> response = new Response<bool>();
            entity.Id = entity.Id == Guid.Empty ? Guid.NewGuid() : entity.Id; 
            var projectEntity = _mapper.Map<Project>(entity);
            _repoProject.Insert(projectEntity);
            response.IsSuccess = true;
            response.Message = "Project created";

            return response;
        }

        public Response<bool> Update(ProjectDto entity)
        {
            Response<bool> response = new Response<bool>();
            var projectEntity = _mapper.Map<Project>(entity);
            _repoProject.Update(projectEntity);
            response.IsSuccess = true;
            response.Message = "";

            return response;
        }
        public Response<bool> Delete(string id)
        {
            Response<bool> response = new Response<bool>();
            var repoResponse = _repoProject.Delete(id);
            response.IsSuccess = repoResponse;
            response.Message = "";

            return response;
        }
        public Response<ProjectDto> Get(string id)
        {
            Response<ProjectDto> response = new Response<ProjectDto>();
            
            var project = _repoProject.Get(id);
            response.Data = _mapper.Map<ProjectDto>(project);
            response.IsSuccess = true;
            response.Message = "";

            return response;
        }

        public Response<IEnumerable<ProjectDto>> GetAll()
        {
            Response<IEnumerable<ProjectDto>> response = new Response<IEnumerable<ProjectDto>>();

            var projects = _repoProject.GetAll();
            response.Data = _mapper.Map<IEnumerable<ProjectDto>>(projects);
            response.IsSuccess = true;
            response.Message = "";

            return response;
        }

        public ResponsePagination<IEnumerable<ProjectDto>> GetAllWithPagination(int pageNumber, int pageSize, string userId)
        {
            ResponsePagination<IEnumerable<ProjectDto>> response = new ResponsePagination<IEnumerable<ProjectDto>>();

            var count = _repoProject.Count();

            var projects = _repoProject.GetAllWithPagination(pageNumber, pageSize, userId);

            response.Data = _mapper.Map<IEnumerable<ProjectDto>>(projects);

            if (response.Data is not null)
            {
                response.PageNumber = pageNumber;
                response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                response.TotalCount = count;
                response.IsSuccess = true;
                response.Message = "Consulta paginada exitosa";
            }

            return response;
        }


        #endregion

        #region Asynchronous Methods


        public async Task<Response<bool>> InsertAsync(ProjectDto entity)
        {
            Response<bool> response = new Response<bool>();

            //response.Data = await _repoProject.Insert();
            response.IsSuccess = true;
            response.Message = "";

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(ProjectDto entity)
        {
            Response<bool> response = new Response<bool>();

            //response.Data = await _repoProject.Insert();
            response.IsSuccess = true;
            response.Message = "";

            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string id)
        {
            Response<bool> response = new Response<bool>();

            //response.Data = await _repoProject.Insert();
            response.IsSuccess = true;
            response.Message = "";

            return response;
        }
        
        public async Task<Response<ProjectDto>> GetAsync(string id)
        {
            Response<ProjectDto> response = new Response<ProjectDto>();

            //response.Data = await _repoProject.Insert();
            response.IsSuccess = true;
            response.Message = "";

            return response;
        }

        public async Task<ResponsePagination<IEnumerable<ProjectDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            ResponsePagination<IEnumerable<ProjectDto>> response = new ResponsePagination<IEnumerable<ProjectDto>>();

            //response.Data = await _repoProject.Insert();
            response.IsSuccess = true;
            response.Message = "";

            return response;
        }

        public async Task<Response<IEnumerable<ProjectDto>>> GetAllAsync()
        {
            Response<IEnumerable<ProjectDto>> response = new Response<IEnumerable<ProjectDto>>();

            //response.Data = await _repoProject.Insert();
            response.IsSuccess = true;
            response.Message = "";

            return response;
        }

        #endregion
    }
}