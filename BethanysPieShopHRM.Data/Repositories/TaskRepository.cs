using System.Collections.Generic;
using System.Linq;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Api.Models
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _appDbContext;

        public TaskRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<HRTask> GetAllTasks()
        {
            return _appDbContext.Tasks;
        }

        public HRTask GetTaskById(int TaskId)
        {
            return _appDbContext.Tasks.FirstOrDefault(c => c.HRTaskId == TaskId);
        }

        public HRTask AddTask(HRTask task)
        {
            var addedEntity = _appDbContext.Tasks.Add(task);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }
    }
}
