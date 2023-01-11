using AutoMapper;

using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using library;

using LibraryService.Repo;
using LibraryService.Repo.BookRepo;

namespace LibraryService.Services
{
    public class BookService : Book.BookBase
    {
        private readonly IBookRepo repo;
        private readonly IMapper mapper;

        public BookService(IBookRepo repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public override Task<AddAurthorToBookResponse> AddAuthor(AddAuthorToBookRequest request, ServerCallContext context)
        {
            var result = repo.AddAuthor(new Models.Author
            {
                Name = request.AuthorName
            }, request.BookId);
         
            if (result.IsCompletedSuccessfully)
            {
                var response = new AddAurthorToBookResponse() { Status = ResponseStatus.Success };
                return Task.FromResult(response);
            }
            else
            {
                var response = new AddAurthorToBookResponse() { Status = ResponseStatus.Fail };
                return Task.FromResult(response);
            }
        }

        public override Task<AddCategoryToBookResponse> AddCategory(AddCategoryToBookRequest request, ServerCallContext context)
        {
            var result = repo.AddCategory(new Models.Category
            {
               CategoryName = request.CategoryName
            }, request.BookId); 


            if (result.IsCompletedSuccessfully)
            {
                var response = new AddCategoryToBookResponse() { Status = ResponseStatus.Success };
                return Task.FromResult(response);
            }
            else
            {
                var response = new AddCategoryToBookResponse() { Status = ResponseStatus.Fail };
                return Task.FromResult(response);
            }
        }

        public override Task<CreateBookResponse> Create(CreateBookRequest request, ServerCallContext context)
        {
              var result = repo.Create(new Models.Book() {
              Title =request.Title, 
              Description =request.Description,
              PageCount = request.PageCount }) ;


            if (result.IsCompletedSuccessfully)
            {
                var response = new CreateBookResponse() { Status = ResponseStatus.Success , BookId =result.Result};
                return Task.FromResult(response);
            }
            else
            {
                var response = new CreateBookResponse() { Status = ResponseStatus.Fail};
                return Task.FromResult(response);
            }

        }

        public override Task<DeleteBookResponse> Delete(DeleteBookRequest request, ServerCallContext context)
        {
           var result =  repo.Delete(request.BookId);

            if (result.IsCompletedSuccessfully)
            {
                var response = new DeleteBookResponse() { Status = ResponseStatus.Success };
                return Task.FromResult(response);
            }
            else
            {
                var response = new DeleteBookResponse() { Status = ResponseStatus.Fail };
                return Task.FromResult(response);
            }
        }

        public override Task<GetAllBooksResponse> GetAll(Empty request, ServerCallContext context)
        {
            var result = repo.GetAll();
            if (result.IsCompletedSuccessfully)
            {
                var response = new GetAllBooksResponse();
                response.Books.AddRange(mapper.Map<IEnumerable<GetBookResponse>>(result.Result));
                response.Status = ResponseStatus.Success;
                return Task.FromResult(response);
            }
            else
            {
                var response = new GetAllBooksResponse();
                response.Status = ResponseStatus.Fail;
                return Task.FromResult(response);
            }
        }

        public override Task<GetBookResponse> GetById(GetBookByIdRequest request, ServerCallContext context)
        {
            var result = repo.GetById(request.Id);

            if (result.IsCompletedSuccessfully)
            {
                var response = mapper.Map<GetBookResponse>(result.Result);
                response.Status = ResponseStatus.Success;
                return Task.FromResult(response);
            }
            else
            {
                var response = new GetBookResponse();
                response.Status = ResponseStatus.Fail;
                return Task.FromResult(response);
            }
        }
    }
}
