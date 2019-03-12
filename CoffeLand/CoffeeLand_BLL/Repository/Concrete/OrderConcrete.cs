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
    public class OrderConcrete
    {
        public IRepository<Order> _orderRepository;
        public IUnitOfWork _orderUnitOfWork;
        private DbContext _dbContext;

        public OrderConcrete()
        {
            _dbContext = new Context();
            _orderUnitOfWork = new EFUnitOfWork(_dbContext);
            _orderRepository = _orderUnitOfWork.GetRepository<Order>();
        }
    }
}
