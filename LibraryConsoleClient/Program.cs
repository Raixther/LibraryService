// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;

using libraryClient;

using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");

var channel = GrpcChannel.ForAddress("http://localhost:5140");

var authorClient = new Author.AuthorClient(channel);

var bookClient = new Book.BookClient(channel);

var categoryClient = new Category.CategoryClient(channel);

Thread.Sleep(2000);

//var response = authorClient.Create(new CreateAuthorRequest(){ Name = "ddd"});

var response = authorClient.GetById(new GetAuthorByIdRequest() { AuthorId = 1 });

Console.WriteLine(response.Name);

Console.ReadKey();

