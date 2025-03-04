using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TaskProjects.Domain.Entities;
using TaskProjects.Interfaces.Persistence;
using TaskProjects.Persistence.Context;

namespace TaskProjects.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskProjectContext _efContex;
        private readonly DapperContext _dContext;
        private readonly ILogger<ProjectRepository> _logger;

        public ProjectRepository(TaskProjectContext efContex,
                                 DapperContext dContext,
                                 ILogger<ProjectRepository> logger)
        {
            _efContex = efContex;
            _dContext = dContext;
            _logger = logger;
        }


        #region Synchronous Methods
        public bool Insert(Project entity)
        {
            try
            {
                var result = _efContex.Projects.Add(entity);
                _efContex.SaveChanges();
                return result.State > 0;

            }
            catch (Exception ex)
            {
                _logger.LogError($"from class {nameof(ProjectRepository)} method {nameof(Insert)} /n message: {ex.Message}");
                throw;
            }
        }

        public bool Update(Project entity)
        {
            try
            {
                var project = _efContex.Projects.FirstOrDefault(x => x.Id == entity.Id);
                if (project == null)
                {
                    return false;
                }
                project.Name = entity.Name;
                project.Description = entity.Description;
                project.CreatedBy = entity.CreatedBy;
                project.AssignedTo = entity.AssignedTo;
                _efContex.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError($"from class {nameof(ProjectRepository)} method {nameof(Update)} /n message: {ex.Message}");
                throw;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var project = _efContex.Projects.FirstOrDefault(x => x.Id == Guid.Parse(id));
                if (project == null)
                {
                    return false;
                }
                _efContex.Projects.Remove(project);
                _efContex.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"from class {nameof(ProjectRepository)} method {nameof(Insert)} /n message: {ex.Message}");
                throw;
            }
        }

        public Project Get(string id)
        {
            try
            {
                var project = _efContex.Projects.FirstOrDefault(x => x.Id == Guid.Parse(id));
                return project;
            }
            catch (Exception ex)
            {
                _logger.LogError($"from class {nameof(ProjectRepository)} method {nameof(Insert)} /n message: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Project> GetAll()
        {
            try
            {
                var projects = _efContex.Projects.ToList();
                return projects;
            }
            catch (Exception ex)
            {
                _logger.LogError($"from class {nameof(ProjectRepository)} method {nameof(Insert)} /n message: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Project> GetAllWithPagination(int pageNumber, int pageSize, string userId)
        {
            try
            {
                Guid user = Guid.Parse(userId);
                var projects = _efContex.Projects
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToList();

                return projects;
            }
            catch (Exception ex)
            {
                _logger.LogError($"from class {nameof(ProjectRepository)} method {nameof(GetAllWithPagination)} /n message: {ex.Message}");
                throw;
            }
        }

        public int Count()
        {
            try
            {
                var response = _efContex.Projects.Count();
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"from class {nameof(ProjectRepository)} method {nameof(Insert)} /n message: {ex.Message}");
                throw;
            }
        }

        #endregion

        #region Asynchronous Methods

        public Task<bool> InsertAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAllWithPaginationAsync(int pageNumber, int pageSize, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}