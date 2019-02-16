using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_BLL.Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        //Generic olarak kullanılacak olan metodlar, soyut bir biçimde ve generic yapıda tanımlanır.
        IQueryable<T> GetAll();
        T GetById(int id);
        T GetByEntity(T entity);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
