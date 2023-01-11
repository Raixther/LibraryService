using library;

using LibraryService.Database;
using LibraryService.Interceptors;
using LibraryService.Repo.AuthorRepo;
using LibraryService.Repo.BookRepo;
using LibraryService.Repo.CategoryRepo;
using LibraryService.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(cfg => {
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection"));
});


builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();
builder.Services.AddScoped<IBookRepo, BookRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();

builder.Services.AddGrpc(cfg => { cfg.Interceptors.Add<ExceptionHandlerInterceptor>();}); 




builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<AuthorService>();
app.MapGrpcService<BookService>();
app.MapGrpcService<CategoryService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
