using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeLand_BLL.Repository.Abstract;
using CoffeeLand_DAL;
using CoffeeLand_DATA.Classes;

namespace CoffeeLand_BLL.Repository.Concrete
{
    public class BaristaConcrete
    {
        public IRepository<Barista> _baristaRepository;
        public IUnitOfWork _baristaUnitOfWork;
        private DbContext _dbContext;

        public BaristaConcrete()
        {
            _dbContext = new Context();
            _baristaUnitOfWork = new EFUnitOfWork(_dbContext);
            _baristaRepository = _baristaUnitOfWork.GetRepository<Barista>();
        }
    }
}
