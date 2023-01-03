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
        public Task<int> Create(Author item)
        {
            try
            {
                var result = dbContext.Authors.Add(item);
               
                return Task.FromResult(result.Entity.AuthorId);
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
                dbContext.Remove<Author>(dbContext.Authors.FirstOrDefault((author) => author.AuthorId == id));
                dbContext.SaveChanges();
                return Task.CompletedTask;
                
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);      
            }
        }

        public Task<IEnumerable<Author>> GetAll()
        {
            try
            {
               var result = dbContext.Authors.AsEnumerable();
               return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromException<IEnumerable<Author>>(ex);           
            }
        }

        public Task<Author> GetById(int id)
        {
            try
            {
              var result =  dbContext.Authors.FirstOrDefault((author) => author.AuthorId == id);
              return Task.FromResult<Author>(result);
            }
            catch (Exception ex)
            {
                return Task.FromException<Author>(ex);
            }
        }
    }
}
