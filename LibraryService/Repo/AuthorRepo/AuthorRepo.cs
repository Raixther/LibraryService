using LibraryService.Models;

namespace LibraryService.Repo.AuthorRepo
{
    public class AuthorRepo : IAuthorRepo
    {
        public Task<Author> Create(Author item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
