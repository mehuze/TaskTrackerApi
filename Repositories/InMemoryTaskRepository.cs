using TaskTrackerApi.Models;

namespace TaskTrackerApi.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private List<TaskItem> _tasks = new List<TaskItem>();
        public List<TaskItem> GetAll()
        {
            return _tasks;
        }

        public TaskItem GetById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Clear()
        {
            _tasks.Clear();
        }
        public Task<TaskItem> SaveAsync(TaskItem task)
        {
            _tasks.Add(task);
            return Task.FromResult(task);
        }
    }
}
