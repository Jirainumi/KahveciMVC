﻿using CoffeeLand_BLL.Repository.Abstract;
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
	public class CoffeeCommentConcrete
	{
		public IRepository<CoffeeComment> _coffeeCommentRepository;
		public IUnitOfWork _coffeeCommentUnitOfWork;
		private DbContext _dbContext;

		public CoffeeCommentConcrete()
		{
			_dbContext = new Context();
			_coffeeCommentUnitOfWork = new EFUnitOfWork(_dbContext);
			_coffeeCommentRepository = _coffeeCommentUnitOfWork.GetRepository<CoffeeComment>();
		}

        public int CalculateCoffeeAVGPoint()
        {
            int totalCoffeePoint = _coffeeCommentRepository.GetAll().Sum(x => x.Point).Value;
            int countCoffeePoint = _coffeeCommentRepository.GetAll().Count;

            double avgPoint = totalCoffeePoint / countCoffeePoint;

            int AVGPoint = Convert.ToInt32(Math.Round(avgPoint));

            return AVGPoint;
        }
    }
}
