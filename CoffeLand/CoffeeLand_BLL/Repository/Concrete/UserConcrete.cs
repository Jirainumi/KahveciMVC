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
    public class UserConcrete
    {
        public IRepository<Customer> _userRepository;
        public IUnitOfWork _userUnitOfWork;
        private DbContext _dbContext;

        public UserConcrete()
        {
            _dbContext = new Context();
            _userUnitOfWork = new EFUnitOfWork(_dbContext);
            _userRepository = _userUnitOfWork.GetRepository<Customer>();
        }
    }
}
