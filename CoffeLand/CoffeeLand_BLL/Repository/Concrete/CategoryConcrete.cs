using CoffeeLand_BLL.Repository.Abstract;
using CoffeeLand_DAL;
using CoffeeLand_DATA.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_BLL.Repository.Concrete
{
    public class CategoryConcrete
    {
        public IRepository<Category> _categoryRepository;
        public IUnitOfWork _categoryUnitOfWork;
        private DbContext _dbContext;

        public CategoryConcrete()
        {
            _dbContext = new Context();
            _categoryUnitOfWork = new EFUnitOfWork(_dbContext);
            _categoryRepository = _categoryUnitOfWork.GetRepository<Category>();
        }
    }
}
