using LibraryService.Models;

namespace LibraryService.Repo.CategoryRepo
{
    public interface ICategoryRepo:IRepo<Category>
    {
        public Task AddBook(Book book, int categoryId);
        public Task DeleteBook(int bookId, int categoryId);
    }
}
