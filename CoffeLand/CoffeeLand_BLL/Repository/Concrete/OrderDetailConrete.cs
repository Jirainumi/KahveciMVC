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
    public class OrderDetailConrete
    {
        public IRepository<OrderDetail> _orderDetailRepository;
        public IUnitOfWork _orderDetailUnitOfWork;
        private DbContext _dbContext;

        public OrderDetailConrete()
        {
            _dbContext = new Context();
            _orderDetailUnitOfWork = new EFUnitOfWork(_dbContext);
            _orderDetailRepository = _orderDetailUnitOfWork.GetRepository<OrderDetail>();
        }
    }
}
