using LibraryService.Models;

namespace LibraryService.Repo.CategoryRepo
{
    public class CategoryRepo : ICategoryRepo
    {
        public Task<Category> Create(Category item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
