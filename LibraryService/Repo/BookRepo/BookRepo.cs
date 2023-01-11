
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

        public Task AddAuthor(Author author, int bookId)
        {
            try
            {
                var book = dbContext.Books.FirstOrDefault(book => book.BookId==bookId);
                book.Authors.Add(author);
                author.Books.Add(book);
                dbContext.SaveChanges();
                return Task.CompletedTask;

            }
            catch (Exception)
            {
                throw;
            }
     
        }

        public Task AddCategory(Category category, int bookId)
        {
            try
            {
                var book = dbContext.Books.FirstOrDefault(book => book.BookId==bookId);
                book.Categories.Add(category);
                category.Books.Add(book);
                dbContext.SaveChanges();
                return Task.CompletedTask;

            }
            catch (Exception) 
            { 
              throw;
            }
        }

        public Task<int> Create(Book item)
        {
            try
            {
                var result = dbContext.Books.Add(item);
                dbContext.SaveChanges();
                return Task.FromResult(result.Entity.BookId);
            }
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }

        public Task DeleteAuthor(int authorId, int bookId)
        {
            try
            {
                var book = dbContext.Books.FirstOrDefault(x => x.BookId == bookId);
                var author = dbContext.Authors.FirstOrDefault(x => x.AuthorId ==bookId);


                var authorRef = book.Authors.FirstOrDefault(x => x.AuthorId == authorId);
                authorRef = null;

                var bookRef = author.Books.FirstOrDefault(x => x.BookId == bookId);
                bookRef = null;
                return Task.CompletedTask;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task DeleteCategory(int categoryId, int bookId)
        {
            try
            {
                var book = dbContext.Books.FirstOrDefault(x => x.BookId == bookId);

                var category = dbContext.Categories.FirstOrDefault(x => x.CategoryId == categoryId);

                dbContext.Remove(category);

                dbContext.SaveChanges();
                return Task.CompletedTask;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<IEnumerable<Book>> GetAll()
        {

            try
            {
                var result = dbContext.Books.AsEnumerable();
                return Task.FromResult(result);
            }
            catch (Exception) 
            {
             throw;
            }
        }

        public Task<Book> GetById(int id)
        {
            try
            {
                var result = dbContext.Books.FirstOrDefault((book) => book.BookId == id);
                return Task.FromResult<Book>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
