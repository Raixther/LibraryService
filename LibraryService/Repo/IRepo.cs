﻿namespace LibraryService.Repo
{
    public interface IRepo<T> where T:class
    {
        public Task<IEnumerable<T>> GetAll();
        public  Task<T> GetById(int id);
        public Task<T> Create(T item);
        public Task Delete(int id);

    }
}
