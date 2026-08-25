using TaskTrackerApi.Models;
using TaskTrackerApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStatusCodePages();

app.MapGet("/", () => "Hello World!");
app.MapGet("/tasks", (ITaskRepository repository) =>
{
    return repository.GetAll();
});

app.MapPost("/tasks", async (TaskItem newTask, ITaskRepository repository) =>
{
    var savedTask = await repository.SaveAsync(newTask);
    return savedTask;
});
app.MapGet("/tasks/{id:int}", (int id, ITaskRepository repository) =>
{
    return repository.GetById(id);
});
app.MapGet("/tasks/status/{isCompleted:bool}", (bool isCompleted, ITaskRepository repository) =>
{
    return repository.GetAll().Where(t => t.IsCompleted == isCompleted);
});

app.Run();

