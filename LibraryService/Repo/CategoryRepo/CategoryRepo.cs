using LibraryService.Database;
using LibraryService.Models;

namespace LibraryService.Repo.CategoryRepo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext dbContext;

        public CategoryRepo(AppDbContext dbContext)
        {
            this.dbContext=dbContext;
        }

     
        public Task<int> Create(Category item)
        {
            try
            {
                var result = dbContext.Categories.Add(item);
                dbContext.SaveChanges();
                return Task.FromResult(result.Entity.CategoryId);
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
                dbContext.Remove<Category>(dbContext.Categories.FirstOrDefault((category) => category.CategoryId == id));
                dbContext.SaveChanges();
                return Task.CompletedTask;

            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                var result = dbContext.Categories.AsEnumerable();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromException<IEnumerable<Category>>(ex);
            }
        }

        public Task<Category> GetById(int id)
        {
            try
            {
                var result = dbContext.Categories.FirstOrDefault((category) => category.CategoryId== id);
                return Task.FromResult<Category>(result);
            }
            catch (Exception ex)
            {
                return Task.FromException<Category>(ex);
            }
        }
    }
}
