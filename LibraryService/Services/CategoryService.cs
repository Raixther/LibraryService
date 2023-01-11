using AutoMapper;

using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using library;

using LibraryService.Repo.CategoryRepo;

namespace LibraryService.Services
{
    public class CategoryService : Category.CategoryBase
    {
        private readonly ICategoryRepo repo;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepo repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public override Task<AddBookToCategoryResponse> AddBook(AddBookToCategoryRequest request, ServerCallContext context)
        {
            var result = repo.AddBook(new Models.Book() { Title = request.BookTitle, Description = request.BookDescription, PageCount = request.PageCount },
            request.CategoryId);
            if (result.IsCompletedSuccessfully)
            {
                var response = new AddBookToCategoryResponse() { Status = ResponseStatus.Success };
                return Task.FromResult(response);
            }
            else
            {
                var response = new AddBookToCategoryResponse() { Status = ResponseStatus.Fail };
                return Task.FromResult(response);
            }
        }
        public override Task<CreateCategoryResponse> Create(CreateCategoryRequest request, ServerCallContext context)
        {
            var result = repo.Create(new Models.Category() { CategoryName =request.CategoryName });

            if (result.IsCompletedSuccessfully)
            {
                var response = new CreateCategoryResponse() { Status = ResponseStatus.Success, CategoryId = result.Id };
                return Task.FromResult(response);
            }
            else
            {
                var response = new CreateCategoryResponse() { Status = ResponseStatus.Fail };
                return Task.FromResult(response);
            }


        }
        public override Task<DeleteCategoryResponse> Delete(DeleteCategoryRequest request, ServerCallContext context)
        {
            var result = repo.Delete(request.CategoryId);

            if (result.IsCompletedSuccessfully)
            {
                var response = new DeleteCategoryResponse() { Status = ResponseStatus.Success };
                return Task.FromResult(response);
            }
            else
            {
                var response = new DeleteCategoryResponse() { Status = ResponseStatus.Fail };
                return Task.FromResult(response);
            }
        }
        public override Task<GetAllCategoriesResponse> GetAll(Empty request, ServerCallContext context)
        {
            var result = repo.GetAll();
            if (result.IsCompletedSuccessfully)
            {
                var response = new GetAllCategoriesResponse();
                response.Categories.AddRange(mapper.Map<IEnumerable<GetCategoryResponse>>(result.Result));
                response.Status = ResponseStatus.Success;
                return Task.FromResult(response);
            }
            else
            {
                var response = new GetAllCategoriesResponse();
                response.Status = ResponseStatus.Fail;
                return Task.FromResult(response);
            }
        }
        public override Task<GetCategoryResponse> GetById(GetCategoryByIdRequest request, ServerCallContext context)
        {
            var result = repo.GetById(request.CategoryId);
            if (result.IsCompletedSuccessfully)
            {         
                var response = mapper.Map<GetCategoryResponse>(result.Result);
                response.Books.AddRange(mapper.Map<IEnumerable<GetBookResponse>>(result.Result.Books));
                response.Status = ResponseStatus.Success;
                return Task.FromResult(response);
            }
            else
            {
                var response = new GetCategoryResponse();
                response.Status = ResponseStatus.Fail;
                return Task.FromResult(response);
            }

        }
    }
}

