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


        public int CalculateBaristaAVGPoint()
        {
            int totalBaristaPoint = _baristaCommentRepository.GetAll().Sum(x => x.Point).Value;
            int countBaristaPoint = _baristaCommentRepository.GetAll().Count;

            double avgPoint = totalBaristaPoint / countBaristaPoint;

            int AVGPoint = Convert.ToInt32(Math.Floor(avgPoint));

            return AVGPoint;
        }
    }
}
