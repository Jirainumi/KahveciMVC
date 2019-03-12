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
	public class WishListConcrete
	{
		public IRepository<WishList> _wishListRepository;
		public IUnitOfWork _wishListUnitOfWork;
		private DbContext _dbContext;

		public WishListConcrete()
		{
			_dbContext = new Context();
			_wishListUnitOfWork = new EFUnitOfWork(_dbContext);
			_wishListRepository = _wishListUnitOfWork.GetRepository<WishList>();
		}
	}
}
