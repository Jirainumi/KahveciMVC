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
    public class CustomerConcrete
    {
        public IRepository<Customer> _customerRepository;
        public IUnitOfWork _customerUnitOfWork;
        private DbContext _dbContext;

        public CustomerConcrete()
        {
            _dbContext = new Context();
            _customerUnitOfWork = new EFUnitOfWork(_dbContext);
            _customerRepository = _customerUnitOfWork.GetRepository<Customer>();
        }

        public Customer GetCustomerByUsername(string username)
        {
            return _customerRepository.GetAll().FirstOrDefault(x => x.UserName == username);
        }

        public Customer LoginControl(string username,string password)
        {
            return _customerRepository.GetAll().FirstOrDefault(x => x.UserName == username && x.Password == password);
        }
    }
}
