using LibraryService.Database;
using LibraryService.Models;

using System.Net;

namespace LibraryService.Repo.CategoryRepo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext dbContext;

        public CategoryRepo(AppDbContext dbContext)
        {
            this.dbContext=dbContext;
        }

        public Task AddBook(Book book, int categoryId)
        {
            try
            {
                var category = dbContext.Categories.FirstOrDefault(category => category.CategoryId==categoryId);
                category.Books.Add(book);
                book.Categories.Add(category);
                dbContext.SaveChanges();
                return Task.CompletedTask;

            }
            catch (Exception) 
            {
              throw; 
            }
        }

        public Task<int> Create(Category item)
        {
            try
            {
                var result = dbContext.Categories.Add(item);
                dbContext.SaveChanges();
                return Task.FromResult(result.Entity.CategoryId);
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
                dbContext.Remove<Category>(dbContext.Categories.FirstOrDefault((category) => category.CategoryId == id));
                dbContext.SaveChanges();
                return Task.CompletedTask;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task DeleteBook(int bookId, int categoryId)
        {
            try
            {
                var category = dbContext.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
                var book = dbContext.Books.FirstOrDefault(x => x.BookId ==bookId);


                var bookRef = category.Books.FirstOrDefault(x => x.BookId == bookId);

                bookRef = null;

                var categoryRef = book.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
                categoryRef = null;
                return Task.CompletedTask;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                var result = dbContext.Categories.AsEnumerable();
                return Task.FromResult(result);
            }
            catch (Exception) { throw; }
        }

        public Task<Category> GetById(int id)
        {
            try
            {
                var result = dbContext.Categories.FirstOrDefault((category) => category.CategoryId== id);
                return Task.FromResult<Category>(result);
            }
            catch (Exception) { throw; }
        }
    }
}
