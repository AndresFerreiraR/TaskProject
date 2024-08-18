using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProjects.Domain.Entities;

namespace TaskProjects.Interfaces.Persistence
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        
    }
}