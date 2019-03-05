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
	public class CoffeeConcrete
	{
		public IRepository<Coffee> _coffeeRepository;
		public IUnitOfWork _coffeeUnitOfWork;
		private DbContext _dbContext;

		public CoffeeConcrete()
		{
			_dbContext = new Context();
			_coffeeUnitOfWork = new EFUnitOfWork(_dbContext);
			_coffeeRepository = _coffeeUnitOfWork.GetRepository<Coffee>();
		}

		public int CoffeeIdByCoffeeName(string coffeeName)
		{
			return _coffeeRepository.GetEntity().FirstOrDefault(x => x.CoffeeName.ToLower() == coffeeName.ToLower()).ID;
		}
	}
}
