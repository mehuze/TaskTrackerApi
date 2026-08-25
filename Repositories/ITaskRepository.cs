using TaskTrackerApi.Models;
using System.Threading.Tasks;

namespace TaskTrackerApi.Repositories
{
    public interface ITaskRepository
    {
        List<TaskItem> GetAll();
        TaskItem GetById(int id);
        void Clear();
        Task<TaskItem> SaveAsync(TaskItem task);
    }
}
