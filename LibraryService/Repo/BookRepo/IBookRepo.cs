using LibraryService.Models;

namespace LibraryService.Repo.BookRepo
{
    public interface IBookRepo:IRepo<Book>
    {
        public Task AddCategory(Category category, int bookId);
        public Task AddAuthor(Author author, int bookId);

        public Task DeleteCategory(int categoryId, int bookId);
        public Task DeleteAuthor(int authorId, int bookId);

    }
}
