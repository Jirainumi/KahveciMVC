using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_DATA.Classes
{
    public class Authorization
    {
        public int ID { get; set; }
        public string AuthorizationType { get; set; }

        public virtual List<User> UsersOfAuthorization { get; set; }
    }
}
