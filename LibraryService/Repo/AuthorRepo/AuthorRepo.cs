using LibraryService.Database;
using LibraryService.Models;

namespace LibraryService.Repo.AuthorRepo
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly AppDbContext dbContext;

        public AuthorRepo(AppDbContext dbContext)
        {
            this.dbContext=dbContext;
        }

        public Task AddBook(Book book, int authorId)
        {
            try
            {
               var author = dbContext.Authors.FirstOrDefault((author) => author.AuthorId == authorId);
               author.Books.Add(book);
               book.Authors.Add(author);
               dbContext.SaveChanges();
               return Task.CompletedTask;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> Create(Author item)
        {
            try
            {
                var result = dbContext.Authors.Add(item);

                dbContext.SaveChanges();
               
                return Task.FromResult(result.Entity.AuthorId);
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
                dbContext.Remove<Author>(dbContext.Authors.FirstOrDefault((author) => author.AuthorId == id));
                dbContext.SaveChanges();
                return Task.CompletedTask;
                
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);      
            }
        }

        public Task DeleteBook(int bookId, int authorId)
        {
            try
            {
                var author = dbContext.Authors.FirstOrDefault(x => x.AuthorId == authorId);
                var book = dbContext.Books.FirstOrDefault(x => x.BookId == bookId);

                var bookRef = author.Books.FirstOrDefault(x=>x.BookId == bookId);
                bookRef = null;

                var authorRef = book.Authors.FirstOrDefault(x => x.AuthorId == authorId);
                authorRef = null;
                return Task.CompletedTask;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public Task<IEnumerable<Author>> GetAll()
        {
            try
            {
               var result = dbContext.Authors.AsEnumerable();
               return Task.FromResult(result);
            }
            catch (Exception)
            {
                throw;       
            }
        }

        public Task<Author> GetById(int id)
        {
            try
            {
              var result =  dbContext.Authors.FirstOrDefault((author) => author.AuthorId == id);
              return Task.FromResult<Author>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
