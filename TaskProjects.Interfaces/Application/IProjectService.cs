using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProjects.Commons.Dto;
using TaskProjects.Commons.Response;

namespace TaskProjects.Interfaces.Application
{
    public interface IProjectService
    {
        #region Synchronous Methods

        Response<bool> Insert(ProjectDto entity);
        Response<bool> Update(ProjectDto entity);
        Response<bool> Delete(string id);
        Response<ProjectDto> Get(string id);
        Response<IEnumerable<ProjectDto>> GetAll();
        ResponsePagination<IEnumerable<ProjectDto>> GetAllWithPagination(int pageNumber, int pageSize);

        #endregion

        #region Asynchronous Methods

        Task<Response<bool>> InsertAsync(ProjectDto entity);
        Task<Response<bool>> UpdateAsync(ProjectDto entity);
        Task<Response<bool>> DeleteAsync(string id);
        Task<Response<ProjectDto>> GetAsync(string id);
        Task<Response<IEnumerable<ProjectDto>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<ProjectDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        #endregion
    }
}