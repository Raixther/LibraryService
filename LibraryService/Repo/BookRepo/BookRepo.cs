using LibraryService.Models;

namespace LibraryService.Repo.BookRepo
{
    public class BookRepo : IBookRepo
    {
        public Task<Book> Create(Book item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
