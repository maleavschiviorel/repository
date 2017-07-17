using System.Collections.Generic;
using System.Linq;
using Materials.Interfaces;
using Materials;
using MyListGeneric;
using System;

namespace Magazin
{
    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        private List<T> _storage;
        public GenericRepository()
        {
            _storage = new List<T>();
        }
        public IList<T> All
        {
            get
            {
                return _storage;
            }
        }
        public void Add(T entity)
        {
            _storage.Add(entity);
        }
        public void Delete(T entity)
        {
            _storage.Remove(entity);
        }
        public void Update(T entity)
        {
            int index = _storage.FindIndex(x => x.Id == entity.Id);
            if (index != -1)
            {
                _storage[index] = entity;
            }
        }
        public T FindById(int Id)
        {
            var result = _storage.FirstOrDefault(x => x.Id == Id);
            return result;
        }
    }
}
