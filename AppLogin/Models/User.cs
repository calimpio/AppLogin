using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogin.Models
{
    public class User
    {
        public long id { get; set; }
        public string nickName { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }
        public DateTime bornDate { get; set; }
    }
}
