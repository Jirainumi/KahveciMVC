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
    public class AuthorizationConrete
    {
        public IRepository<Authorization> _authorizationRepository;
        public IUnitOfWork _authorizationUnitOfWork;
        private DbContext _dbContext;

        public AuthorizationConrete()
        {
            _dbContext = new Context();
            _authorizationUnitOfWork = new EFUnitOfWork(_dbContext);
            _authorizationRepository = _authorizationUnitOfWork.GetRepository<Authorization>();
        }
    }
}
