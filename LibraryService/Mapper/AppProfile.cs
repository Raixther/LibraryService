using AutoMapper;

using library;

namespace LibraryService.Mapper
{
    public class AppProfile:Profile
    {
        public AppProfile()
        {
            CreateMap<Models.Author, GetAuthorResponse>().ForSourceMember(m => m.AuthorId, opts=>opts.DoNotValidate());
            CreateMap<Models.Book, GetBookResponse>().ForSourceMember(m => m.BookId, opts => opts.DoNotValidate());
            CreateMap<Models.Category, GetCategoryResponse>().ForSourceMember(m => m.CategoryId, opts => opts.DoNotValidate()); ;
            
        }
    }
}
