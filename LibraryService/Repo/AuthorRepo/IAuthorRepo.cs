using LibraryService.Models;

namespace LibraryService.Repo.AuthorRepo
{
    public interface IAuthorRepo:IRepo<Author>
    {
        public Task AddBook(Book book, int authorId);

        public Task DeleteBook(int bookId, int authorId);
    }
}
