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
    public class ExtraMaterialsConcrete
    {
        public IRepository<ExtraMaterial> _extraMaterialRepository;
        public IUnitOfWork _extraMaterialUnitOfWork;
        private DbContext _dbContext;

        public ExtraMaterialsConcrete()
        {
            _dbContext = new Context();
            _extraMaterialUnitOfWork = new EFUnitOfWork(_dbContext);
            _extraMaterialRepository = _extraMaterialUnitOfWork.GetRepository<ExtraMaterial>();
        }
    }
}
