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
    public class BaristaCommentConrete
    {
        public IRepository<BaristaComment> _baristaCommentRepository;
        public IUnitOfWork _baristaCommentUnitOfWork;
        private DbContext _dbContext;

        public BaristaCommentConrete()
        {
            _dbContext = new Context();
            _baristaCommentUnitOfWork = new EFUnitOfWork(_dbContext);
            _baristaCommentRepository = _baristaCommentUnitOfWork.GetRepository<BaristaComment>();
        }
    }
}
