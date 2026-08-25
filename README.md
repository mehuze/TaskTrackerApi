
TaskTracker API

A simple task management REST API built with ASP.NET Core Minimal APIs, created as a hands-on learning project to practice routing, dependency injection, and error handling.

Basit bir görev (task) yönetim API'si — ASP.NET Core Minimal API ile yapıldı. Routing, dependency injection ve error handling konularını pratik etmek için sıfırdan yazılan bir öğrenme projesi.



What this project does / Bu proje ne yapıyor

An in-memory API that lets you create tasks, list all tasks, get a single task by id, and filter tasks by completion status.

Task oluşturma, tüm task'ları listeleme, id'ye göre tek bir task getirme ve tamamlanma durumuna göre filtreleme yapabilen, verileri hafızada (in-memory) tutan bir API.


Endpoints
Method	Route	Description (EN) 	                                        Açıklama (TR)  

GET	/	Health check, returns "Hello World!"	                         Sağlık kontrolü, "Hello World!" döner
GET	/tasks	Returns all tasks	                                         Tüm task'ları döner
POST	/tasks	Creates a new task from the request body	             Gövdeden gelen bilgiyle yeni bir task oluşturur
GET	/tasks/{id}	Returns a single task by its id (route constraint: int) -Id'sine göre tek bir task döner (route kısıtı: int)
GET	/tasks/status/{isCompleted}	Returns tasks filtered by
completion status (route constraint: bool)	                             Tamamlanma durumuna göre filtrelenmiş task'ları döner (route kısıtı: bool)


What I learned and applied / Ne öğrendim, ne uyguladım

Routing (EN): Minimal API endpoints are defined with app.MapGet/app.MapPost, mapping an HTTP method + URL pattern to a handler. Route parameters like {id:int} and {isCompleted:bool} add type constraints, so ASP.NET Core automatically returns a 404 if the value doesn't match the expected type.

Routing (TR): Minimal API endpoint'leri app.MapGet/app.MapPost ile tanımlanır — bir HTTP metodu + URL kalıbını bir işleyiciye (handler) bağlar. {id:int} ve {isCompleted:bool} gibi route parametreleri tip kısıtı ekler; değer beklenen tipe uymazsa ASP.NET Core otomatik olarak 404 döner.

Dependency Injection (EN): ITaskRepository is registered as a Singleton service (AddSingleton) and implemented by InMemoryTaskRepository. Endpoints depend on the interface, not the concrete class — so the storage implementation could be swapped (e.g. for a real database) without changing any endpoint code.

Dependency Injection (TR): ITaskRepository, Singleton olarak kaydedildi (AddSingleton) ve InMemoryTaskRepository tarafından gerçeklendi (implement edildi). Endpoint'ler somut sınıfa değil, interface'e bağımlı — bu yüzden depolama mantığı (mesela gerçek bir veritabanına) hiçbir endpoint kodu değişmeden değiştirilebilir.

Async/Await (EN): SaveAsync returns Task<TaskItem>, so it's called with await inside an async lambda — practicing how asynchronous operations are handled in C#, even for an operation that completes instantly in this in-memory version.

Async/Await (TR): SaveAsync, Task<TaskItem> döndürdüğü için async bir lambda içinde await ile çağrılıyor — bu in-memory versiyonda işlem anında bitse bile, C#'ta asenkron işlemlerin nasıl ele alındığını pratik etmek için kullanıldı.

Error Handling (EN): UseDeveloperExceptionPage() shows detailed errors in development. UseStatusCodePages() returns a readable response for status codes like 404, instead of an empty body.

Error Handling (TR): UseDeveloperExceptionPage(), geliştirme ortamında detaylı hata gösterir. UseStatusCodePages(), 404 gibi durum kodlarında boş gövde yerine okunabilir bir cevap döner.

Known limitation / Bilinen sınırlama

Data is stored in memory only — it resets every time the application restarts. This was a deliberate choice to focus on learning routing/DI/error handling first, before adding a real database.

Veriler sadece hafızada tutuluyor — uygulama her yeniden başladığında sıfırlanıyor. Bu, gerçek bir veritabanı eklemeden önce routing/DI/error handling konularına odaklanmak için bilinçli bir tercihti.



How to run / Nasıl çalıştırılır
bash
dotnet run

Then visit https://localhost:{port}/tasks (port is shown in the console output).

Sonra https://localhost:{port}/tasks adresine git (port, konsol çıktısında görünür).