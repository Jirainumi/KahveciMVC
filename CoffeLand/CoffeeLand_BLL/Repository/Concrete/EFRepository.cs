using CoffeeLand_BLL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_BLL.Repository.Concrete
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        //Burada class içerisinde dbcontext ve dbset değişkenleri tanımlanır, hangi class bu yapıyı kullanacak ise constructer içerisinde onun context ve dbset'ine göre işlem yapılması gerektiği için atama işlemi gerçekleştirilir. Bu yapıyı kullanacak olan her class, burada generic olarak yazılmış olan yapıları kendisine Dependency Injection mantığı ile entegre eder. Kısacası kendisinde olmayan yapıları, kendisine özel olarak içerisinde yazılmış gibi kullanılmasına olanak sağlar. Bu şekilde SOLID prensiplerinde de bahsedilen kod tekrarının olmaması gerektiği, bir kod parçacığının bir kere yazılıp birden fazla yerde de aynı işi yapabilme yetisini kazanmasını sağlamış oluyoruz.

        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EFRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetByEntity(T entity)
        {
            return _dbSet.Find(entity);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            _dbSet.Remove(GetById(id));
        }
    }
}
