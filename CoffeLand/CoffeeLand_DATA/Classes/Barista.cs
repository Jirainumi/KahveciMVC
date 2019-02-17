using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_DATA.Classes
{
    public class Barista
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HiredDate { get; set; }
        public decimal AVGPoint { get; set; }

        public int Age
        {
            get
            {
                return (DateTime.Now.Year - BirthDate.Year);
            }
        }
        public int YearOfExperience
        {
            get
            {
                return (DateTime.Now.Year - HiredDate.Year);
            }
        }
        public string FullName
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }

        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<BaristaComment> BaristaComments { get; set; }
    }
}
