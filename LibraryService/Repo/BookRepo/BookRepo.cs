using LibraryService.Database;
using LibraryService.Models;

namespace LibraryService.Repo.BookRepo
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDbContext dbContext;

        public BookRepo(AppDbContext dbContext)
        {
            this.dbContext=dbContext;
        }
        public Task<int> Create(Book item)
        {
            try
            {
                var result = dbContext.Books.Add(item);
                dbContext.SaveChanges();
                return Task.FromResult(result.Entity.BookId);
            }
            catch (Exception ex)
            {
                return Task.FromException<int>(ex);
            }
        }

        public Task Delete(int id)
        {
            try
            {
                dbContext.Remove<Book>(dbContext.Books.FirstOrDefault((book) => book.BookId == id));
                dbContext.SaveChanges();
                return Task.CompletedTask;

            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        public Task<IEnumerable<Book>> GetAll()
        {

            try
            {
                var result = dbContext.Books.AsEnumerable();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromException<IEnumerable<Book>>(ex);
            }
        }

        public Task<Book> GetById(int id)
        {
            try
            {
                var result = dbContext.Books.FirstOrDefault((book) => book.BookId == id);
                return Task.FromResult<Book>(result);
            }
            catch (Exception ex)
            {
                return Task.FromException<Book>(ex);
            }
        }
    }
}
