using AutoMapper;

using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using library;

using LibraryService.Repo.AuthorRepo;



namespace LibraryService.Services
{
    public class AuthorService : Author.AuthorBase
    {
        private readonly IAuthorRepo repo;
        private readonly IMapper mapper;

        public AuthorService(IAuthorRepo repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public override Task<AddBookToAuthorResponse> AddBook(AddBookToAuthorRequest request, ServerCallContext context)
        {
            try
            {
                var result = repo.AddBook(new Models.Book
                {
                    Title =request.BookTitle,
                    Description = request.BookDescription,
                    PageCount = request.PageCount
                },
               request.AuthorId);


             var response = new AddBookToAuthorResponse() { Status = ResponseStatus.Success };
              return Task.FromResult(response);
            }
            catch (Exception)
            {

                throw;
            }
                 
        }

        public override Task<CreateAuthorResponse> Create(CreateAuthorRequest request, ServerCallContext context)
        {
            var result = repo.Create(new Models.Author(){ Name = request.Name});
            if (result.IsCompletedSuccessfully)
            {
                var response = new CreateAuthorResponse() { Status = ResponseStatus.Success, AuthorId = result.Result };
                return Task.FromResult(response);
            }
            else
            {
                var response = new CreateAuthorResponse() { Status = ResponseStatus.Fail, AuthorId = result.Result };
                return Task.FromResult(response);
            }
            
        }
        public override Task<DeleteAuthorResponse> Delete(DeleteAuthorRequest request, ServerCallContext context)
        {
            var result = repo.Delete(request.AuthorId);


            if (result.IsCompletedSuccessfully)
            {
                var response = new DeleteAuthorResponse() { Status = ResponseStatus.Success };
                return Task.FromResult(response);
            }
            else
            {

                var response = new DeleteAuthorResponse() { Status = ResponseStatus.Fail };
                return Task.FromResult(response);
            }

        }

        public override Task<DeleteBookFromAuthorResponse> DeleteBook(DeleteBookFromAuthorRequest request, ServerCallContext context)
        {
            repo.DeleteBook(request.BookId, request.AuthorId);
            var response = new DeleteBookFromAuthorResponse() {Status = ResponseStatus.Success };
            return Task.FromResult(response);
        }

        public override Task<GetAllAuthorsResponse> GetAll(Empty request, ServerCallContext context)
        {
           var result = repo.GetAll();

            if (result.IsCompletedSuccessfully)
            {
                var response = new GetAllAuthorsResponse() { Status = ResponseStatus.Success};
                response.Authors.Add(mapper.Map<IEnumerable<GetAuthorResponse>>(result.Result));
                return Task.FromResult(response);
            }
            else
            {
                var response = new GetAllAuthorsResponse() { Status = ResponseStatus.Fail };
                return Task.FromResult(response);
            }
       }
        public override Task<GetAuthorResponse> GetById(GetAuthorByIdRequest request, ServerCallContext context)
       {
            var result = repo.GetById(request.AuthorId);

            if (result.IsCompletedSuccessfully)
            {
                var response = mapper.Map<GetAuthorResponse>(result.Result);
                response.Status = ResponseStatus.Success;
                return Task.FromResult(response);
            }
           else
            {
               var response = new GetAuthorResponse();
               response.Status = ResponseStatus.Fail;
               return Task.FromResult(response);
           }       
        }
    }
}
